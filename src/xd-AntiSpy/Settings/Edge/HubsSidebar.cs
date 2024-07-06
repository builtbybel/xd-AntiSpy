using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Edge
{
    public class HubsSidebar : SettingsBase
    {
        public HubsSidebar(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Edge";

        public override string ID() => "Disable Copilot Symbol in Edge";

        public override string Info() => "This feature will disable Copilot in Microsoft Edge.";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "HubsSidebarEnabled", 0);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "HubsSidebarEnabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "HubsSidebarEnabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }
    }
}