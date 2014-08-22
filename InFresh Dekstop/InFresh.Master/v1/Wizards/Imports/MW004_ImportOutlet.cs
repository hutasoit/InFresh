using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using InFresh.Framework.v1.Enums;
using InFresh.Framework.v1.Globals;
using InFresh.Framework.v1.Models.Details;
using InFresh.Framework.v1.Models.Masters;
using InFresh.Framework.v1.Models.Systems;
using InFresh.Master.v1.Implements;
using InFresh.Master.v1.Lists;
using InFresh.Utilization.v1.OleProcessor;
using InFresh.Utilization.v1.Processors;

namespace InFresh.Master.v1.Wizards.Imports
{
    public partial class MW004_ImportOutlet : Form
    {
        #region Contructors and Properties
        /// <summary>
        /// 
        /// </summary>
        public MW004_ImportOutlet()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = dgvTaxes.AutoGenerateColumns = dgvGroup.AutoGenerateColumns =
                dgvAdministration.AutoGenerateColumns = dgvTransaction.AutoGenerateColumns =
                dgvContacts.AutoGenerateColumns = dgvAccounts.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 
        /// </summary>
        protected const string Entity = "OTLT";
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
        protected IList<OutletDto> Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<OutletPart1Dto> Part1s { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<OutletContactDto> Contacts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected IList<OutletAccountDto> Accounts { get; set; }
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
        protected IList<OutletDto> ExistOutlets { get; set; }
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
                bgwWorker.RunWorkerAsync(ImportSequence.FormLoad);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (bgwWorker.IsBusy)
                e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closed(object sender, FormClosedEventArgs e)
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
                    bgwWorker.RunWorkerAsync(ImportSequence.DataLoad);
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
                    bgwWorker.RunWorkerAsync(ImportSequence.DataSaving);
                return;
            }

