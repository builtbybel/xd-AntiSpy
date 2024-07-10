using xdAntiSpy;
using xdAntiSpy.Locales;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Privacy
{
    internal class BackgroundApps : SettingsBase
    {
        public BackgroundApps( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications";
        private const int desiredValue = 0;

        public override string ID()
        {
            return Strings._privacyBackgroundApps;
        }

        public override string Info()
        {
            return Strings._privacyBackgroundApps_desc;
        }

        public override bool CheckFeature()
        {
            return !(
                   Utils.IntEquals(keyName, "GlobalUserDisabled", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "GlobalUserDisabled", 1, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "GlobalUserDisabled", desiredValue, RegistryValueKind.DWord);

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