using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Models.Masters;
using InFresh.Framework.v1.Models.Systems;
using InFresh.Master.v1.Implements;
using InFresh.Utilization.v1.OleProcessor;
using InFresh.Utilization.v1.Processors;

namespace InFresh.Master.v1.Wizards.Imports
{
    public partial class MW001_ImportSubdepo : Form
    {
        #region Constructors and Properties
        /// <summary>
        /// 
        /// </summary>
        public MW001_ImportSubdepo()
        {
            InitializeComponent();
        }
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
        protected IList<SubdepoDto> ExistSubdepo { get; set; }
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

            if (!bgwForm.IsBusy)
                bgwForm.RunWorkerAsync(0);
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboItem_SelectedIdexChanged(object sender, EventArgs e)
        {

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

                    if (!bgwFile.IsBusy)
                        bgwFile.RunWorkerAsync(0);
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
            if (sender == bgwForm)
            {
                if (Templates != null)
                    Templates.Clear();

                Templates = MasterModule.Handler.RepositoryV2.Get<Template1Dto>()
                                .Where(m => m.Status == 1).ToList();

                ExistSubdepo = MasterModule.Handler.RepositoryV2.Get<SubdepoDto>()
                                .Where(m => m.Status == 1).ToList();
                return;
            }

            if (sender == bgwFile)
            {
                if (HeaderFile != null)
                    HeaderFile.Clear();

                HeaderFile = Processor.GetHeaders();
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
            if (sender == bgwForm)
            {
                btnBrowse.Enabled = true;
                tspProgress.Visible = false;
                tspProgress.Style = ProgressBarStyle.Continuous;
                tsxStatus.Text = MasterModule.Handler.Resources.GetString("Ready");
                return;
            }

            if (sender == bgwFile)
            {
                
                return;
            }
        }

        #endregion
    }
}
