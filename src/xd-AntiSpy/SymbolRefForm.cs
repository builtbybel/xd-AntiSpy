using System.Windows.Forms;
using xdAntiSpy.Locales;

namespace xdAntiSpy
{
    public partial class SymbolRefForm : Form
    {
        public SymbolRefForm()
        {
            InitializeComponent();
            InitializeLocalizedStrings();
        }

        private void InitializeLocalizedStrings()
        {
            this.Text = Strings.menu_symbolrefToolStripMenuItem;
            lblActive.Text = Strings.formSymbolRef_lblActive;
            lblInactive.Text = Strings.formSymbolRef_lblInactive;
            lblGreen.Text = Strings.formSymbolRef_lblGreen;
            lblRed.Text = Strings.formSymbolRef_lblRed;
            checkInfoPlugins.Text = Strings.formSymbolRef_checkInfoPlugins;
        }
    }
}