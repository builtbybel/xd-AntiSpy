using xdAntiSpy;
using xdAntiSpy.Locales;
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

        public override string ID() => Strings._edgeHubsSidebar;

        public override string Info() => Strings._edgeHubsSidebar_desc ;

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