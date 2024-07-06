using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Ads
{
    internal class TipsAndSuggestions : SettingsBase
    {
        public TipsAndSuggestions( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int desiredValue = 0;

        public override string ID() => "Disable General Tips and Ads";

        public override string Info() => "This feature will disable general tips and ads.";

        public override bool CheckFeature()
        {
            return (Utils.IntEquals(keyName, "SubscribedContent-338389Enabled", desiredValue)
                 );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "SubscribedContent-338389Enabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "SubscribedContent-338389Enabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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