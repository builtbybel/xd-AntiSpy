using xdAntiSpy;

using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Privacy
{
    public class Telemetry : SettingsBase
    {
        public Telemetry( Logger logger) : base(logger)
        {
        }

        private const string dataCollection = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\DataCollection";
        private const string diagTrack = @"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\DiagTrack";
        private const string dmwappushservice = @"HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services\dmwappushservice";

        public override string ID() => "Turn off Telemetry data collection";

        public override string Info() => "Unfortunately, Microsoft does not allow Windows 11 or Windows 10 Home edition users to completely turn off the collection of telemetry data. However, those users can still limit some optional data collection through System settings.";

        public override bool CheckFeature()
        {
            return (
               Utils.IntEquals(dataCollection, "AllowTelemetry", 1) &&
                Utils.IntEquals(dataCollection, "MaxTelemetryAllowed", 1) &&
                Utils.IntEquals(diagTrack, "Start", 2) &&
                Utils.IntEquals(dmwappushservice, "Start", 2)

           );
        }

        public override bool DoFeature()
        {
            try
            {
     
                Registry.SetValue(dataCollection, "AllowTelemetry", 1, RegistryValueKind.DWord);
                Registry.SetValue(dataCollection, "MaxTelemetryAllowed", 1, RegistryValueKind.DWord);
                Registry.SetValue(diagTrack, "Start", 2, RegistryValueKind.DWord);
                Registry.SetValue(dmwappushservice, "Start", 2, RegistryValueKind.DWord);

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
                Registry.SetValue(dataCollection, "AllowTelemetry", 3, RegistryValueKind.DWord);
                Registry.SetValue(dataCollection, "MaxTelemetryAllowed", 3, RegistryValueKind.DWord);
                Registry.SetValue(diagTrack, "Start", 4, RegistryValueKind.DWord);
                Registry.SetValue(dmwappushservice, "Start", 4, RegistryValueKind.DWord);

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