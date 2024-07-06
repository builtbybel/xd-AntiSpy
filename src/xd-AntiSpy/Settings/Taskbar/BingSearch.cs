using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;

namespace Settings.Taskbar
{
    internal class BingSearch : SettingsBase
    {
        public BingSearch(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows";
        private const int desiredValue = 1;

        public override string ID()
        {
            return "Disable Bing Cloud content search";
        }

        public override string Info()
        {
            return "This feature will disable Bing Cloud content search.";
        }

        public override bool CheckFeature()
        {
            return (
                   Utils.IntEquals(keyName, "DisableSearchBoxSuggestions", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "DisableSearchBoxSuggestions", 1, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "DisableSearchBoxSuggestions", 0, RegistryValueKind.DWord);

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