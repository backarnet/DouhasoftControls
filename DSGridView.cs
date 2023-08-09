using System.Windows.Forms;

namespace DouhasoftControls.Components
{
    public class DSGridView : DataGridView
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                SendKeys.Send("\t");
            }
            else
                base.OnKeyDown(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                EndEdit();
                SendKeys.Send("\t");
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
