using xdAntiSpy;
using xdAntiSpy.Locales;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Privacy
{
    public class PrivacyExperience : SettingsBase
    {
        public PrivacyExperience( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\OOBE";
        private const int desiredValue = 0;

        public override string ID() => Strings._privacyPrivacyExperience;

        public override string Info() => Strings._privacyPrivacyExperience_desc;

        public override bool CheckFeature()
        {
            return !Utils.IntEquals(keyName, "DisablePrivacyExperience", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "DisablePrivacyExperience", 1, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "DisablePrivacyExperience", 0, Microsoft.Win32.RegistryValueKind.DWord);

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