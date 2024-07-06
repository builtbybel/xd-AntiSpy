using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.System
{
    internal class LockScreen : SettingsBase
    {
        public LockScreen( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Personalization";
        private const int desiredValue =0;

        public override string ID()
        {
            return "Don't use personalized lock screen";
        }

        public override string Info()
        {
            return "This feature will disable the personalized lock screen.";
        }

        public override bool CheckFeature()
        {
            return !(
                   Utils.IntEquals(keyName, "NoLockScreen", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "NoLockScreen", 1, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "NoLockScreen", 0, RegistryValueKind.DWord);

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