using xdAntiSpy;
using xdAntiSpy.Locales;    
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Ads
{
    internal class TailoredExperiences : SettingsBase
    {
        public TailoredExperiences( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Privacy";
        private const int desiredValue = 0;

        public override string ID()
        {
            return Strings._adsTailoredExperiences;
        }

        public override string Info()
        {
            return Strings._adsTailoredExperiences_desc;
        }

        public override bool CheckFeature()
        {
            return (
                   Utils.IntEquals(keyName, "TailoredExperiencesWithDiagnosticDataEnabled", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "TailoredExperiencesWithDiagnosticDataEnabled", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "TailoredExperiencesWithDiagnosticDataEnabled", 1, RegistryValueKind.DWord);
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