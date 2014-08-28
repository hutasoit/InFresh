using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using InFresh.Framework.v1.Interfaces;
using InFresh.Framework.v1.Models.Masters;
using InFresh.Master.v1.Enums;
using InFresh.Master.v1.Implements;
using InFresh.Master.v1.Lists;
using WeifenLuo.WinFormsUI.Docking;

namespace InFresh.Master.v1.Pages
{
    public partial class MP001_SubdepoPage : DockContent, IDock
    {
        #region Constructor & Properties
        /// <summary>
        /// 
        /// </summary>
        public MP001_SubdepoPage()
        {
            InitializeComponent();

            Text = TabText = MasterModule.Handler.Resources.GetString("Subdepo").Replace("&", string.Empty);

            Index = -1;
            Flag = Flag.IDLE;
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
        protected IList<SubdepoDto> Data { get; set; }
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
                tsbEdit.Enabled = tsbSave.Enabled= tsbCancel.Enabled =
                tsbFirst.Enabled = tsbPrevious.Enabled = tsbNext.Enabled =
                tsbLast.Enabled = false;
            if (!bgwWorker.IsBusy)
                bgwWorker.RunWorkerAsync(Flag.FormLoading);

            if (!bgwMap.IsBusy)
                bgwMap.RunWorkerAsync(Flag.MapLoading);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (Flag == Flag.DataCreating || Flag == Flag.DataUpdating)
            {
                if (MessageBox.Show(null,
                    MasterModule.Handler.Resources.GetString("Close_Without_Save"),
                    MasterModule.Name,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
            else
            {
                if (bgwWorker.IsBusy || bgwMap.IsBusy)
                {
                    MessageBox.Show(null,
                    MasterModule.Handler.Resources.GetString("Unable_Close"),
                    MasterModule.Name,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
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
                Size = new Size(900, 675);

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
            if (sender == tsbList)
            {
                using (var form = new MS001_ListSubdepo(this))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Index = Data.IndexOf(form.Tag as SubdepoDto);

                        if (!bgwWorker.IsBusy)
                            bgwWorker.RunWorkerAsync(Flag.DetailLoading);
                    }
                }
                return;
            }

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
                    tsbLast.Visible = tslRecord.Visible = txtOldCode.ReadOnly =
                    txtName.ReadOnly = txtAddr1.ReadOnly = txtAddr2.ReadOnly =
                    txtCity.ReadOnly = txtZipCode.ReadOnly = txtPhone1.ReadOnly =
                    txtFax1.ReadOnly = txtLongitude.ReadOnly = txtLatitude.ReadOnly = false;

                tsbSave.Enabled = tsbCancel.Enabled = tsbDelete.Enabled =
                    chkStatus.Enabled = btnFoto.Enabled = btnGeolocation.Enabled = true;

                tsbCancel.Text = tsbDelete.Text =
                    tsbCancel.ToolTipText = tsbDelete.Text = MasterModule.Handler.Resources.GetString("Cancel_Changes");

                if (sender == tsbNew)
                {
                    Flag = Flag.DataCreating;
                    txtCode.Text = txtOldCode.Text = txtName.Text =
                    txtAddr1.Text = txtAddr2.Text = txtCity.Text =
                    txtZipCode.Text = txtPhone1.Text = txtFax1.Text =
                    txtLongitude.Text = txtLatitude.Text = string.Empty;
                    chkStatus.Checked = tsbGenerate.Enabled = lblInfo.Visible = true;

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
                    lblInfo.Visible = tsbRefresh.Enabled = tsbFirst.Visible = 
                    tsbPrevious.Visible = tsbNext.Visible =
                    tsbLast.Visible = tslRecord.Visible =
                    txtOldCode.ReadOnly = txtName.ReadOnly =
                    txtAddr1.ReadOnly = txtAddr2.ReadOnly = txtCity.ReadOnly =
                    txtZipCode.ReadOnly = txtPhone1.ReadOnly = txtFax1.ReadOnly =
                    txtLongitude.ReadOnly = txtLatitude.ReadOnly = true;

                tsbSave.Enabled = tsbGenerate.Enabled = lblInfo.Visible =
                    chkStatus.Enabled = btnFoto.Enabled = btnGeolocation.Enabled = false;

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
                tsbGenerate.Enabled = lblInfo.Visible = false;
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
            if (sender == btnFoto)
            {
                ofdFileDialog.ShowDialog();
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
            if (sender == ofdFileDialog)
            {
                
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
                            Data = MasterModule.Handler.RepositoryV2.Get<SubdepoDto>()
                                        .Where(m => m.Status == 1).ToList();
                            break;
                        //case Flag.DetailLoad:
                        //    if (Index != -1)
                        //        Tag = Data[Index];
                        //    break;
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

                if (sender == bgwMap)
                {
                    try
                    {
                        gmpMap.DragButton = MouseButtons.Left;
                        System.Net.IPHostEntry ev =
                             System.Net.Dns.GetHostEntry("www.google.com");
                    }
                    catch
                    {
                        gmpMap.Manager.Mode = AccessMode.ServerAndCache;
                        MessageBox.Show("No internet connection avaible, going to CacheOnly mode.",
                              MasterModule.Name, MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                    }

                    // config map
                    gmpMap.ScaleMode = ScaleModes.Fractional;
                    gmpMap.Manager.Mode = AccessMode.ServerAndCache;
                    gmpMap.MapProvider = GMapProviders.GoogleMap;
                    gmpMap.MinZoom = 0;
                    gmpMap.MaxZoom = 24;
                    gmpMap.Zoom = 8;

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
            SubdepoDto mm = null;
            if (Index != -1)
                mm = Data[Index];

            if (mm != null)
            {
                txtCode.Text = mm.Code;
                txtOldCode.Text = mm.OldCode;
                txtName.Text = mm.Name;
                txtAddr1.Text = mm.Address1;
                txtAddr2.Text = mm.Address2;
                txtCity.Text = mm.City;
                txtZipCode.Text = mm.ZipCode;
                txtPhone1.Text = mm.Phone1;
                txtFax1.Text = mm.Fax1;
                txtLongitude.Text = mm.Longitude.ToString();
                txtLatitude.Text = mm.Latitude.ToString();
                chkStatus.Checked = mm.Status == 1 ? true : false;

                btnFoto.Enabled = true;
            }
            Flag = Flag.IDLE;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConfigureToolbar()
        {
            tsbList.Enabled = tsbNew.Enabled = tsbRefresh.Enabled = true;
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
            SubdepoDto mm = null;

            try
            {
                if (Flag == Flag.DataDeleting)
                {
                    tResult = MasterModule.Handler.RepositoryV2.Delete<SubdepoDto>(Data[Index].Code).Equals("0") ? true : false;
                }
                else
                {
                    switch (Flag)
                    {
                        case Flag.DataCreating:
                            mm = new SubdepoDto()
                            {
                                OldCode = txtOldCode.Text.Trim(),
                                Name = txtName.Text.Trim(),
                                Address1 = txtAddr1.Text.Trim(),
                                Address2 = txtAddr2.Text.Trim(),
                                City = txtCity.Text.Trim(),
                                ZipCode = txtZipCode.Text.Trim(),
                                Phone1 = txtPhone1.Text.Trim(),
                                Fax1 = txtFax1.Text.Trim(),
                                Status = chkStatus.Checked ? 1 : 0
                            };

                            if (string.IsNullOrWhiteSpace(txtCode.Text.Trim()))
                                mm.Code = string.Format("{0:000000}", Data.Count + 1);
                            else
                                mm.Code = txtCode.Text.Trim();

                            if (!string.IsNullOrWhiteSpace(txtGeoAddr1.Text.Trim()) &&
                                !string.IsNullOrWhiteSpace(txtGeoAddr2.Text.Trim()))
                                mm.GeoAddress = txtGeoAddr1.Text.Trim() + "#" + txtGeoAddr2.Text.Trim();
                            else if (!string.IsNullOrWhiteSpace(txtGeoAddr1.Text.Trim()))
                                mm.GeoAddress = txtGeoAddr1.Text.Trim();
                            else
                                mm.GeoAddress = txtGeoAddr2.Text.Trim();

                            if (!string.IsNullOrWhiteSpace(txtLongitude.Text.Trim()))
                            {
                                string lgt = txtLongitude.Text.Trim();
                                if (Regex.IsMatch(lgt, "^-?\\d*\\.?\\d*$"))
                                    mm.Longitude = double.Parse(lgt);
                            }

                            if (!string.IsNullOrWhiteSpace(txtLatitude.Text.Trim()))
                            {
                                string lat = txtLatitude.Text.Trim();
                                if (Regex.IsMatch(lat, "^-?\\d*\\.?\\d*$"))
                                    mm.Latitude = double.Parse(lat);
                            }

                            tResult = MasterModule.Handler.RepositoryV2.Insert<SubdepoDto>(mm).Equals("0") ? true : false;
                            break;
                        case Flag.DataUpdating:
                            mm = Tag as SubdepoDto;

                            mm.OldCode = txtOldCode.Text.Trim();
                            mm.Name = txtName.Text.Trim();
                            mm.Address1 = txtAddr1.Text.Trim();
                            mm.Address2 = txtAddr2.Text.Trim();
                            mm.City = txtCity.Text.Trim();
                            mm.ZipCode = txtZipCode.Text.Trim();
                            mm.Phone1 = txtPhone1.Text.Trim();
                            mm.Fax1 = txtFax1.Text.Trim();
                            mm.Status = chkStatus.Checked ? 1 : 0;

                            if (!string.IsNullOrWhiteSpace(txtGeoAddr1.Text.Trim()) &&
                                !string.IsNullOrWhiteSpace(txtGeoAddr2.Text.Trim()))
                                mm.GeoAddress = txtGeoAddr1.Text.Trim() + "#" + txtGeoAddr2.Text.Trim();
                            else if (!string.IsNullOrWhiteSpace(txtGeoAddr1.Text.Trim()))
                                mm.GeoAddress = txtGeoAddr1.Text.Trim();
                            else
                                mm.GeoAddress = txtGeoAddr2.Text.Trim();

                            if (!string.IsNullOrWhiteSpace(txtLongitude.Text.Trim()))
                            {
                                string lgt = txtLongitude.Text.Trim();
                                if (Regex.IsMatch(lgt, "^-?\\d*\\.?\\d*$"))
                                    mm.Longitude = double.Parse(lgt);
                            }

                            if (!string.IsNullOrWhiteSpace(txtLatitude.Text.Trim()))
                            {
                                string lat = txtLatitude.Text.Trim();
                                if (Regex.IsMatch(lat, "^-?\\d*\\.?\\d*$"))
                                    mm.Latitude = double.Parse(lat);
                            }

                            mm.LastUpdated =  DateTime.Now.ToString("yyyyMMddhhmmss");

                            tResult = MasterModule.Handler.RepositoryV2.Update<SubdepoDto>(mm).Equals("0") ? true : false;
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
