using System;
using System.Windows.Forms;
using System.Linq;
using InFresh.Framework.v1.Enums;
using InFresh.Framework.v1.Interfaces;
using System.Collections.Generic;

namespace InFresh.Driver.v1.Forms
{
    public partial class Z0002_WizardWindow : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Z0002_WizardWindow(WizardType type)
        {
            InitializeComponent();
            Type = type;
            switch (Type)
            {
                case WizardType.Import:
                    Text = Program.Handler.Resources.GetString("Import_Data").Replace("&", string.Empty);
                    break;
                case WizardType.Export:
                    Text = Program.Handler.Resources.GetString("Export_Data").Replace("&", string.Empty);
                    break;
            }

            txtSearch.WaterMark = string.Format(Program.Handler.Resources.GetString("Search_Item"), string.Empty);
            cmbSort.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public WizardType Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IWizard Wizard { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            if (lsbType.Items.Count != 0)
                btnOK.Enabled = true;

            try
            {
                var paths = Program.Handler.Wizards.Select(m => m.Value.FullPath).ToList();

                trvCategory.PathSeparator = @"\";

                PopulateTreeView(trvCategory, paths, '\\');

                ShowDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, Program.Handler.Host.DomainName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonItem_Click(object sender, EventArgs e)
        {
            if (sender == btnSearch)
            {
                return;
            }

            if (sender == btnOK)
            {
                Close();
                Dispose();
                DialogResult = DialogResult.OK;
                return;
            }

            if (sender == btnCancel)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeItem_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            ShowDetail();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeItem_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            trvCategory.SelectedNode = e.Node;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeItem_AfterExpand(object sender, TreeViewEventArgs e)
        {
            ShowDetail();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeItem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //if (!e.Node.IsExpanded) e.Node.Expand(); else e.Node.Collapse();
            ShowDetail();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Wizard = lsbType.SelectedItems[0] as IWizard;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="paths"></param>
        /// <param name="pathSeparator"></param>
        private void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                subPathAgg = string.Empty;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    subPathAgg += subPath + pathSeparator;
                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                lastNode = null; // This is the place code was changed
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowDetail()
        {
            Wizard = null;
            List<IWizard> aWizards = null;
            if (trvCategory.SelectedNode != null)

                aWizards = Program.Handler.Wizards
                    .Where(m => m.Value.FullPath.Contains(trvCategory.SelectedNode.FullPath))
                    .Select(m => m.Value).ToList();
            else
                aWizards = Program.Handler.Wizards
                    .Select(m => m.Value).ToList();

            foreach (var w in aWizards)
                lsbType.Items.Add(new ListViewItem { Text = w.Description, Tag = w, });


            //lsbType.DataBindings = aWizards;
            //lsbType.DisplayMember = "Description";
        }
    }
}
