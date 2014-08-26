using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InFresh.Framework.v1.Models.Masters;
using InFresh.Master.v1.Enums;
using InFresh.Master.v1.Implements;
using InFresh.Master.v1.Wizards;

namespace InFresh.Master.v1.Lists
{
    public partial class MS001_ListSubdepo : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public MS001_ListSubdepo()
        {
            InitializeComponent();

            dgvData.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        public MS001_ListSubdepo(Form host)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            try
            {
                if (host.GetType() == Type.GetType("InFresh.Master.v1.Lists.MP001_SubdepoPage"))
                {
                }
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 
        /// </summary>
        protected IList<SubdepoDto> Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                Tag = Data[e.RowIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Tag = Data[e.RowIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Flag idx = Flag.IDLE;
            try
            {
                idx = (Flag)e.Argument;
                if (idx != Flag.IDLE)
                {
                    switch (idx)
                    {
                        case Flag.DataLoading:
                            if (Data != null)
                                Data.Clear();
                            Data = MasterModule.Handler.RepositoryV2.Get<SubdepoDto>()
                                    .Where(m => m.Status == 1).ToList();
                            e.Cancel = false;
                            e.Result = idx;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Flag idx = Flag.IDLE;
            try
            {
                idx = (Flag)e.Result;
                if (idx != Flag.IDLE)
                {
                    switch (idx)
                    {
                        case Flag.DataLoading:
                            dgvData.DataSource = null;
                            dgvData.DataSource = Data;
                            Tag = Data[0];

                            dgvData.Enabled =  btnCancel.Enabled = true;
                            crlLoading.Visible = false;
                            
                            btnOK.Enabled = Data.Count != 0 ? true : false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        ///
        /// </summary>
        private void LoadData()
        {
            dgvData.Enabled = btnOK.Enabled = btnCancel.Enabled = false;
            crlLoading.Visible = true;
            if (!bgwWorker.IsBusy)
                bgwWorker.RunWorkerAsync(Flag.DataLoading);
        }

        
    }
}
