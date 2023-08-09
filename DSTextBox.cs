using System.Windows.Forms;

namespace DouhasoftControls.Components
{
    public class DSTextBox : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                Parent.SelectNextControl(this, true, true, true, true);
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
