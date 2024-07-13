using System.Linq;
using System.Windows.Forms;
using xdAntiSpy;

namespace Views
{
    public static class SwitchView
    {
        public static MainForm mainForm;
        public static Control INavPage;

        public static void SetView(Control View)
        {
            var control = View as Control;

            control.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            control.Dock = DockStyle.Fill;
            INavPage.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            INavPage.Dock = DockStyle.Fill;

            mainForm.pnlForm.Controls.Clear();
            mainForm.pnlForm.Controls.Add(View);
        }

        // Handle the back navigation
        public static void GoBack()
        {
            if (INavPage == null)
                return;

            mainForm.pnlForm.Controls.Clear();
            mainForm.pnlForm.Controls.Add(INavPage);
            mainForm.ActiveControl = INavPage;
            mainForm.Focus();
        }
    }
}