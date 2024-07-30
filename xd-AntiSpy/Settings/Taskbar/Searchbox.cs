using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using LocalizationLibrary.Locales;

namespace Settings.Taskbar
{
    internal class Searchbox : SettingsBase
    {
        public Searchbox(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search";
        private const string valueName = "SearchboxTaskbarMode";
        private const int desiredValue = 2;

        public override string ID()
        {
            return Strings._taskbarSearchbox;
        }

        public override string Info()
        {
            return Strings._taskbarSearchbox_desc;
        }

        public override bool CheckFeature()
        {
            return !(
                   Utils.IntEquals(keyName, valueName, desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, valueName, 2, RegistryValueKind.DWord);
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