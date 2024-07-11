using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy.Locales;
using xdAntiSpy;

namespace Settings.Edge
{
    public class EdgeCollections : SettingsBase
    {
        public EdgeCollections(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => Strings._edgeEdgeCollections;

        public override string Info() => Strings._edgeEdgeCollections_desc;

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "EdgeCollectionsEnabled", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "EdgeCollectionsEnabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "EdgeCollectionsEnabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

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