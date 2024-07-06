using xdAntiSpy;

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
            return "Disable Tailored experiences";
        }

        public override string Info()
        {
            return "Tailored Experiences allows Microsoft to get information from you to deliver personalized tips, ads, and recommendations. Many people would call this telemetry, or even spying.";
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