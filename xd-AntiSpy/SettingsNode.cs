using System.Windows.Forms;

namespace xdAntiSpy
{
    internal class SettingsNode : TreeNode
    {
        public SettingsBase Feature { get; private set; }

        public SettingsNode(SettingsBase feature)
        {
            Feature = feature;
            Text = Feature.ID();
        }
    }
}