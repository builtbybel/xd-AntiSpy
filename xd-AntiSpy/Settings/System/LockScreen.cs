using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using LocalizationLibrary.Locales;

namespace Settings.System
{
    internal class LockScreen : SettingsBase
    {
        public LockScreen(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Personalization";
        private const string valueName = "NoLockScreen";
        private const int desiredValue = 0;

        public override string ID()
        {
            return Strings._systemLockScreen;
        }

        public override string Info()
        {
            return Strings._systemLockScreen_desc;
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
                Registry.SetValue(keyName, valueName, 1, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, valueName, 0, RegistryValueKind.DWord);

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