using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InFresh.Controls.v1
{
    public partial class LeftTabControl : TabControl
    {
        /// <summary>
        /// 
        /// </summary>
        public LeftTabControl()
        {

            InitializeComponent();

            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);
            Graphics g = e.Graphics;
            string str = this.TabPages[e.Index].Text;
            SizeF strLen = g.MeasureString(str, this.Font);

            int x = (int)e.Bounds.Left + 6;
            int y = (int)(e.Bounds.Top + (e.Bounds.Height - strLen.Height) / 2);

            g.DrawString(str, this.Font, Brushes.Black, x, y);
        }
    }
}
