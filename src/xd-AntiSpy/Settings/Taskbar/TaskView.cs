using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Taskbar
{
    internal class TaskView : SettingsBase
    {
        public TaskView( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int desiredValue =1;

        public override string ID()
        {
            return "Hide Task view button on taskbar";
        }

        public override string Info()
        {
            return "This feature will disable the task view button on the taskbar.";
        }

        public override bool CheckFeature()
        {
            return !(
                   Utils.IntEquals(keyName, "ShowTaskViewButton", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "ShowTaskViewButton", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "ShowTaskViewButton", 1, RegistryValueKind.DWord);
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