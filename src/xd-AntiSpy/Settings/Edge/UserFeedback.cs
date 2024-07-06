using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Edge
{
    public class UserFeedback : SettingsBase
    {
        public UserFeedback(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => "Don't Submit user feedback option";

        public override string Info() => "Allow the submission of feedback, suggestions, or customer surveys, as well as reporting issues with the browser";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "UserFeedbackAllowed", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "UserFeedbackAllowed", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "UserFeedbackAllowed", 1, Microsoft.Win32.RegistryValueKind.DWord);

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