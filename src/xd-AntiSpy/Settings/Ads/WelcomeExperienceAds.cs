using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Ads
{
    public class WelcomeExperienceAds : SettingsBase
    {
        public WelcomeExperienceAds( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int desiredValue = 0;

        public override string ID() => "Disable Welcome Experience Ads";

        public override string Info() => "This feature will disable ads in the welcome experience.";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "SubscribedContent-310093Enabled", 0);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "SubscribedContent-310093Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "SubscribedContent-310093Enabled",1, Microsoft.Win32.RegistryValueKind.DWord);

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