using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Interfaces;
using InFresh.Framework.v1.Models.Masters;
using InFresh.Master.v1.Enums;
using InFresh.Master.v1.Implements;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Master.v1.Pages
{
    public partial class MP002_EmployeePage : DockContent, IDock
    {
        #region Constructor & Properties
        /// <summary>
        /// 
        /// </summary>
        public MP002_EmployeePage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private static int Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private static Flag Flag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected IList<EmployeeDto> Data { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public DockState State
        {
            get { return DockState.Document; }
        }

        #region UI Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Up:
                    if (tsbFirst.Enabled)
                        tsbFirst.PerformClick();
                    return true;
                case Keys.Control | Keys.Left:
                    if (tsbPrevious.Enabled)
                        tsbPrevious.PerformClick();
                    return true;
                case Keys.Control | Keys.Right:
                    if (tsbNext.Enabled)
                        tsbNext.PerformClick();
                    return true;
                case Keys.Control | Keys.Down:
                    if (tsbLast.Enabled)
                        tsbLast.PerformClick();
                    return true;
                case Keys.Control | Keys.N:
                    if (tsbNew.Enabled)
                        tsbNew.PerformClick();
                    return true;
                case Keys.Control | Keys.S:
                    if (tsbSave.Enabled)
                        tsbSave.PerformClick();
                    return true;
                case Keys.Escape:
                    if (Flag != Flag.IDLE)
                    {
                        if (tsbCancel.Enabled)
                            tsbCancel.PerformButtonClick();
                    }
                    return true;
                case Keys.F2:
                    if (tsbEdit.Enabled)
                        tsbEdit.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            tspProgress.Visible = true;
            tsxStatus.Text = MasterModule.Handler.Resources.GetString("Load_References");
            tsbList.Enabled = tsbNew.Enabled = tsbRefresh.Enabled =
                tsbEdit.Enabled = tsbSave.Enabled = tsbCancel.Enabled =
                tsbFirst.Enabled = tsbPrevious.Enabled = tsbNext.Enabled =
                tsbLast.Enabled = false;
            if (!bgwWorker.IsBusy)
                bgwWorker.RunWorkerAsync(Flag.FormLoading);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            MasterModule.Handler.Host.ReverseToolbar(tlsToolbar);
            MasterModule.Handler.Host.ReverseStatusbar(stsStatusbar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            MasterModule.Handler.Host.ReverseToolbar(tlsToolbar);
            MasterModule.Handler.Host.ReverseStatusbar(stsStatusbar);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Activated(object sender, EventArgs e)
        {
            if (DockState == DockState.Document)
            {
                MasterModule.Handler.Host.MergeToolbar(tlsToolbar);
                MasterModule.Handler.Host.MergeStatusbar(stsStatusbar);
                Controls.Remove(stsStatusbar);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Deactivate(object sender, EventArgs e)
        {
            if (DockState == DockState.Document)
            {
                MasterModule.Handler.Host.ReverseToolbar(tlsToolbar);
                MasterModule.Handler.Host.ReverseStatusbar(stsStatusbar);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_DockStateChanged(object sender, EventArgs e)
        {
            if (DockState == DockState.Float)
            {
                Size = new Size(960, 500);

                MasterModule.Handler.Host.ReverseToolbar(tlsToolbar);
                MasterModule.Handler.Host.ReverseStatusbar(stsStatusbar);

                Controls.Remove(tlsToolbar);
                Controls.Remove(stsStatusbar);

                Controls.Add(tlsToolbar);
                Controls.Add(stsStatusbar);

                var topLeft = DockPanel.Location;
                topLeft.X = ((Screen.PrimaryScreen.Bounds.Width / 2) - (Size.Width / 2));
                topLeft.Y = ((Screen.PrimaryScreen.Bounds.Height / 2) - (Size.Height / 2));
                Show(DockPanel, new Rectangle(topLeft, Size));

                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(Flag.DetailLoading);
            }
            else if (DockState == DockState.Document)
            {
                MasterModule.Handler.Host.MergeToolbar(tlsToolbar);
                MasterModule.Handler.Host.MergeStatusbar(stsStatusbar);
                Controls.Remove(stsStatusbar);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarItem_Click(object sender, EventArgs e)
        {
            #region List & Refresh
            //if (sender == tsbList)
            //{
            //    using (var form = new MS001_ListSubdepo(this))
            //    {
            //        if (form.ShowDialog() == DialogResult.OK)
            //        {
            //            Index = Data.IndexOf(form.Tag as SubdepoDto);

            //            if (!bgwWorker.IsBusy)
            //                bgwWorker.RunWorkerAsync(Flag.DetailLoading);
            //        }
            //    }
            //    return;
            //}

            if (sender == tsbRefresh)
            {
                tspProgress.Visible = true;
                tsxStatus.Text = MasterModule.Handler.Resources.GetString("Load_References");
                tsbList.Enabled = tsbNew.Enabled = tsbRefresh.Enabled =
                    tsbEdit.Enabled = tsbSave.Enabled = tsbCancel.Enabled =
                    tsbFirst.Enabled = tsbPrevious.Enabled = tsbNext.Enabled =
                    tsbLast.Enabled = false;
                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(Flag.DataLoading);
                return;
            }
            #endregion

            #region UI for Creating and Editing
            if (sender == tsbNew || sender == tsbEdit)
            {
                tsbList.Enabled = tsbNew.Enabled = tsbEdit.Enabled =
                    tsbTruncate.Visible = tsbRefresh.Enabled = tsbFirst.Enabled =
                    tsbPrevious.Enabled = tsbNext.Enabled = tsbLast.Enabled =
                    tsbFirst.Visible = tsbPrevious.Visible = tsbNext.Visible =
                    tsbLast.Visible = tslRecord.Visible = txtCode.ReadOnly =
                    txtName.ReadOnly = txtAddr1.ReadOnly = txtAddr2.ReadOnly =
                    txtCity.ReadOnly = txtPhone1.ReadOnly = txtPhone2.ReadOnly =
                    txtEmail.ReadOnly = txtPositionCode.ReadOnly = txtPositionName.ReadOnly =
                    txtEmplTypeCode.ReadOnly = txtEmplTypeName.ReadOnly =
                    txtSubdepoCode.ReadOnly = txtSubdepoName.ReadOnly = txtBankAccount.ReadOnly = false;

                tsbSave.Enabled = tsbCancel.Enabled = tsbDelete.Enabled =
                    chkStatus.Enabled = btnFoto.Enabled = grbGender.Enabled =
                    dtpDateOfBirth.Enabled = dtpJoin.Enabled = true;

                tsbCancel.Text = tsbDelete.Text =
                    tsbCancel.ToolTipText = tsbDelete.Text = MasterModule.Handler.Resources.GetString("Cancel_Changes");

                if (sender == tsbNew)
                {
                    Flag = Flag.DataCreating;
                    txtCode.Text = txtName.Text =
                    txtAddr1.Text = txtAddr2.Text = txtCity.Text =
                    txtPhone1.Text = txtPhone2.Text = txtEmail.Text =
                    lnkEmail.Text = txtPositionCode.Text = txtPositionName.Text =
                    txtEmplTypeCode.Text = txtEmplTypeName.Text = txtSubdepoCode.Text =
                    txtSubdepoName.Text = txtBankAccount.Text = string.Empty;
                    chkStatus.Checked = true;
                    dtpJoin.Value = dtpJoin.Value = DateTime.Now;

                    pbxFoto.Image = null;
                }
                else
                {
                    Flag = Flag.DataUpdating;
                }
                txtName.Focus();

                return;
            }
            #endregion

            #region UI for Saving and Deleting
            if (sender == tsbSave || sender == tsbCancel ||
                      sender == tsbDelete || sender == tsbTruncate)
            {
                bool tResult = false;
                DialogResult dResult = DialogResult.No;

                if (sender == tsbSave)
                {
                    tResult = Save();

                    if (!tResult)
                        return;
                    else
                        Index = Data.Count - 1;
                }
                else if (sender == tsbCancel || sender == tsbDelete)
                {
                    if (Flag == Flag.DataCreating || Flag == Flag.DataUpdating)
                    {
                        dResult = MessageBox.Show(null,
                                MasterModule.Handler.Resources.GetString("Cancel_Save"),
                                MasterModule.Name,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                        if (dResult == DialogResult.No)
                            return;
                    }
                    else
                    {
                        if (MessageBox.Show(null,
                            string.Format(MasterModule.Handler.Resources.GetString("Msg_Delete"), Data[Index].Name),
                            MasterModule.Name,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Flag = Flag.DataDeleting;

                            tResult = Save();

                            if (!tResult)
                                return;
                            else
                                Index = 0;
                        }
                        else
                            return;
                    }
                }
                else if (sender == tsbTruncate)
                {
                    dResult = MessageBox.Show(null,
                            MasterModule.Handler.Resources.GetString("Msg_Delete_All"),
                            MasterModule.Name,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    if (dResult == DialogResult.Yes)
                    {
                        Flag = Flag.DataTruncating;

                        if (!tResult)
                            return;
                        else
                            Index = -1;
                    }
                }

                tsbList.Enabled = tsbNew.Enabled = tsbTruncate.Visible =
                    tsbRefresh.Enabled = tsbFirst.Visible = tsbPrevious.Visible = 
                    tsbNext.Visible = tsbLast.Visible = tslRecord.Visible =
                    txtCode.ReadOnly = txtName.ReadOnly = txtAddr1.ReadOnly =
                    txtAddr2.ReadOnly = txtCity.ReadOnly = txtPhone1.ReadOnly =
                    txtPhone2.ReadOnly = txtEmail.ReadOnly = txtPositionCode.ReadOnly =
                    txtPositionName.ReadOnly = txtEmplTypeCode.ReadOnly = txtEmplTypeName.ReadOnly =
                    txtSubdepoCode.ReadOnly = txtSubdepoName.ReadOnly = txtBankAccount.ReadOnly = true;

                tsbSave.Enabled = tsbCancel.Enabled = tsbDelete.Enabled =
                    chkStatus.Enabled = btnFoto.Enabled = grbGender.Enabled =
                    dtpDateOfBirth.Enabled = dtpJoin.Enabled = false;

                tsbCancel.ToolTipText = tsbCancel.Text =
                    tsbDelete.ToolTipText = tsbDelete.Text =
                    string.Format(MasterModule.Handler.Resources.GetString("Delete"), string.Empty);

                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(Flag.DataLoading);

                return;
            }
            #endregion

            #region UI for Genereting Code

            if (sender == tsbGenerate)
            {
                // This is only for sample
                string code = string.Format("{0:000000}", Data.Count + 1);
                MessageBox.Show(null,
                    string.Format(MasterModule.Handler.Resources.GetString("Suggested_Code"), code),
                    MasterModule.Name,
                    MessageBoxButtons.OK);
                txtCode.Text = code;
                tsbGenerate.Enabled = false;
                return;
            }
            #endregion

            #region UI Navigation
            if (sender == tsbLast || sender == tsbNext || sender == tsbPrevious || sender == tsbFirst)
            {
                if (sender == tsbFirst)
                    Index = 0;

                if (sender == tsbPrevious)
                    Index--;

                if (sender == tsbNext)
                    Index++;

                if (sender == tsbLast)
                    Index = Data.Count - 1;

                if (!bgwWorker.IsBusy)
                    bgwWorker.RunWorkerAsync(Flag.DetailLoading);
                return;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
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
                try
                {
                    Flag idx = Flag.IDLE;
                    idx = (Flag)e.Argument;
                    switch (idx)
                    {
                        case Flag.FormLoading:
                        case Flag.DataLoading:
                            if (Data != null)
                                Data.Clear();
                            Data = MasterModule.Handler.RepositoryV2.Get<EmployeeDto>()
                                        .Where(m => m.Status == 1).ToList();
                            break;
                        default:
                            break;
                    }
                    e.Cancel = false;
                    e.Result = idx;
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                }
                return;
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
            if (!e.Cancelled)
            {
                if (sender == bgwWorker)
                {
                    try
                    {
                        Flag idx = Flag.IDLE;
                        idx = (Flag)e.Result;
                        switch (idx)
                        {
                            case Flag.FormLoading:
                            case Flag.DataLoading:
                                tspProgress.Visible = false;
                                tsxStatus.Text = MasterModule.Handler.Resources.GetString("Ready");
                                tsbList.Enabled = tsbNew.Enabled = tsbRefresh.Enabled = true;

                                if (Index == -1)
                                {
                                    if (Data.Count != 0)
                                        Index = 0;
                                    else
                                        Index = -1;
                                }
                                if (!bgwWorker.IsBusy)
                                    bgwWorker.RunWorkerAsync(Flag.DetailLoading);
                                break;
                            case Flag.DetailLoading:
                                ShowDetail();
                                ConfigureToolbar();
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    return;
                }
            }
        }

        #endregion


        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void ShowDetail()
        {
            EmployeeDto mm = null;
            if (Index != -1)
                mm = Data[Index];

            if (mm != null)
            {
                txtCode.Text = mm.Code;
                txtName.Text = mm.Name;
                txtAddr1.Text = mm.Address1;
                txtAddr2.Text = mm.Address2;
                txtCity.Text = mm.City;
                txtPhone1.Text = mm.Phone1;
                txtPhone2.Text = mm.Phone2;
                lnkEmail.Text = mm.Email;
                //txtPositionCode.Text = mm.PositionCode;
                //txtPositionName.Text = mm.PositionName;
                //txtEmplTypeCode.Text = mm.SalesmanTypeCode;
                txtSubdepoCode.Text = mm.Subdepo.Code;
                txtSubdepoName.Text = mm.Subdepo.Name;
                txtBankAccount.Text = mm.BankAccount;
                chkStatus.Checked = mm.Status == 1 ? true : false;
                dtpJoin.Value = new DateTime(int.Parse(mm.Joined.Substring(0, 4)), int.Parse(mm.Joined.Substring(4, 2)), int.Parse(mm.Joined.Substring(6)));
                dtpDateOfBirth.Value = new DateTime(int.Parse(mm.BirthDate.Substring(0, 4)), int.Parse(mm.Joined.Substring(4, 2)), int.Parse(mm.Joined.Substring(6)));

                rdbMale.Checked = mm.Gender.Equals("M") ? true : false;
                rdbFemale.Checked = mm.Gender.Equals("F") ? true : false;
                txtEmail.Text = string.Empty;

                btnFoto.Enabled = true;
            }
            Flag = Flag.IDLE;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfigureToolbar()
        {
            if (Data.Count != 0)
            {
                tslRecord.Text = string.Format(MasterModule.Handler.Resources.GetString("Record_Number"), Index + 1, Data.Count);

                tsbEdit.Enabled = true;
                tsbCancel.Enabled = true;
            }
            else
            {
                tslRecord.Text = string.Format(MasterModule.Handler.Resources.GetString("Record_Number"), 0, Data.Count);

                tsbEdit.Enabled = false;
                tsbCancel.Enabled = false;
            }

            if (Index != -1 && Data.Count != 0)
            {
                if (Index != Data.Count - 1)
                    tsbNext.Enabled = tsbLast.Enabled = true;
                else
                    tsbNext.Enabled = tsbLast.Enabled = false;

                if (Index != 0 && Index <= Data.Count - 1)
                    tsbFirst.Enabled = true;
                else
                    tsbFirst.Enabled = false;

                if (Index != 0)
                    tsbPrevious.Enabled = true;
                else
                    tsbPrevious.Enabled = false;
            }
            else
                tsbFirst.Enabled = tsbPrevious.Enabled = tsbNext.Enabled = tsbLast.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool Save()
        {
            bool tResult = false;
            EmployeeDto mm = null;

            try
            {
                if (Flag == Flag.DataDeleting)
                {
                    tResult = MasterModule.Handler.RepositoryV2.Delete<EmployeeDto>(Data[Index].Code).Equals("0") ? true : false;
                }
                else
                {
                    switch (Flag)
                    {
                        case Flag.DataCreating:
                           mm = new EmployeeDto()
                                {
                                    Code = txtCode.Text.Trim(),
                                    Name = txtName.Text.Trim(),
                                    Address1 = txtAddr1.Text.Trim(),
                                    Address2 = txtAddr2.Text.Trim(),
                                    Gender = (rdbMale.Checked == true ? "M" : "F"),
                                    Phone1 = txtPhone1.Text.Trim(),
                                    Phone2 = txtPhone2.Text.Trim(),
                                    //PositionCode = txtPositionCode.Text.Trim(),
                                    //SalesmanTypeCode = txtEmplTypeCode.Text.Trim(),
                                    SubdepoCode = txtSubdepoCode.Text.Trim(),
                                    Email = txtEmail.Text.Trim(),
                                    Joined = dtpJoin.Value.ToString("yyyyMMdd"),
                                    Status = chkStatus.Checked ? 1 : 0,
                                    BankAccount = txtBankAccount.Text.Trim(),
                                    BirthDate = dtpDateOfBirth.Value.ToString("yyyyMMdd"),
                                    City = txtCity.Text.Trim()
                                };

                            tResult = MasterModule.Handler.RepositoryV2.Insert<EmployeeDto>(mm).Equals("0") ? true : false;
                            break;
                        case Flag.DataUpdating:
                            mm = Tag as EmployeeDto;

                                //Code = txtCode.Text.Trim(),
                                mm.Name = txtName.Text.Trim();
                                mm.Address1 = txtAddr1.Text.Trim();
                                mm.Address2 = txtAddr2.Text.Trim();
                                mm.Gender = (rdbMale.Checked == true ? "M" : "F");
                                mm.Phone1 = txtPhone1.Text.Trim();
                                mm.Phone2 = txtPhone2.Text.Trim();
                                //mm.PositionCode = txtPositionCode.Text.Trim();
                                //mm.SalesmanTypeCode = txtEmplTypeCode.Text.Trim();
                                mm.SubdepoCode = txtSubdepoCode.Text.Trim();
                                mm.Email = txtEmail.Text.Trim();
                                mm.Joined = dtpJoin.Value.ToString("yyyyMMdd");
                                mm.Status = chkStatus.Checked ? 1 : 0;
                                mm.BankAccount = txtBankAccount.Text.Trim();
                                mm.BirthDate = dtpDateOfBirth.Value.ToString("yyyyMMdd");
                                mm.City = txtCity.Text.Trim();

                            mm.LastUpdated =  DateTime.Now.ToString("yyyyMMddhhmmss");

                            tResult = MasterModule.Handler.RepositoryV2.Update<EmployeeDto>(mm).Equals("0") ? true : false;
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                tResult = false;
                MessageBox.Show(null,
                    ex.Message,
                    MasterModule.Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
            return tResult;
        }
        #endregion
    }
}
