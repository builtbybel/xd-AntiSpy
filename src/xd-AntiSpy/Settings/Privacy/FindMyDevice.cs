using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Privacy
{
    internal class FindMyDevice : SettingsBase
    {
        public FindMyDevice( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location";
        private const string desiredValue = @"Allow";

        public override string ID()
        {
            return "Disable Find my device";
        }

        public override string Info()
        {
            return "This feature will disable find my device.";
        }

        public override bool CheckFeature()
        {
            return !(
                  Utils.StringEquals(keyName, "Value", desiredValue)
            );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "Value", "Deny", RegistryValueKind.String);
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
                Registry.SetValue(keyName, "Value", "Allow", RegistryValueKind.String);

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