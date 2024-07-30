using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using LocalizationLibrary.Locales;

namespace Settings.Privacy
{
    internal class FindMyDevice : SettingsBase
    {
        public FindMyDevice(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location";
        private const string valueName = "Value";
        private const string desiredValue = @"Allow";

        public override string ID()
        {
            return Strings._privacyFindMyDevice;
        }

        public override string Info()
        {
            return Strings._privacyFindMyDevice_desc;
        }

        public override bool CheckFeature()
        {
            return !(
                  Utils.StringEquals(keyName, valueName, desiredValue)
            );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, valueName, "Deny", RegistryValueKind.String);
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
                Registry.SetValue(keyName, valueName, desiredValue, RegistryValueKind.String);

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