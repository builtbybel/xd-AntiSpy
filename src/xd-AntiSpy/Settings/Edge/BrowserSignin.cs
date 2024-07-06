using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;

namespace Settings.Edge
{
    public class BrowserSignin : SettingsBase
    {
        public BrowserSignin(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => "Disable Browser sign in and sync services";

        public override string Info() => "This setting controls whether a user can sign into Microsoft Edge with an account to use services such as sync and single sign on";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "BrowserSignin", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "BrowserSignin", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "BrowserSignin", 1, Microsoft.Win32.RegistryValueKind.DWord);

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