using System.Windows.Forms;

namespace PluginInterface
{
    public interface IPlugin
    {
        UserControl GetControl();
    }
}