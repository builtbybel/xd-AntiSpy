using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xdAntiSpy.Locales;

namespace xdAntiSpy
{
    public class ProfileManager
    {
        public void ExportProfile(TreeView treeSettings, string filePath)
        {
            try
            {
                // Collect checked nodes
                var checkedNodes = GetCheckedNodes(treeSettings.Nodes);

                // Serialize to JSON
                string json = JsonConvert.SerializeObject(checkedNodes, Formatting.Indented);

                // Write to file
                File.WriteAllText(filePath, json);

                // Log success
                MessageBox.Show($"Profile exported successfully to: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting profile: {ex.Message}");
            }
        }

        public void ImportProfile(string filePath, TreeView treeSettings)
        {
            try
            {
                // Read JSON from file
                string json = File.ReadAllText(filePath);

                // Deserialize JSON
                var checkedNodes = JsonConvert.DeserializeObject<List<string>>(json);

                // Restore checked states in TreeView
                RestoreCheckedNodes(treeSettings.Nodes, checkedNodes);

                // Log success
                MessageBox.Show($"Profile imported successfully from: {filePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing profile: {ex.Message}");
            }
        }

        private List<string> GetCheckedNodes(TreeNodeCollection nodes)
        {
            List<string> checkedNodes = new List<string>();

            foreach (TreeNode node in nodes)
            {
                // Recursively add checked nodes
                if (node.Checked)
                {
                    checkedNodes.Add(node.FullPath);
                }

                checkedNodes.AddRange(GetCheckedNodes(node.Nodes));
            }

            return checkedNodes;
        }

        private void RestoreCheckedNodes(TreeNodeCollection nodes, List<string> checkedNodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Check if the current node's full path exists in checkedNodes list
                bool isChecked = checkedNodes.Contains(node.FullPath);

                // Set checked property accordingly
                node.Checked = isChecked;

                // Recursively restore checked nodes
                RestoreCheckedNodes(node.Nodes, checkedNodes);
            }
        }

        public void CopySettingsToClipboard(TreeView treeSettings)
        {
            StringBuilder settingsBuilder = new StringBuilder();

            foreach (TreeNode categoryNode in treeSettings.Nodes)
            {
                foreach (TreeNode settingNode in categoryNode.Nodes)
                {
                    if (settingNode is SettingsNode settingsNode)
                    {
                        string status = settingsNode.Checked ? Strings.statusEnabled : Strings.statusDisabled;
                        settingsBuilder.AppendLine($"{settingsNode.Text}: {status}");
                    }
                    else if (settingNode.Tag is PluginsBase pluginSettings)
                    {
                        string status = settingNode.Checked ? Strings.statusEnabled : Strings.statusDisabled;
                        settingsBuilder.AppendLine($"{pluginSettings.PlugID}: {status}");
                    }
                }
            }

            Clipboard.SetText(settingsBuilder.ToString());
            MessageBox.Show("Settings copied to clipboard.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CaptureShareSettings(Form form)
        {
            // Capture the entire form
            Rectangle formBounds = form.Bounds;
            Bitmap bitmap = new Bitmap(formBounds.Width, formBounds.Height);
            form.DrawToBitmap(bitmap, new Rectangle(0, 0, formBounds.Width, formBounds.Height));

            // Save the screenshot to a temporary file
            string filePath = Path.Combine(Path.GetTempPath(), "SettingsScreenshot.png");
            bitmap.Save(filePath, ImageFormat.Png);

            // Copy the image to the clipboard
            Clipboard.SetImage(bitmap);

            // Prepare the tweet text and URL
            string tweetText = Uri.EscapeDataString("Check out my system configuration with the XD-AntiSpy app, bringing back the vibes of XP-Antispy for Windows 11! #xdAntiSpy #Windows11 #Nostalgia");
            string tweetUrl = $"https://twitter.com/intent/tweet?text={tweetText}";

            // Open the default web browser to share on Twitter
            Process.Start(new ProcessStartInfo
            {
                FileName = tweetUrl,
                UseShellExecute = true
            });

            // Show a message box to inform the user
            MessageBox.Show("Screenshot captured and copied to clipboard. Ready to share on X/Twitter.\n\nDon't forget to paste the image from the clipboard when tweeting!", "Share Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}