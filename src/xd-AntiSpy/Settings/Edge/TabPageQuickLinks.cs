using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Edge
{
    public class TabPageQuickLinks: SettingsBase
    {
        public TabPageQuickLinks(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => "Don't Show Quick links in new tab page";

        public override string Info() => "By default, when you open a new tab, you see a Bing search bar, Bing image of the day set as the page background. For supported websites, Quick Links on the New Tab page can display recent updates right in the tile";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "NewTabPageQuickLinksEnabled", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "NewTabPageQuickLinksEnabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "NewTabPageQuickLinksEnabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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