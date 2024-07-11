using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using xdAntiSpy.Locales;

namespace Settings.Ads
{
    public class FinishSetupAds : SettingsBase
    {
        public FinishSetupAds(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\UserProfileEngagement";
        private const int desiredValue = 0;

        public override string ID() => Strings._adsFinishSetupAds;

        public override string Info() => Strings._adsFinishSetupAds_desc;

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "ScoobeSystemSettingEnabled", 0);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "ScoobeSystemSettingEnabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "ScoobeSystemSettingEnabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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