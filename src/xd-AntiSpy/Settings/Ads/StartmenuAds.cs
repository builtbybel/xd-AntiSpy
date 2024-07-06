using Microsoft.Win32;
using xdAntiSpy;
using System;
using System.Drawing;

namespace Settings.Ads
{
    internal class StartmenuAds : SettingsBase
    {
        public StartmenuAds(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int desiredValue = 0;

        public override string ID()
        {
            return "Disable Start menu Ads";
        }

        public override string Info()
        {
            return "This feature will disable ads in the start menu.";
        }

        public override bool CheckFeature()
        {
            return (
                   Utils.IntEquals(keyName, "Start_IrisRecommendations", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "Start_IrisRecommendations", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "Start_IrisRecommendations", 1 ,RegistryValueKind.DWord);
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