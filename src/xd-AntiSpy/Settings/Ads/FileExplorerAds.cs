using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Ads
{
    internal class FileExplorerAds : SettingsBase
    {
        public FileExplorerAds(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int desiredValue = 0;

        public override string ID()
        {
            return "Disable File Explorer Ads";
        }

        public override string Info()
        {
            return "This feature will disable ads in File Explorer.";
        }

        public override bool CheckFeature()
        {
            return (Utils.IntEquals(keyName, "ShowSyncProviderNotifications", desiredValue));
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "ShowSyncProviderNotifications", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "ShowSyncProviderNotifications",1, RegistryValueKind.DWord);
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