            if (sender == btnSearchSubdepo)
            {
                using (var f = new MS001_ListSubdepo(this))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        SubdepoDto s = f.Tag as SubdepoDto;

                        txtSubdepoCode.Text = s.Code;
                        txtSubdepoName.Text = s.Name;
                        txtSubdepoCode.Tag = s;
                    }
                    else
                        txtSubdepoCode.Focus();
                }
                return;
            }

            if (sender == btnSearchSupplier)
            {
                //using (var f = new FSSupplier(this))
                //{
                //    if (f.ShowDialog() == DialogResult.OK)
                //    {
                //        SupplierDto s = f.Tag as SupplierDto;

                //        txtSupplierCode.Text = s.Code;
                //        txtSupplierName.Text = s.Name;
                //        txtSupplierCode.Tag = s;
                //    }
                //    else
                //        txtSupplierCode.Focus();
                //}
                //return;
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
                    bgwWorker.RunWorkerAsync(ImportSequence.SheetLoad);
                return;
            }

            if (sender == cmbTemplate)
            {
                if (cmbTemplate.SelectedIndex != 0)
                    Template = (cmbTemplate.SelectedValue as Template1Dto);
                else
                    Template = null;

                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(ImportSequence.TemplateLoad);
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
                        bgwWorker.RunWorkerAsync(ImportSequence.FileLoad);
                }
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioItem_CheckedChanged(object sender, EventArgs e)
        {

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
                ImportSequence idx = ImportSequence.IDLE;
                try
                {
                    idx = (ImportSequence)e.Argument;
                    if (idx != ImportSequence.IDLE)
                    {
                        switch (idx)
                        {
                            case ImportSequence.FormLoad:
                                if (Templates != null)
                                    Templates.Clear();

                                Templates = MasterModule.Handler.RepositoryV2.Get<Template1Dto>()
                                                .Where(m => m.Status == 1
                                                        && m.Entity.Equals(Entity)
                                                        && m.Type.Equals(WizardType.Import)).ToList();
                                Templates.Insert(0, new Template1Dto
                                {
                                    Description = string.Format(MasterModule.Handler.Resources.GetString("Select_Item"), "template")
                                });

                                ExistOutlets = MasterModule.Handler.RepositoryV2.Get<OutletDto>()
                                                .Where(m => m.Status == 1).ToList();

                                e.Cancel = false;
                                e.Result = idx;
                                break;
                            case ImportSequence.DataSaving:
                                try
                                {
                                    TResult = MasterModule.Handler.RepositoryV2.Insert<OutletDto>(Data);
                                    e.Cancel = false;
                                    e.Result = idx;
                                }
                                catch (Exception ex)
                                {
                                    e.Cancel = true;
                                    e.Result = ex.Message;
                                }
                                break;
                            case ImportSequence.TemplateSaving:
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
                    ImportSequence idx = ImportSequence.IDLE;

                    try
                    {
                        idx = (ImportSequence)e.Result;
                        if (idx != ImportSequence.IDLE)
                        {
                            switch (idx)
                            {
                                case ImportSequence.FormLoad:
                                    btnBrowse.Enabled = true;
                                    tspProgress.Visible = false;
                                    tsxStatus.Text = MasterModule.Handler.Resources.GetString("Ready");
                                    break;
                                case ImportSequence.FileLoad:
                                    cmbSheet.DataSource = new BindingSource(Processor.GetSheets(), null);
                                    cmbSheet.DisplayMember = "Value";
                                    cmbSheet.ValueMember = "Key";
                                    cmbSheet.SelectedIndex = 0;
                                    break;
                                case ImportSequence.SheetLoad:
                                    ReadHeaderFile();

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
                                case ImportSequence.TemplateLoad:
                                    ReadTemplate();
                                    break;
                                case ImportSequence.DataLoad:
                                    if (MappingValid())
                                    {
                                        if (MappingValue())
                                        {
                                            //dgvData.DataSource = null;
                                            dgvData.DataSource = dgvTaxes.DataSource = dgvGroup.DataSource =
                                                dgvAdministration.DataSource = dgvTransaction.DataSource = Part1s;
                                            dgvContacts.DataSource = Contacts;
                                            dgvAccounts.DataSource = Accounts;
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
                                case ImportSequence.DataSaving:
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
                                                    bgwWorker.RunWorkerAsync(ImportSequence.TemplateSaving);
                                            }
                                            else
                                                this.Close();
                                        }
                                        else
                                            this.Close();
                                    }
                                    break;
                                case ImportSequence.TemplateSaving:
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

            bool valid = true;

            if (cmbAdd1Field.SelectedIndex == 0)
            {
                if (cmbNameField.SelectedIndex == 0)
                {
                    if (cmbCodeField.SelectedIndex == 0)
                    {
                        MessageBox.Show(null,
                            string.Format(MasterModule.Handler.Resources.GetString("Fields_Required"),
                                string.Format("- {0}\n -{1}\n -{2}", "Outlet Code", "Outlet Name", "Outlet Address")),
                            MasterModule.Name,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        cmbCodeField.Focus();
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(null,
                            string.Format(MasterModule.Handler.Resources.GetString("Fields_Required"),
                                string.Format("- {0}\n -{1}", "Outlet Name", "Outlet Address")),
                            MasterModule.Name,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        cmbAdd1Field.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(null,
                            string.Format(MasterModule.Handler.Resources.GetString("Field_Required"), "Outlet Address"),
                            MasterModule.Name,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    cmbAdd1Field.Focus();
                    return false;
                }
            }
            else valid = true;

            #region References Tab

            if (chkSubdepoColumn.Checked)
            {
                if (cmbSubdCodeField.SelectedIndex == 0)
                {
                    tbcField.SelectedIndex = 0;
                    MessageBox.Show(null,
                                string.Format(MasterModule.Handler.Resources.GetString("Field_Required"), "Subdepo Outlet"),
                                MasterModule.Name,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                    cmbSubdCodeField.Focus();
                    return false;
                }
                else valid = true;
            }
            else
            {
                if (rdoDistributor.Checked)
                {
                    if (txtSubdepoCode.Tag == null)
                    {
                        tbcField.SelectedIndex = 0;
                        MessageBox.Show(null,
                                    string.Format(MasterModule.Handler.Resources.GetString("Field_Required"), "Subdepo Outlet"),
                                    MasterModule.Name,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        txtSubdepoCode.Focus();
                        return false;
                    }
                    else valid = true;
                }
                else valid = true;
            }

            if (chkSupplierColumn.Checked)
            {
                if (cmbSuppCodeField.SelectedIndex == 0)
                {
                    tbcField.SelectedIndex = 0;
                    MessageBox.Show(null,
                                string.Format(MasterModule.Handler.Resources.GetString("Field_Required"), "Supplier Outlet"),
                                MasterModule.Name,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                    cmbSuppCodeField.Focus();
                    return false;
                }
                else valid = true;
            }
            else
            {
                if (rdoSupplier.Checked)
                {
                    if (txtSupplierCode.Tag == null)
                    {
                        tbcField.SelectedIndex = 0;
                        MessageBox.Show(null,
                                    string.Format(MasterModule.Handler.Resources.GetString("Field_Required"), "Supplier Outlet"),
                                    MasterModule.Name,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        txtSupplierCode.Focus();
                        return false;
                    }
                    else valid = true;
                }
                else valid = true;
            }
            #endregion

            #region Tax Tab
            //if (!cmbTaxCodeField.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //{
            //    if (cmbTaxNameField.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //    {
            //        tbcField.SelectedIndex = 1;
            //        cmbTaxNameField.Focus();
            //        return false;
            //    }
            //    else valid = true;

            //    if (cmbTaxAdd1Field.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //    {
            //        tbcField.SelectedIndex = 2;
            //        cmbTaxAdd1Field.Focus();
            //        return false;
            //    }
            //    else valid = true;
            //}
            //else valid = true;
            #endregion

            #region Contact Tab

            #region Row 1

            //if (cmbCNameField0.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //{
            //    if (cmbCPhone1Field0.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //    {
            //        if (cmbCPhone2Field0.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        {
            //            if (cmbCEmailField0.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //                valid = true;
            //            else
            //            {
            //                tbcField.SelectedIndex = 5;
            //                cmbCNameField0.Focus();
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            tbcField.SelectedIndex = 5;
            //            cmbCNameField0.Focus();
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCNameField0.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (!cmbCPhone1Field0.SelectedValue.Equals(Properties.Resources.Label_Select_Item) ||
            //        !cmbCPhone2Field0.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        valid = true;
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCPhone1Field0.Focus();
            //        return false;
            //    }
            //}
            #endregion

            #region Row 2
            //if (cmbCNameField1.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //{
            //    if (cmbCPhone1Field1.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //    {
            //        if (cmbCPhone2Field1.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        {
            //            if (cmbCEmailField1.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //                valid = true;
            //            else
            //            {
            //                tbcField.SelectedIndex = 5;
            //                cmbCNameField1.Focus();
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            tbcField.SelectedIndex = 5;
            //            cmbCNameField1.Focus();
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCNameField1.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (!cmbCPhone1Field1.SelectedValue.Equals(Properties.Resources.Label_Select_Item) ||
            //        !cmbCPhone2Field1.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        valid = true;
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCPhone1Field1.Focus();
            //        return false;
            //    }
            //}
            #endregion

            #region Row 3
            //if (cmbCNameField2.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //{
            //    if (cmbCPhone1Field2.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //    {
            //        if (cmbCPhone2Field2.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        {
            //            if (cmbCEmailField2.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //                valid = true;
            //            else
            //            {
            //                tbcField.SelectedIndex = 5;
            //                cmbCNameField2.Focus();
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            tbcField.SelectedIndex = 5;
            //            cmbCNameField2.Focus();
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCNameField2.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (!cmbCPhone1Field2.SelectedValue.Equals(Properties.Resources.Label_Select_Item) ||
            //        !cmbCPhone2Field2.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        valid = true;
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCPhone1Field2.Focus();
            //        return false;
            //    }
            //}
            #endregion

            #region Row 4
            //if (cmbCNameField3.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //{
            //    if (cmbCPhone1Field3.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //    {
            //        if (cmbCPhone2Field3.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        {
            //            if (cmbCEmailField3.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //                valid = true;
            //            else
            //            {
            //                tbcField.SelectedIndex = 5;
            //                cmbCNameField3.Focus();
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            tbcField.SelectedIndex = 5;
            //            cmbCNameField3.Focus();
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCNameField3.Focus();
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (!cmbCPhone1Field3.SelectedValue.Equals(Properties.Resources.Label_Select_Item) ||
            //        !cmbCPhone2Field3.SelectedValue.Equals(Properties.Resources.Label_Select_Item))
            //        valid = true;
            //    else
            //    {
            //        tbcField.SelectedIndex = 5;
            //        cmbCPhone1Field3.Focus();
            //        return false;
            //    }
            //}
            #endregion

            #endregion

            return valid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool MappingValue()
        {
            var rows = Processor.GetData(cmbSheet.SelectedValue.ToString()).AsEnumerable();

            Data = new List<OutletDto>();
            Part1s = new List<OutletPart1Dto>();
            Contacts = new List<OutletContactDto>();
            Accounts = new List<OutletAccountDto>();
            string errMsg = string.Empty;
            try
            {
                int count = ExistOutlets.Count();
                OutletDto mm = null;
                OutletPart1Dto m1 = null;
                OutletContactDto oc = null;
                OutletAccountDto oa = null;
                int ii = 0;
                foreach (var row in rows)
                {
                    mm = new OutletDto();
                    m1 = new OutletPart1Dto();

                    #region Master

                    if (chkCode.Checked)
                    {
                        count++;
                        mm.Code = m1.MasterCode = string.Format("{0:0000000}", count);
                    }
                    if (cmbCodeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCodeField.SelectedValue.ToString()) != null)
                            m1.Code = row.Field<object>(cmbCodeField.SelectedValue.ToString()).ToString();
                        else
                        {
                            m1.Code = m1.MasterCode;
                            errMsg += "Error Code Outlet on line " + (ii + 1) + "\n";
                        }
                    }
                    if (cmbNameField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbNameField.SelectedValue.ToString()) != null)
                            mm.Name = m1.Name = row.Field<object>(cmbNameField.SelectedValue.ToString()).ToString();
                        else
                        {
                            mm.Name = m1.Name = mm.Code;
                            errMsg += "Error Name Subdepo on line " + (ii + 1) + "\n";
                        }
                    }
                    if (cmbAdd1Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbAdd1Field.SelectedValue.ToString()) != null)
                            mm.Address1 = m1.Address = row.Field<object>(cmbAdd1Field.SelectedValue.ToString()).ToString();
                        else
                        {
                            mm.Address1 = mm.Code;
                            errMsg += "Error Address Subdepo on line " + (ii + 1) + "\n";
                        }
                    }
                    if (cmbAdd2Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbAdd2Field.SelectedValue.ToString()) != null)
                        {
                            mm.Address1 += "\\n" + row.Field<object>(cmbAdd2Field.SelectedValue.ToString()).ToString();
                            m1.Address += "\\n" + row.Field<object>(cmbAdd2Field.SelectedValue.ToString()).ToString();
                        }
                        else
                        {
                            mm.Address1 += string.Empty;
                            m1.Address += string.Empty;
                        }
                    }
                    if (cmbCityField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCityField.SelectedValue.ToString()) != null)
                            mm.City = m1.City = row.Field<object>(cmbCityField.SelectedValue.ToString()).ToString();
                        else
                            mm.City = m1.City = string.Empty;
                    }
                    if (cmbZipCodeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbZipCodeField.SelectedValue.ToString()) != null)
                            mm.ZipCode = m1.ZipCode = row.Field<object>(cmbZipCodeField.SelectedValue.ToString()).ToString();
                        else
                            mm.ZipCode = m1.ZipCode = string.Empty;
                    }
                    if (cmbPhone1Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbPhone1Field.SelectedValue.ToString()) != null)
                            mm.Phone1 = m1.Phone1 = row.Field<object>(cmbPhone1Field.SelectedValue.ToString()).ToString();
                        else
                            mm.Phone1 = m1.Phone1 = string.Empty;
                    }
                    if (cmbFax1Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbFax1Field.SelectedValue.ToString()) != null)
                            mm.Fax1 = m1.Fax1 = row.Field<object>(cmbFax1Field.SelectedValue.ToString()).ToString();
                        else
                            mm.Fax1 = m1.Fax1 = string.Empty;
                    }
                    if (cmbEmailField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbEmailField.SelectedValue.ToString()) != null)
                            mm.Email = m1.Email = row.Field<object>(cmbEmailField.SelectedValue.ToString()).ToString();
                        else
                            mm.Email = m1.Email = string.Empty;
                    }
                    if (cmbJoinDateField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbJoinDateField.SelectedValue.ToString()) != null)
                            mm.JoinDate = m1.JoinDate = row.Field<object>(cmbJoinDateField.SelectedValue.ToString()).ToString();
                        else
                            mm.JoinDate = m1.JoinDate = string.Empty;
                    }

                    #endregion

                    #region Reference
                    if (rdoDistributor.Checked)
                    {
                        if (chkSubdepoColumn.Checked) { }
                        else
                        {
                            if (txtSubdepoCode.Tag != null)
                            {
                                m1.Subdepo = txtSubdepoCode.Tag as SubdepoDto;
                                m1.SubdepoCode = m1.Subdepo.Code;
                            }
                        }
                    }
                    
                    
                    if (rdoSupplier.Checked)
                    {
                        if (chkSupplierColumn.Checked) { }
                        else
                        {
                            if (txtSupplierCode.Tag != null)
                            {
                                m1.Supplier = txtSupplierCode.Tag as SupplierDto;
                                m1.SupplierCode = m1.Supplier.Code;
                            }
                        }
                    }
                    #endregion

                    #region Tax
                    if (cmbTaxCodeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTaxCodeField.SelectedValue.ToString()) != null)
                            mm.TaxCode = row.Field<object>(cmbTaxCodeField.SelectedValue.ToString()).ToString();
                        else
                            mm.TaxCode = string.Empty;
                    }
                    if (cmbTaxNameField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTaxNameField.SelectedValue.ToString()) != null)
                            mm.TaxName = row.Field<object>(cmbTaxNameField.SelectedValue.ToString()).ToString();
                        else
                            mm.TaxName = string.Empty;
                    }
                    if (cmbTaxAdd1Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTaxAdd1Field.SelectedValue.ToString()) != null)
                            mm.TaxAddress1 = row.Field<object>(cmbTaxAdd1Field.SelectedValue.ToString()).ToString();
                        else
                            mm.TaxAddress1 = string.Empty;
                    }
                    if (cmbTaxAdd2Field.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTaxAdd2Field.SelectedValue.ToString()) != null)
                            mm.TaxAddress1 += " \n" + row.Field<object>(cmbTaxAdd2Field.SelectedValue.ToString()).ToString();
                        else
                            mm.TaxAddress1 = string.Empty;
                    }
                    if (cmbTaxCityField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTaxCityField.SelectedValue.ToString()) != null)
                            mm.TaxCity = row.Field<object>(cmbTaxCityField.SelectedValue.ToString()).ToString();
                        else
                            mm.TaxCity = string.Empty;
                    }
                    if (cmbTaxZipCodeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTaxZipCodeField.SelectedValue.ToString()) != null)
                            mm.TaxZip = row.Field<object>(cmbTaxZipCodeField.SelectedValue.ToString()).ToString();
                        else
                            mm.TaxZip = string.Empty;
                    }
                    if (cmbTaxRegDateField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTaxRegDateField.SelectedValue.ToString()) != null)
                            mm.TaxRegDate = row.Field<object>(cmbTaxRegDateField.SelectedValue.ToString()).ToString();
                        else
                            mm.TaxRegDate = string.Empty;
                    }
                    #endregion

                    #region Outlet Group

                    if (cmbOutTypeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbOutTypeField.SelectedValue.ToString()) != null)
                            m1.OutTypeCode = m1.OutTypeName = row.Field<object>(cmbOutTypeField.SelectedValue.ToString()).ToString();
                        else
                            m1.OutTypeCode = m1.OutTypeName = string.Empty;
                    }

                    if (cmbOutGroupField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbOutGroupField.SelectedValue.ToString()) != null)
                            m1.OutGroupCode = m1.OutGroupName = row.Field<object>(cmbOutGroupField.SelectedValue.ToString()).ToString();
                        else
                            m1.OutGroupCode = m1.OutGroupName = string.Empty;
                    }

                    if (cmbPriceGroupField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbPriceGroupField.SelectedValue.ToString()) != null)
                            m1.PriceGroupCode = m1.PriceGroupName  = row.Field<object>(cmbPriceGroupField.SelectedValue.ToString()).ToString();
                        else
                            m1.PriceGroupCode = m1.PriceGroupName = string.Empty;
                    }

                    if (cmbDiscGroupField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbDiscGroupField.SelectedValue.ToString()) != null)
                            m1.DiscGroupCode = m1.DiscGroupName = row.Field<object>(cmbDiscGroupField.SelectedValue.ToString()).ToString();
                        else
                            m1.DiscGroupCode = m1.DiscGroupName = string.Empty;
                    }

                    if (cmbPLUGroupField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbPLUGroupField.SelectedValue.ToString()) != null)
                            m1.PLUGroupCode = m1.PLUGroupName = row.Field<object>(cmbPLUGroupField.SelectedValue.ToString()).ToString();
                        else
                            m1.PLUGroupCode = m1.PLUGroupName = string.Empty;
                    }

                    if (cmbConverGroupField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbConverGroupField.SelectedValue.ToString()) != null)
                            m1.ConvertGroupCode = m1.ConvertGroupName = row.Field<object>(cmbConverGroupField.SelectedValue.ToString()).ToString();
                        else
                            m1.ConvertGroupCode = m1.ConvertGroupName = string.Empty;
                    }
                    #endregion

                    #region Administration

                    if (cmbLocationField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbLocationField.SelectedValue.ToString()) != null)
                            m1.LocationCode = m1.LocationName = row.Field<object>(cmbLocationField.SelectedValue.ToString()).ToString();
                        else m1.LocationCode = m1.LocationName = string.Empty;
                    }
                    if (cmbDistrictField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbDistrictField.SelectedValue.ToString()) != null)
                            m1.DistrictCode = m1.DistrictName = row.Field<object>(cmbDistrictField.SelectedValue.ToString()).ToString();
                        else m1.DistrictCode = m1.DistrictName = string.Empty;
                    }
                    if (cmbBeatField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbBeatField.SelectedValue.ToString()) != null)
                            m1.BeatCode = m1.BeatName = row.Field<object>(cmbBeatField.SelectedValue.ToString()).ToString();
                        else m1.BeatCode = m1.BeatName = string.Empty;
                    }
                    if (cmbSubbeatField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbSubbeatField.SelectedValue.ToString()) != null)
                            m1.SubBeatCode = m1.SubBeatName = row.Field<object>(cmbSubbeatField.SelectedValue.ToString()).ToString();
                        else m1.SubBeatCode = m1.SubBeatName = string.Empty;
                    }
                    if (cmbClasificationField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbClasificationField.SelectedValue.ToString()) != null)
                            m1.ClasificationCode = m1.ClasificationName = row.Field<object>(cmbClasificationField.SelectedValue.ToString()).ToString();
                        else m1.ClasificationCode = m1.ClasificationName = string.Empty;
                    }
                    if (cmbMarketField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbMarketField.SelectedValue.ToString()) != null)
                            m1.MarketCode = m1.MarketName = row.Field<object>(cmbMarketField.SelectedValue.ToString()).ToString();
                        else m1.MarketCode = m1.MarketName = string.Empty;
                    }
                    if (cmbIndustryField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbIndustryField.SelectedValue.ToString()) != null)
                            m1.IndustryCode = m1.IndustryName = row.Field<object>(cmbIndustryField.SelectedValue.ToString()).ToString();
                        else m1.IndustryCode = m1.IndustryName = string.Empty;
                    }
                    #endregion

                    #region Transaction

                    if (cmbContrabillField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbContrabillField.SelectedValue.ToString()) != null)
                        {
                            int a = 0;
                            if (int.TryParse(row.Field<object>(cmbContrabillField.SelectedValue.ToString()).ToString(),
                                out a))
                                m1.ContraBill = a;
                            else
                                m1.ContraBill = 0;
                        }
                        else m1.ContraBill = 0;
                    }
                    if (cmbPayTypeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbPayTypeField.SelectedValue.ToString()) != null)
                            m1.PayTypeCode = m1.PayTypeName = row.Field<object>(cmbPayTypeField.SelectedValue.ToString()).ToString();
                        else m1.PayTypeCode = m1.PayTypeName = string.Empty;
                    }
                    if (cmbTOPField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbTOPField.SelectedValue.ToString()) != null)
                            m1.Top = row.Field<object>(cmbTOPField.SelectedValue.ToString()).ToString();
                        else m1.Top = string.Empty;
                    }
                    if (cmbCLFlagField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCLFlagField.SelectedValue.ToString()) != null)
                        {
                            int a = 0;
                            if (int.TryParse(row.Field<object>(cmbCLFlagField.SelectedValue.ToString()).ToString(),
                                out a))
                                m1.IsCreditLimit = a;
                            else
                                m1.IsCreditLimit = 0;
                        }
                        else m1.IsCreditLimit = 0;
                    }
                    else m1.IsCreditLimit = 0;
                    if (cmbCLValueField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCLValueField.SelectedValue.ToString()) != null)
                            m1.CreditLimit = decimal.Parse(row.Field<object>(cmbCLValueField.SelectedValue.ToString()).ToString());
                        else m1.CreditLimit = 0;
                    }
                    if (cmbCLTypeField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCLTypeField.SelectedValue.ToString()) != null)
                            m1.CreditLimitTypeCode = m1.CreditLimitTypeName = row.Field<object>(cmbCLTypeField.SelectedValue.ToString()).ToString();
                        else m1.CreditLimitTypeCode = m1.CreditLimitTypeName = string.Empty;
                    }
                    if (cmbFTrxDateField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbFTrxDateField.SelectedValue.ToString()) != null)
                            m1.FirstSalesDate = row.Field<object>(cmbFTrxDateField.SelectedValue.ToString()).ToString();
                        else m1.FirstSalesDate = string.Empty;
                    }
                    if (cmbLTrxDateField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbLTrxDateField.SelectedValue.ToString()) != null)
                            m1.LastSalesDate = row.Field<object>(cmbLTrxDateField.SelectedValue.ToString()).ToString();
                        else m1.LastSalesDate = string.Empty;
                    }
                    if (cmbWeekField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbWeekField.SelectedValue.ToString()) != null)
                            m1.Week = row.Field<object>(cmbWeekField.SelectedValue.ToString()).ToString();
                        else m1.Week = string.Empty;
                    }
                    if (cmbMarketShareField.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbMarketShareField.SelectedValue.ToString()) != null)
                            m1.MarketShare = decimal.Parse(row.Field<object>(cmbMarketShareField.SelectedValue.ToString()).ToString());
                        else m1.MarketShare = 0;
                    }

                    #endregion

                    #region Outlet Contacts
                    #region Contact Row 1

                    if (cmbCNameField0.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCNameField0.SelectedValue.ToString()) != null)
                        {
                            oc = new OutletContactDto();
                            oc.MasterCode = mm.Code;

                            oc.Contact = row.Field<object>(cmbCNameField0.SelectedValue.ToString()).ToString();

                            if (cmbCPhone1Field0.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone1Field0.SelectedValue.ToString()) != null)
                                    oc.Phone1 = row.Field<object>(cmbCPhone1Field0.SelectedValue.ToString()).ToString();
                                else oc.Phone1 = string.Empty;
                            }
                            else oc.Phone1 = string.Empty;

                            if (cmbCPhone2Field0.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone2Field0.SelectedValue.ToString()) != null)
                                    oc.Phone2 = row.Field<object>(cmbCPhone2Field0.SelectedValue.ToString()).ToString();
                                else oc.Phone2 = string.Empty;
                            }
                            else oc.Phone2 = string.Empty;

                            if (cmbCEmailField0.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCEmailField0.SelectedValue.ToString()) != null)
                                    oc.Email = row.Field<object>(cmbCEmailField0.SelectedValue.ToString()).ToString();
                                else oc.Email = string.Empty;
                            }
                            else oc.Email = string.Empty;

                            mm.Contacts.Add(oc);
                            Contacts.Add(oc);
                        }
                    }

                    #endregion

                    #region Contact Row 2

                    if (cmbCNameField1.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCNameField1.SelectedValue.ToString()) != null)
                        {
                            oc = new OutletContactDto();
                            oc.MasterCode = mm.Code;

                            oc.Contact = row.Field<object>(cmbCNameField1.SelectedValue.ToString()).ToString();

                            if (cmbCPhone1Field1.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone1Field1.SelectedValue.ToString()) != null)
                                    oc.Phone1 = row.Field<object>(cmbCPhone1Field1.SelectedValue.ToString()).ToString();
                                else oc.Phone1 = string.Empty;
                            }
                            else oc.Phone1 = string.Empty;

                            if (cmbCPhone2Field1.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone2Field1.SelectedValue.ToString()) != null)
                                    oc.Phone2 = row.Field<object>(cmbCPhone2Field1.SelectedValue.ToString()).ToString();
                                else oc.Phone2 = string.Empty;
                            }
                            else oc.Phone2 = string.Empty;

                            if (cmbCEmailField1.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCEmailField1.SelectedValue.ToString()) != null)
                                    oc.Email = row.Field<object>(cmbCEmailField1.SelectedValue.ToString()).ToString();
                                else oc.Email = string.Empty;
                            }
                            else oc.Email = string.Empty;

                            mm.Contacts.Add(oc);
                            Contacts.Add(oc);
                        }
                    }

                    #endregion

                    #region Contact Row 3

                    if (cmbCNameField2.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCNameField2.SelectedValue.ToString()) != null)
                        {
                            oc = new OutletContactDto();
                            oc.MasterCode = mm.Code;

                            oc.Contact = row.Field<object>(cmbCNameField2.SelectedValue.ToString()).ToString();

                            if (cmbCPhone1Field2.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone1Field2.SelectedValue.ToString()) != null)
                                    oc.Phone1 = row.Field<object>(cmbCPhone1Field2.SelectedValue.ToString()).ToString();
                                else oc.Phone1 = string.Empty;
                            }
                            else oc.Phone1 = string.Empty;

                            if (cmbCPhone2Field2.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone2Field2.SelectedValue.ToString()) != null)
                                    oc.Phone2 = row.Field<object>(cmbCPhone2Field2.SelectedValue.ToString()).ToString();
                                else oc.Phone2 = string.Empty;
                            }
                            else oc.Phone2 = string.Empty;

                            if (cmbCEmailField2.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCEmailField2.SelectedValue.ToString()) != null)
                                    oc.Email = row.Field<object>(cmbCEmailField2.SelectedValue.ToString()).ToString();
                                else oc.Email = string.Empty;
                            }
                            else oc.Email = string.Empty;

                            mm.Contacts.Add(oc);
                            Contacts.Add(oc);
                        }
                    }

                    #endregion

                    #region Contact Row 4

                    if (cmbCNameField3.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbCNameField3.SelectedValue.ToString()) != null)
                        {
                            oc = new OutletContactDto();
                            oc.MasterCode = mm.Code;

                            oc.Contact = row.Field<object>(cmbCNameField3.SelectedValue.ToString()).ToString();

                            if (cmbCPhone1Field3.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone1Field3.SelectedValue.ToString()) != null)
                                    oc.Phone1 = row.Field<object>(cmbCPhone1Field3.SelectedValue.ToString()).ToString();
                                else oc.Phone1 = string.Empty;
                            }
                            else oc.Phone1 = string.Empty;

                            if (cmbCPhone2Field3.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCPhone2Field3.SelectedValue.ToString()) != null)
                                    oc.Phone2 = row.Field<object>(cmbCPhone2Field3.SelectedValue.ToString()).ToString();
                                else oc.Phone2 = string.Empty;
                            }
                            else oc.Phone2 = string.Empty;

                            if (cmbCEmailField3.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbCEmailField3.SelectedValue.ToString()) != null)
                                    oc.Email = row.Field<object>(cmbCEmailField3.SelectedValue.ToString()).ToString();
                                else oc.Email = string.Empty;
                            }
                            else oc.Email = string.Empty;

                            mm.Contacts.Add(oc);
                            Contacts.Add(oc);
                        }
                    }

                    #endregion

                    #endregion

                    #region Outlet Accounts

                    #region Account Row 1

                    if (cmbBCodeField0.SelectedIndex != 0 && cmbAccNoField0.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbBCodeField0.SelectedValue.ToString()) != null
                                && row.Field<object>(cmbBCodeField0.SelectedValue.ToString()) != null)
                        {
                            oa = new OutletAccountDto();
                            oa.MasterCode = mm.Code;

                            oa.BankCode = row.Field<object>(cmbBCodeField0.SelectedValue.ToString()).ToString();
                            oa.Code = row.Field<object>(cmbBCodeField0.SelectedValue.ToString()).ToString();

                            if (cmbBNameField0.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbBNameField0.SelectedValue.ToString()) != null)
                                    oa.BankName = row.Field<object>(cmbBNameField0.SelectedValue.ToString()).ToString();
                                else oa.BankName = string.Empty;
                            }
                            else oa.BankName = string.Empty;

                            //if ((bm = mBan.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault()) == null)
                            //{
                            //    if (Banks.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault() == null)
                            //        Banks.Add(new BankDto()
                            //        {
                            //            Code = oa.BankCode,
                            //            Name = oa.BankName
                            //        });
                            //}
                            //else
                            //{
                            //    oa.BankCode = bm.Code;
                            //    oa.BankName = bm.Name;
                            //}

                            mm.Accounts.Add(oa);
                            Accounts.Add(oa);
                        }
                    }

                    #endregion

                    #region Account Row 2

                    if (cmbBCodeField1.SelectedIndex != 0 && cmbAccNoField1.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbBCodeField1.SelectedValue.ToString()) != null
                                && row.Field<object>(cmbBCodeField1.SelectedValue.ToString()) != null)
                        {
                            oa = new OutletAccountDto();
                            oa.MasterCode = mm.Code;

                            oa.BankCode = row.Field<object>(cmbBCodeField1.SelectedValue.ToString()).ToString();
                            oa.Code = row.Field<object>(cmbBCodeField1.SelectedValue.ToString()).ToString();

                            if (cmbBNameField1.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbBNameField1.SelectedValue.ToString()) != null)
                                    oa.BankName = row.Field<object>(cmbBNameField1.SelectedValue.ToString()).ToString();
                                else oa.BankName = string.Empty;
                            }
                            else oa.BankName = string.Empty;

                            //if ((bm = mBan.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault()) == null)
                            //{
                            //    if (Banks.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault() == null)
                            //        Banks.Add(new BankDto()
                            //        {
                            //            Code = oa.BankCode,
                            //            Name = oa.BankName
                            //        });
                            //}
                            //else
                            //{
                            //    oa.BankCode = bm.Code;
                            //    oa.BankName = bm.Name;
                            //}

                            mm.Accounts.Add(oa);
                            Accounts.Add(oa);
                        }
                    }
                    #endregion

                    #region Account Row 3

                    if (cmbBCodeField2.SelectedIndex != 0 && cmbAccNoField2.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbBCodeField2.SelectedValue.ToString()) != null
                                && row.Field<object>(cmbBCodeField2.SelectedValue.ToString()) != null)
                        {
                            oa = new OutletAccountDto();
                            oa.MasterCode = mm.Code;

                            oa.BankCode = row.Field<object>(cmbBCodeField2.SelectedValue.ToString()).ToString();
                            oa.Code = row.Field<object>(cmbBCodeField2.SelectedValue.ToString()).ToString();

                            if (cmbBNameField2.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbBNameField2.SelectedValue.ToString()) != null)
                                    oa.BankName = row.Field<object>(cmbBNameField2.SelectedValue.ToString()).ToString();
                                else oa.BankName = string.Empty;
                            }
                            else oa.BankName = string.Empty;

                            //if ((bm = mBan.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault()) == null)
                            //{
                            //    if (Banks.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault() == null)
                            //        Banks.Add(new BankDto()
                            //        {
                            //            Code = oa.BankCode,
                            //            Name = oa.BankName
                            //        });
                            //}
                            //else
                            //{
                            //    oa.BankCode = bm.Code;
                            //    oa.BankName = bm.Name;
                            //}

                            mm.Accounts.Add(oa);
                            Accounts.Add(oa);
                        }
                    }

                    #endregion

                    #region Account Row 4

                    if (cmbBCodeField3.SelectedIndex != 0 && cmbAccNoField3.SelectedIndex != 0)
                    {
                        if (row.Field<object>(cmbBCodeField3.SelectedValue.ToString()) != null
                                && row.Field<object>(cmbBCodeField3.SelectedValue.ToString()) != null)
                        {
                            oa = new OutletAccountDto();
                            oa.MasterCode = mm.Code;

                            oa.BankCode = row.Field<object>(cmbBCodeField3.SelectedValue.ToString()).ToString();
                            oa.Code = row.Field<object>(cmbBCodeField3.SelectedValue.ToString()).ToString();

                            if (cmbBNameField3.SelectedIndex != 0)
                            {
                                if (row.Field<object>(cmbBNameField3.SelectedValue.ToString()) != null)
                                    oa.BankName = row.Field<object>(cmbBNameField3.SelectedValue.ToString()).ToString();
                                else oa.BankName = string.Empty;
                            }
                            else oa.BankName = string.Empty;

                            //if ((bm = mBan.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault()) == null)
                            //{
                            //    if (Banks.Where(m => m.Code.Equals(oa.BankCode))
                            //        .Select(m => m).FirstOrDefault() == null)
                            //        Banks.Add(new BankDto()
                            //        {
                            //            Code = oa.BankCode,
                            //            Name = oa.BankName
                            //        });
                            //}
                            //else
                            //{
                            //    oa.BankCode = bm.Code;
                            //    oa.BankName = bm.Name;
                            //}

                            mm.Accounts.Add(oa);
                            Accounts.Add(oa);
                        }
                    }

                    #endregion

                    #endregion

                    mm.Part1s.Add(m1);
                    Part1s.Add(m1);
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
                //if (Templates.Count == 1)
                //    code = string.Format("IM{0}{1:000}", Entity, 1);
                //else
                //    code = string.Format("IM{0}{1:000}", Entity, Templates.Count);

                //Template = new Template1Dto()
                //{
                //    Code = code,
                //    Description = string.Format("Template Import Subdepo {0}", Templates.Count),
                //    Type = GlobalVariables.Import,
                //    Entity = Entity
                //};
                //if (FieldsTemplate != null)
                //    FieldsTemplate.Clear();
                //else FieldsTemplate = new List<Template2Dto>();
                //if (cmbNameField.SelectedIndex != 0)
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 1,
                //        Source = cmbNameField.SelectedValue.ToString(),
                //        Destination = "SDSDNM"
                //    });
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 1,
                //        Source = string.Empty,
                //        Destination = "SDSDNM"
                //    });

                //if (cmbPhone1Field.SelectedIndex != 0)
                //{
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 2,
                //        Source = cmbOldCodeField.SelectedValue.ToString(),
                //        Destination = "SDSDON"
                //    });
                //}
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 2,
                //        Source = string.Empty,
                //        Destination = "SDSDON"
                //    });

                //if (cmbAdd1Field.SelectedIndex != 0)
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 3,
                //        Source = cmbAdd1Field.SelectedValue.ToString(),
                //        Destination = "SDADD1"
                //    });
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 3,
                //        Source = string.Empty,
                //        Destination = "SDADD1"
                //    });

                //if (cmbAdd2Field.SelectedIndex != 0)
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 4,
                //        Source = cmbAdd2Field.SelectedValue.ToString(),
                //        Destination = "SDADD2"
                //    });
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 4,
                //        Source = string.Empty,
                //        Destination = "SDADD2"
                //    });

                //if (cmbCityField.SelectedIndex != 0)
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 5,
                //        Source = cmbCityField.SelectedValue.ToString(),
                //        Destination = "SDCITY"
                //    });
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 5,
                //        Source = string.Empty,
                //        Destination = "SDCITY"
                //    });

                //if (cmbZipCodeField.SelectedIndex != 0)
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 6,
                //        Source = cmbZipCodeField.SelectedValue.ToString(),
                //        Destination = "SDZPCD"
                //    });
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 6,
                //        Source = string.Empty,
                //        Destination = "SDZPCD"
                //    });

                //if (cmbPhone1Field.SelectedIndex != 0)
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 7,
                //        Source = cmbPhone1Field.SelectedValue.ToString(),
                //        Destination = "SDPHN1"
                //    });
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 7,
                //        Source = string.Empty,
                //        Destination = "SDPHN1"
                //    });

                //if (cmbFax1Field.SelectedIndex != 0)
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 8,
                //        Source = cmbFax1Field.SelectedValue.ToString(),
                //        Destination = "SDFAX1"
                //    });
                //else
                //    FieldsTemplate.Add(new Template2Dto()
                //    {
                //        Code = code,
                //        Sequence = 8,
                //        Source = string.Empty,
                //        Destination = "SDFAX1"
                //    });
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
                    var header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDSDNM"))
                                    .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbNameField.Text = header;
                    //    else
                    //        cmbNameField.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbNameField.SelectedIndex = 0;
                    //cmbNameField.Enabled = false;

                    //header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDSDON"))
                    //                .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbOldCodeField.Text = header;
                    //    else
                    //        cmbOldCodeField.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbOldCodeField.SelectedIndex = 0;
                    //cmbOldCodeField.Enabled = false;

                    //header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDADD1"))
                    //                .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbAdd1Field.Text = header;
                    //    else
                    //        cmbAdd1Field.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbAdd1Field.SelectedIndex = 0;
                    //cmbAdd1Field.Enabled = false;

                    //header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDADD2"))
                    //                .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbAdd2Field.Text = header;
                    //    else
                    //        cmbAdd2Field.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbAdd2Field.SelectedIndex = 0;
                    //cmbAdd2Field.Enabled = false;

                    //header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDCITY"))
                    //                .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbCityField.Text = header;
                    //    else
                    //        cmbCityField.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbCityField.SelectedIndex = 0;
                    //cmbCityField.Enabled = false;

                    //header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDZPCD"))
                    //                .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbZipCodeField.Text = header;
                    //    else
                    //        cmbZipCodeField.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbZipCodeField.SelectedIndex = 0;
                    //cmbZipCodeField.Enabled = false;

                    //header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDPHN1"))
                    //                .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbPhone1Field.Text = header;
                    //    else
                    //        cmbPhone1Field.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbPhone1Field.SelectedIndex = 0;
                    //cmbPhone1Field.Enabled = false;

                    //header = Template.FieldsTemplate.Where(m => m.Destination.Equals("SDFAX1"))
                    //                .Select(m => m.Source).FirstOrDefault();
                    //if (!string.IsNullOrWhiteSpace(header))
                    //{
                    //    if (HeaderFile.Contains(header))
                    //        cmbFax1Field.Text = header;
                    //    else
                    //        cmbFax1Field.SelectedIndex = 0;
                    //}
                    //else
                    //    cmbFax1Field.SelectedIndex = 0;
                    //cmbFax1Field.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadHeaderFile()
        {
            if (HeaderFile != null)
                HeaderFile.Clear();
            HeaderFile = Processor.GetHeaders(cmbSheet.SelectedValue.ToString());
            HeaderFile.Insert(0, string.Format(MasterModule.Handler.Resources.GetString("Select_Item"), string.Empty));

            cmbCodeField.DataSource = new List<string>(HeaderFile);
            cmbNameField.DataSource = new List<string>(HeaderFile);
            cmbAdd1Field.DataSource = new List<string>(HeaderFile);
            cmbAdd2Field.DataSource = new List<string>(HeaderFile);
            cmbCityField.DataSource = new List<string>(HeaderFile);
            cmbZipCodeField.DataSource = new List<string>(HeaderFile);
            cmbPhone1Field.DataSource = new List<string>(HeaderFile);
            cmbFax1Field.DataSource = new List<string>(HeaderFile);
            cmbEmailField.DataSource = new List<string>(HeaderFile);
            cmbJoinDateField.DataSource = new List<string>(HeaderFile);

            cmbSubdCodeField.DataSource = new List<string>(HeaderFile);
            cmbSubdNameField.DataSource = new List<string>(HeaderFile);
            cmbSuppCodeField.DataSource = new List<string>(HeaderFile);
            cmbSuppNameField.DataSource = new List<string>(HeaderFile);

            #region Tax Tab
            cmbTaxCodeField.DataSource = new List<string>(HeaderFile);
            cmbTaxNameField.DataSource = new List<string>(HeaderFile);
            cmbTaxAdd1Field.DataSource = new List<string>(HeaderFile);
            cmbTaxAdd2Field.DataSource = new List<string>(HeaderFile);
            cmbTaxCityField.DataSource = new List<string>(HeaderFile);
            cmbTaxZipCodeField.DataSource = new List<string>(HeaderFile);
            cmbTaxRegDateField.DataSource = new List<string>(HeaderFile);
            #endregion

            #region Territorial Tab
            cmbLocationField.DataSource = new List<string>(HeaderFile);
            cmbDistrictField.DataSource = new List<string>(HeaderFile);
            cmbBeatField.DataSource = new List<string>(HeaderFile);
            cmbSubbeatField.DataSource = new List<string>(HeaderFile);
            cmbClasificationField.DataSource = new List<string>(HeaderFile);
            cmbMarketField.DataSource = new List<string>(HeaderFile);
            cmbIndustryField.DataSource = new List<string>(HeaderFile);
            #endregion

            #region Group Tab
            cmbOutTypeField.DataSource = new List<string>(HeaderFile);
            cmbOutGroupField.DataSource = new List<string>(HeaderFile);
            cmbPriceGroupField.DataSource = new List<string>(HeaderFile);
            cmbDiscGroupField.DataSource = new List<string>(HeaderFile);
            cmbPLUGroupField.DataSource = new List<string>(HeaderFile);
            cmbConverGroupField.DataSource = new List<string>(HeaderFile);
            #endregion

            #region Transaction Tab
            cmbContrabillField.DataSource = new List<string>(HeaderFile);
            cmbPayTypeField.DataSource = new List<string>(HeaderFile);
            cmbTOPField.DataSource = new List<string>(HeaderFile);
            cmbCLFlagField.DataSource = new List<string>(HeaderFile);
            cmbCLTypeField.DataSource = new List<string>(HeaderFile);
            cmbCLValueField.DataSource = new List<string>(HeaderFile);
            cmbJoinDateField.DataSource = new List<string>(HeaderFile);
            cmbFTrxDateField.DataSource = new List<string>(HeaderFile);
            cmbLTrxDateField.DataSource = new List<string>(HeaderFile);
            cmbWeekField.DataSource = new List<string>(HeaderFile);
            cmbMarketShareField.DataSource = new List<string>(HeaderFile);
            #endregion

            #region Contact Tab
            cmbCNameField0.DataSource = new List<string>(HeaderFile);
            cmbCNameField1.DataSource = new List<string>(HeaderFile);
            cmbCNameField2.DataSource = new List<string>(HeaderFile);
            cmbCNameField3.DataSource = new List<string>(HeaderFile);

            cmbCPhone1Field0.DataSource = new List<string>(HeaderFile);
            cmbCPhone1Field1.DataSource = new List<string>(HeaderFile);
            cmbCPhone1Field2.DataSource = new List<string>(HeaderFile);
            cmbCPhone1Field3.DataSource = new List<string>(HeaderFile);

            cmbCPhone2Field0.DataSource = new List<string>(HeaderFile);
            cmbCPhone2Field1.DataSource = new List<string>(HeaderFile);
            cmbCPhone2Field2.DataSource = new List<string>(HeaderFile);
            cmbCPhone2Field3.DataSource = new List<string>(HeaderFile);

            cmbCEmailField0.DataSource = new List<string>(HeaderFile);
            cmbCEmailField1.DataSource = new List<string>(HeaderFile);
            cmbCEmailField2.DataSource = new List<string>(HeaderFile);
            cmbCEmailField3.DataSource = new List<string>(HeaderFile);
            #endregion

            #region Bank Tab
            cmbBCodeField0.DataSource = new List<string>(HeaderFile);
            cmbBCodeField1.DataSource = new List<string>(HeaderFile);
            cmbBCodeField2.DataSource = new List<string>(HeaderFile);
            cmbBCodeField3.DataSource = new List<string>(HeaderFile);

            cmbBNameField0.DataSource = new List<string>(HeaderFile);
            cmbBNameField1.DataSource = new List<string>(HeaderFile);
            cmbBNameField2.DataSource = new List<string>(HeaderFile);
            cmbBNameField3.DataSource = new List<string>(HeaderFile);

            cmbAccNoField0.DataSource = new List<string>(HeaderFile);
            cmbAccNoField1.DataSource = new List<string>(HeaderFile);
            cmbAccNoField2.DataSource = new List<string>(HeaderFile);
            cmbAccNoField3.DataSource = new List<string>(HeaderFile);
            #endregion
        }
        #endregion
    }
}
