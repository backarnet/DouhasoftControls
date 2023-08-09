using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DouhasoftControls.Components
{
    public class DSComboBox : ComboBox
    {
        List<IFilterable> list;

        public DSComboBox()
        {
            list = new List<IFilterable>();
        }

        public List<IFilterable> List
        {
            get => list;
            set { list = value; DataSource = list; }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectedItem != null)
                {
                    Parent.SelectNextControl(this, true, true, true, true);
                    e.SuppressKeyPress = true;
                }
                else
                {
                    DataSource = list
                        .Where(b => b.Name.Contains(Text))
                        .ToList();
                    DroppedDown = true;
                    SelectAll();
                    e.Handled = e.SuppressKeyPress = true;
                }
            }
        }
    }
}