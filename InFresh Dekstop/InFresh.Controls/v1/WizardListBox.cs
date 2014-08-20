using System.Drawing;
using System.Windows.Forms;

namespace InFresh.Controls.v1
{
    public partial class WizardListBox : ListBox
    {
        public WizardListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //base.OnDrawItem(e);
            e.DrawBackground();
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.Graphics.DrawRectangle(Pens.Transparent, 2, e.Bounds.Y + 2, 14, 14); 

                var textRect = e.Bounds;
                textRect.X += 20;
                textRect.Width -= 20;

                string itemText = DesignMode ? "Wizard Item Name" : Items[e.Index].ToString();
                TextRenderer.DrawText(e.Graphics, itemText, e.Font, textRect, e.ForeColor, flags);
                e.DrawFocusRectangle();
            }
        }
    }
}
