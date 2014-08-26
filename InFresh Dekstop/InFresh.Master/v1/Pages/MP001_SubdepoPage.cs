using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

                    txtOldCode.Focus();
                }

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
                        if (Data.Count != 0)
                            Index = 0;
                        else
                            Index = -1;
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

                            if (!bgwWorker.IsBusy)
                                bgwWorker.RunWorkerAsync(Flag.DetailLoading);
                            break;
                        case Flag.DetailLoading:
                            ConfigureToolbar();
                            ShowDetail();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

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
        #endregion
    }
    
}
