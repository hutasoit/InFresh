using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using InFresh.Framework.v1.Globals;
using InFresh.Framework.v1.Models.Masters;
using InFresh.Framework.v1.Models.Systems;
using InFresh.Master.v1.Implements;
using InFresh.Utilization.v1.OleProcessor;
using InFresh.Utilization.v1.Processors;

namespace InFresh.Master.v1.Wizards.Imports
{
    public partial class MW003_ImportSupplier : Form
    {
        #region Constructor & Properties
        /// <summary>
        /// 
        /// </summary>
        public MW003_ImportSupplier()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 
        /// </summary>
        protected const string Entity = "SPLR";
        /// <summary>
        /// 
        /// </summary>
        protected string TResult = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        protected IOProcessor Processor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<string> HeaderFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<SupplierDto> Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected Template1Dto Template { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<Template2Dto> FieldsTemplate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<SupplierDto> ExistSuppliers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<Template1Dto> Templates { get; set; }
        #endregion

        #region UI Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            tspProgress.Visible = true;
            tsxStatus.Text = MasterModule.Handler.Resources.GetString("Load_References");

            if (!bgwWorker.IsBusy)
                bgwWorker.RunWorkerAsync(WizardSequence.FormLoad);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closed(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonItem_Click(object sender, EventArgs e)
        {
            if (sender == btnBrowse)
            {
                ofpFileDialog.ShowDialog();
                return;
            }

            if (sender == btnShowData)
            {
                pnlData.Enabled = btnShowData.Enabled = false;
                crlDataLoading.Visible = true;
                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(WizardSequence.DataLoad);
                return;
            }

            if (sender == btnSave)
            {
                btnBrowse.Enabled = cmbSheet.Enabled = cmbTemplate.Enabled =
                pnlField.Enabled = btnShowData.Enabled =
                pnlData.Enabled = btnSave.Enabled = false;
                tsxStatus.Text = "Saving Data...";
                tspProgress.Visible = true;
                tspProgress.Value = 0;

                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(WizardSequence.DataSaving);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cmbSheet)
            {
                crlFieldLoading.Visible = true;
                pnlField.Enabled = btnShowData.Enabled = false;
                dgvData.DataSource = null;
                if (Template != null)
                    Template = null;
                if (FieldsTemplate != null)
                    FieldsTemplate = null;
                if (Data != null)
                    Data.Clear();

                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(WizardSequence.SheetLoad);
                return;
            }

            if (sender == cmbTemplate)
            {
                if (cmbTemplate.SelectedIndex != 0)
                    Template = (cmbTemplate.SelectedValue as Template1Dto);
                else
                    Template = null;

                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(WizardSequence.TemplateLoad);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (sender == ofpFileDialog)
            {
                if (!e.Cancel)
                {
                    txtFilename.Text = ofpFileDialog.FileName;

                    string ext = Path.GetExtension(txtFilename.Text.Trim());

                    if (ext.Equals(".xls") || ext.Equals(".xlsx"))
                        Processor = new XlsOleProcessor(txtFilename.Text.Trim());
                    else if (ext.Equals(".csv")) { }

                    if (!bgwWorker.IsBusy)
                        bgwWorker.RunWorkerAsync(WizardSequence.FileLoad);
                }
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender == bgwWorker)
            {
                WizardSequence idx = WizardSequence.IDLE;
                try
                {
                    idx = (WizardSequence)e.Argument;
                    if (idx != WizardSequence.IDLE)
                    {
                        switch (idx)
                        {
                            case WizardSequence.FormLoad:
                                if (Templates != null)
                                    Templates.Clear();

                                Templates = MasterModule.Handler.RepositoryV2.Get<Template1Dto>()
                                                .Where(m => m.Status == 1).ToList();
                                Templates.Insert(0, new Template1Dto
                                {
                                    Description = string.Format(MasterModule.Handler.Resources.GetString("Select_Item"), "template")
                                });

                                ExistSuppliers = MasterModule.Handler.RepositoryV2.Get<SupplierDto>()
                                                .Where(m => m.Status == 1).ToList();

                                e.Cancel = false;
                                e.Result = idx;
                                break;
                            case WizardSequence.DataSaving:
                                try
                                {
                                    TResult = MasterModule.Handler.RepositoryV2.Insert<SupplierDto>(Data);
                                    e.Cancel = false;
                                    e.Result = idx;
                                }
                                catch (Exception ex)
                                {
                                    e.Cancel = true;
                                    e.Result = ex.Message;
                                }
                                break;
                            case WizardSequence.TemplateSaving:
                                try
                                {
                                    TResult = MasterModule.Handler.RepositoryV2.Insert<Template1Dto>(Template);
                                    if (TResult.Equals("0"))
                                        TResult = MasterModule.Handler.RepositoryV2.Insert<Template2Dto>(FieldsTemplate);

                                    e.Cancel = false;
                                    e.Result = idx;
                                }
                                catch (Exception ex)
                                {
                                    e.Cancel = true;
                                    e.Result = ex.Message;
                                }
                                break;
                            default:
                                e.Cancel = false;
                                e.Result = idx;
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    e.Result = ex.Message;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sender == bgwWorker)
            {
                if (!e.Cancelled)
                {
                    WizardSequence idx = WizardSequence.IDLE;

                    try
                    {
                        idx = (WizardSequence)e.Result;
                        if (idx != WizardSequence.IDLE)
                        {
                            switch (idx)
                            {
                                case WizardSequence.FormLoad:
                                    btnBrowse.Enabled = true;
                                    tspProgress.Visible = false;
                                    tsxStatus.Text = MasterModule.Handler.Resources.GetString("Ready");
                                    break;
                                case WizardSequence.FileLoad:
                                    cmbSheet.DataSource = new BindingSource(Processor.GetSheets(), null);
                                    cmbSheet.DisplayMember = "Value";
                                    cmbSheet.ValueMember = "Key";
                                    cmbSheet.SelectedIndex = 0;
                                    break;
                                case WizardSequence.SheetLoad:
                                    if (HeaderFile != null)
                                        HeaderFile.Clear();
                                    HeaderFile = Processor.GetHeaders(cmbSheet.SelectedValue.ToString());
                                    HeaderFile.Insert(0, string.Format(MasterModule.Handler.Resources.GetString("Select_Item"), string.Empty));

                                    cmbOldCodeField.DataSource = new List<string>(HeaderFile);
                                    cmbNameField.DataSource = new List<string>(HeaderFile);
                                    cmbAdd1Field.DataSource = new List<string>(HeaderFile);
                                    cmbAdd2Field.DataSource = new List<string>(HeaderFile);
                                    cmbCityField.DataSource = new List<string>(HeaderFile);
                                    cmbZipCodeField.DataSource = new List<string>(HeaderFile);
                                    cmbContactField.DataSource = new List<string>(HeaderFile);
                                    cmbPhone1Field.DataSource = new List<string>(HeaderFile);
                                    cmbFax1Field.DataSource = new List<string>(HeaderFile);
                                    cmbEmailField.DataSource = new List<string>(HeaderFile);

                                    cmbTemplate.DataSource = Templates;
                                    //cmbTemplate.ValueMember = "Code";

                                    if (Templates.Count == 1)
                                    {
                                        if (!string.IsNullOrWhiteSpace(Templates[0].Code))
                                            cmbTemplate.Enabled = true;
                                    }
                                    else
                                        cmbTemplate.Enabled = true;
                                    cmbTemplate.SelectedIndex = 0;

                                    cmbSheet.Enabled = pnlField.Enabled = btnShowData.Enabled = true;
                                    crlFieldLoading.Visible = false;
                                    break;
                                case WizardSequence.TemplateLoad:
                                    ReadTemplate();
                                    break;
                                case WizardSequence.DataLoad:
                                    if (MappingValid())
                                    {
                                        if (MappingValue())
                                        {

                                            dgvData.DataSource = null;
                                            dgvData.DataSource = new BindingList<SupplierDto>(Data);
                                            pnlData.Enabled = true;

                                            if (Data.Count != 0)
                                                btnSave.Enabled = true;

                                            MappingTemplate();
                                        }
                                    }
                                    else
                                    {
                                        pnlData.Enabled = false;
                                    }
                                    pnlField.Enabled = btnShowData.Enabled = true;
                                    crlDataLoading.Visible = false;
                                    break;
                                case WizardSequence.DataSaving:
                                    if (TResult.Equals("0"))
                                    {
                                        if (cmbTemplate.SelectedIndex == 0)
                                        {
                                            if (MessageBox.Show(this,
                                                "Do you want to save this template?",
                                                MasterModule.Name,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                TResult = string.Empty;
                                                tsxStatus.Text = "Saving Template...";
                                                tspProgress.Visible = true;
                                                tspProgress.Value = 0;

                                                if (!bgwWorker.IsBusy)
                                                    bgwWorker.RunWorkerAsync(WizardSequence.TemplateSaving);
                                            }
                                            else
                                                this.Close();
                                        }
                                        else
                                            this.Close();
                                    }
                                    break;
                                case WizardSequence.TemplateSaving:
                                    if (TResult.Equals("0"))
                                    {
                                        tsxStatus.Text = "Complete all task";
                                        tspProgress.Visible = false;

                                        try
                                        {
                                            Thread.Sleep(1000);
                                        }
                                        catch { }
                                        this.Close();
                                    }
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show(e.Result.ToString());
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool MappingValid()
        {
            if (cmbNameField.SelectedIndex == 0 &&
                        cmbAdd1Field.SelectedIndex == 0)
            {
                MessageBox.Show(null,
                    string.Format(MasterModule.Handler.Resources.GetString("Fields_Required"),
                        string.Format("- {0} \n -{1}", "Supplier Name", "Subdepo Address")),
                    MasterModule.Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmbNameField.Focus();
                return false;
            }
            else if (cmbNameField.SelectedIndex == 0)
            {
                MessageBox.Show(null,
                    string.Format(MasterModule.Handler.Resources.GetString("Field_Required"), "Supplier Name"),
                    MasterModule.Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmbNameField.Focus();
                return false;
            }
            else if (cmbAdd1Field.SelectedIndex == 0)
            {
                MessageBox.Show(null,
                    string.Format(MasterModule.Handler.Resources.GetString("Field_Required"), "Supplier Address"),
                    MasterModule.Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmbAdd1Field.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool MappingValue()
        {
            var rows = Processor.GetData(cmbSheet.SelectedValue.ToString()).AsEnumerable();

            Data = new List<SupplierDto>();
            string errMsg = string.Empty;
            try
            {
                int count = ExistSuppliers.Count();
                SupplierDto mm = null;
                int ii = 0;
                foreach (var row in rows)
                {
                    mm = new SupplierDto();
                    if (chkCode.Checked)
                    {
                        count++;
                        mm.Code = string.Format("{0:0000000}", count);
                    }
                    if (cmbOldCodeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbOldCodeField.SelectedValue.ToString()) != null)
                            mm.OldCode = row.Field<object>(cmbOldCodeField.SelectedValue.ToString()).ToString();
                        else
                            mm.OldCode = string.Empty;
                    }
                    if (cmbNameField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbNameField.SelectedValue.ToString()) != null)
                            mm.Name = row.Field<object>(cmbNameField.SelectedValue.ToString()).ToString();
                        else
                        {
                            mm.Name = mm.Code;
                            errMsg += "Error Name Supplier on line " + (ii + 1) + "\n";
                        }
                    }
                    if (cmbAdd1Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbAdd1Field.SelectedValue.ToString()) != null)
                            mm.Address1 = row.Field<object>(cmbAdd1Field.SelectedValue.ToString()).ToString();
                        else
                        {
                            mm.Address1 = mm.Code;
                            errMsg += "Error Address Supplier on line " + (ii + 1) + "\n";
                        }
                    }
                    if (cmbAdd2Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbAdd2Field.SelectedValue.ToString()) != null)
                            mm.Address2 = row.Field<object>(cmbAdd2Field.SelectedValue.ToString()).ToString();
                        else
                            mm.Address2 = string.Empty;
                    }
                    if (cmbCityField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCityField.SelectedValue.ToString()) != null)
                            mm.City = row.Field<object>(cmbCityField.SelectedValue.ToString()).ToString();
                        else
                            mm.City = string.Empty;
                    }
                    if (cmbZipCodeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbZipCodeField.SelectedValue.ToString()) != null)
                            mm.ZipCode = row.Field<object>(cmbZipCodeField.SelectedValue.ToString()).ToString();
                        else
                            mm.ZipCode = string.Empty;
                    }
                    if (cmbContactField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbContactField.SelectedValue.ToString()) != null)
                            mm.Contact = row.Field<object>(cmbContactField.SelectedValue.ToString()).ToString();
                        else
                            mm.Contact = string.Empty;
                    }
                    if (cmbPhone1Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbPhone1Field.SelectedValue.ToString()) != null)
                            mm.Phone1 = row.Field<object>(cmbPhone1Field.SelectedValue.ToString()).ToString();
                        else
                            mm.Phone1 = string.Empty;
                    }
                    if (cmbFax1Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbFax1Field.SelectedValue.ToString()) != null)
                            mm.Fax1 = row.Field<object>(cmbFax1Field.SelectedValue.ToString()).ToString();
                        else
                            mm.Fax1 = string.Empty;
                    }
                    if (cmbEmailField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbEmailField.SelectedValue.ToString()) != null)
                            mm.Email = row.Field<object>(cmbEmailField.SelectedValue.ToString()).ToString();
                        else
                            mm.Email = string.Empty;
                    }

                    Data.Add(mm);
                    ii++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null,
                        ex.Message,
                        MasterModule.Name,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(errMsg))
            {
                if (MessageBox.Show(null,
                        errMsg,
                        MasterModule.Name,
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Warning) == DialogResult.Ignore)
                    return true;
                else
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void MappingTemplate()
        {
            if (cmbTemplate.SelectedIndex == 0)
            {
                string code = string.Empty;
                if (Templates.Count == 1)
                    code = string.Format("IM{0}{1:000}", Entity, 1);
                else
                    code = string.Format("IM{0}{1:000}", Entity, Templates.Count);

                Template = new Template1Dto()
                {
                    Code = code,
                    Description = string.Format("Template Import Supplier {0}", Templates.Count),
                    Type = GlobalTemplate.Import,
                    Entity = Entity
                };
                if (FieldsTemplate != null)
                    FieldsTemplate.Clear();
                else FieldsTemplate = new List<Template2Dto>();
                if (cmbNameField.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 1,
                        Source = cmbNameField.SelectedValue.ToString(),
                        Destination = "SPSPNM"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 1,
                        Source = string.Empty,
                        Destination = "SPSPNM"
                    });

                if (cmbPhone1Field.SelectedIndex != 0)
                {
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 2,
                        Source = cmbOldCodeField.SelectedValue.ToString(),
                        Destination = "SPSPON"
                    });
                }
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 2,
                        Source = string.Empty,
                        Destination = "SPSPON"
                    });

                if (cmbAdd1Field.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 3,
                        Source = cmbAdd1Field.SelectedValue.ToString(),
                        Destination = "SPADD1"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 3,
                        Source = string.Empty,
                        Destination = "SPADD1"
                    });

                if (cmbAdd2Field.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 4,
                        Source = cmbAdd2Field.SelectedValue.ToString(),
                        Destination = "SPADD2"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 4,
                        Source = string.Empty,
                        Destination = "SPADD2"
                    });

                if (cmbCityField.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 5,
                        Source = cmbCityField.SelectedValue.ToString(),
                        Destination = "SPCITY"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 5,
                        Source = string.Empty,
                        Destination = "SPCITY"
                    });

                if (cmbZipCodeField.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 6,
                        Source = cmbZipCodeField.SelectedValue.ToString(),
                        Destination = "SPZPCD"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 6,
                        Source = string.Empty,
                        Destination = "SPZPCD"
                    });
                if (cmbContactField.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 7,
                        Source = cmbContactField.SelectedValue.ToString(),
                        Destination = "SPCTNM"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 7,
                        Source = string.Empty,
                        Destination = "SPCTNM"
                    });
                if (cmbPhone1Field.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 8,
                        Source = cmbPhone1Field.SelectedValue.ToString(),
                        Destination = "SPPHN1"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 8,
                        Source = string.Empty,
                        Destination = "SPPHN1"
                    });

                if (cmbFax1Field.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 9,
                        Source = cmbFax1Field.SelectedValue.ToString(),
                        Destination = "SDFAX1"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 9,
                        Source = string.Empty,
                        Destination = "SDFAX1"
                    });
                if (cmbEmailField.SelectedIndex != 0)
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 10,
                        Source = cmbEmailField.SelectedValue.ToString(),
                        Destination = "SPEMIL"
                    });
                else
                    FieldsTemplate.Add(new Template2Dto()
                    {
                        Code = code,
                        Sequence = 10,
                        Source = string.Empty,
                        Destination = "SPEMIL"
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadTemplate()
        {
            if (cmbTemplate.SelectedIndex != 0)
            {
                if (Template.FieldsTemplate.Count != 0)
                {
                    var header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPSPNM"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbNameField.Text = header;
                        else
                            cmbNameField.SelectedIndex = 0;
                    }
                    else
                        cmbNameField.SelectedIndex = 0;
                    cmbNameField.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPSPON"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbOldCodeField.Text = header;
                        else
                            cmbOldCodeField.SelectedIndex = 0;
                    }
                    else
                        cmbOldCodeField.SelectedIndex = 0;
                    cmbOldCodeField.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPADD1"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbAdd1Field.Text = header;
                        else
                            cmbAdd1Field.SelectedIndex = 0;
                    }
                    else
                        cmbAdd1Field.SelectedIndex = 0;
                    cmbAdd1Field.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPADD2"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbAdd2Field.Text = header;
                        else
                            cmbAdd2Field.SelectedIndex = 0;
                    }
                    else
                        cmbAdd2Field.SelectedIndex = 0;
                    cmbAdd2Field.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPCITY"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbCityField.Text = header;
                        else
                            cmbCityField.SelectedIndex = 0;
                    }
                    else
                        cmbCityField.SelectedIndex = 0;
                    cmbCityField.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPZPCD"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbZipCodeField.Text = header;
                        else
                            cmbZipCodeField.SelectedIndex = 0;
                    }
                    else
                        cmbZipCodeField.SelectedIndex = 0;
                    cmbZipCodeField.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPCTNM"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbContactField.Text = header;
                        else
                            cmbContactField.SelectedIndex = 0;
                    }
                    else
                        cmbContactField.SelectedIndex = 0;
                    cmbContactField.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPPHN1"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbPhone1Field.Text = header;
                        else
                            cmbPhone1Field.SelectedIndex = 0;
                    }
                    else
                        cmbPhone1Field.SelectedIndex = 0;
                    cmbPhone1Field.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPFAX1"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbFax1Field.Text = header;
                        else
                            cmbFax1Field.SelectedIndex = 0;
                    }
                    else
                        cmbFax1Field.SelectedIndex = 0;
                    cmbFax1Field.Enabled = false;

                    header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SPEMIL"))
                                    .Select(m => m.Source).FirstOrDefault();
                    if (!string.IsNullOrWhiteSpace(header))
                    {
                        if (HeaderFile.Contains(header))
                            cmbEmailField.Text = header;
                        else
                            cmbEmailField.SelectedIndex = 0;
                    }
                    else
                        cmbFax1Field.SelectedIndex = 0;
                    cmbEmailField.Enabled = false;
                }
            }
        }
        #endregion
    }
}
