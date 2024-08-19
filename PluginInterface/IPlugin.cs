using System.Windows.Forms;

namespace PluginInterface
{
    public interface IPlugin
    {
        UserControl GetControl();

        // Property for Plugin information
        string PluginName { get; }
        string PluginVersion { get; }
        string PluginInfo { get; }


    }
}