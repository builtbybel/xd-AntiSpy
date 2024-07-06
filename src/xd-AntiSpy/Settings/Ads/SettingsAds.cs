using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;


namespace Settings.Ads
{
    internal class SettingsAds : SettingsBase
    {
        public SettingsAds( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int desiredValue = 0;

        public override string ID() => "Disable Settings Ads";

        public override string Info() => "This feature will disable ads in settings.";

        public override bool CheckFeature()
        {
            return (Utils.IntEquals(keyName, "SubscribedContent-338393Enabled", desiredValue) &&
                   Utils.IntEquals(keyName, "SubscribedContent-353694Enabled", desiredValue) &&
                   Utils.IntEquals(keyName, "SubscribedContent-353696Enabled", desiredValue)
            );
        }
   

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "SubscribedContent-338393Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord); 
                Registry.SetValue(keyName, "SubscribedContent-353694Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord); 
                Registry.SetValue(keyName, "SubscribedContent-353696Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "SubscribedContent-338393Enabled", 1, Microsoft.Win32.RegistryValueKind.DWord);
                Registry.SetValue(keyName, "SubscribedContent-353694Enabled",1, Microsoft.Win32.RegistryValueKind.DWord);
                Registry.SetValue(keyName, "SubscribedContent-353696Enabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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