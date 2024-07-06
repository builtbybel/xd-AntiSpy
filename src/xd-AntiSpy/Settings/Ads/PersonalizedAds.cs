using Microsoft.Win32;
using xdAntiSpy;
using System;
using System.Drawing;


namespace Settings.Ads
{
    public class PersonalizedAds: SettingsBase
    {
        public PersonalizedAds( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo";
        private const int desiredValue =0;

        public override string ID() => "Disable Personalized Ads";

        public override string Info() => "This feature will disable personalized ads."; 

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "Enabled", 0);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "Enabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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