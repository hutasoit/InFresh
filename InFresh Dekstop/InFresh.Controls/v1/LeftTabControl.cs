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
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            DrawItem += new DrawItemEventHandler(TabControl_DrawItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabControl control = sender as TabControl;
            string str = control.TabPages[e.Index].Text;
            SizeF strLen = g.MeasureString(str, control.Font);

            int x = (int)e.Bounds.Left + 6;
            int y = (int)(e.Bounds.Top + (e.Bounds.Height - strLen.Height) / 2);

            g.DrawString(str, control.Font, Brushes.Black, x, y);
        }

    }
}
