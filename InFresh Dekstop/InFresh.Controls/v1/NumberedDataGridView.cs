using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InFresh.Controls.v1
{
    public class NumberedDataGridView : DataGridView
    {
        public NumberedDataGridView()
        {
            BorderStyle = BorderStyle.None;
            BackgroundColor = SystemColors.ControlLightLight;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);

            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (RowHeadersWidth < (int)(size.Width + 20))
                RowHeadersWidth = (int)(size.Width + 20);
            else
                RowHeadersWidth = 41;

            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber,
                this.Font, b, e.RowBounds.Location.X + 15,
                e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

        }
    }
}
