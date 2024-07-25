using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using xdAntiSpy.Locales;

namespace Settings.System
{
    internal class FullContextMenus : SettingsBase
    {
        public FullContextMenus(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\SOFTWARE\CLASSES\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

        public override string ID()
        {
            return Strings._systemFullContextMenus;
        }

        public override string Info()
        {
            return Strings._systemFullContextMenus_desc;
        }

        public override bool CheckFeature()
        {
            try
            {
                object value = Registry.GetValue(keyName, "", null);
                return value != null; // Return true if value is not null
            }
            catch (Exception ex)
            {
                logger.Log("Error occurred while checking: " + ex.Message, Color.Red);
                return false;
            }
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "", "", RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Error occurred while enabling: " + ex.Message, Color.Red);
                return false;
            }
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}", false);
                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Error occurred while disabling: " + ex.Message, Color.Red);
                return false;
            }
        }
    }
}