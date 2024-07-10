using xdAntiSpy;
using xdAntiSpy.Locales;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Taskbar
{
    internal class Searchbox : SettingsBase
    {
        public Searchbox(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search";
        private const int desiredValue = 1;

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
                   Utils.IntEquals(keyName, "SearchboxTaskbarMode", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "SearchboxTaskbarMode", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "SearchboxTaskbarMode", 1, RegistryValueKind.DWord);
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