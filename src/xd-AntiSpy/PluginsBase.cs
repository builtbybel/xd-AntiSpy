using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xdAntiSpy
{
    public class PluginsBase
    {
        public string PlugID { get; set; }
        public string PlugInfo { get; set; }
        public string[] PlugCheck { get; set; }
        public string[] PlugDo { get; set; }
        public string[] PlugUndo { get; set; }
        public string PlugCategory { get; set; }

        private Logger logger;

        public PluginsBase(Logger logger)
        {
            this.logger = logger;
        }

        public bool PlugCheckFeature()
        {
            bool isFeatureActive = true;
            foreach (var command in PlugCheck)
            {
                if (!ExecuteCommandAndCheckResult(command))
                {
                    isFeatureActive = false;
                    break;
                }
            }
            logger.Log($"Feature '{PlugID}' is {(isFeatureActive ? "active" : "inactive")}", System.Drawing.Color.Green);
            return isFeatureActive;
        }

        // PlugCheck Helper to execute commands and check the result
        private bool ExecuteCommandAndCheckResult(string command)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c {command}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };
                process.Start();
                process.WaitForExit();

                // Read the output of the command
                string output = process.StandardOutput.ReadToEnd();

                // Check if output contains "1" (indicating active) or "0" (indicating inactive)
                bool isActive = output.Contains("1");

                logger.Log($"Plugin executed successfully: {command}. Result: {(isActive ? "active" : "inactive")}", System.Drawing.Color.Green);

                return isActive;
            }
            catch (Exception ex)
            {
                logger.Log($"Error executing plugin: {command}. Exception: {ex.Message}", System.Drawing.Color.Red);
                return false;
            }
        }

        public async void PlugDoFeature()
        {
            await ExecuteFeatureCommands(PlugDo);
        }

        public async void PlugUndoFeature()
        {
            await ExecuteFeatureCommands(PlugUndo);
        }

        private async Task ExecuteFeatureCommands(string[] commands)
        {
            foreach (var command in commands)
            {
                await ExecuteCommand(command);
            }
        }

        private async Task ExecuteCommand(string command)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = IsPowerShellCommand(command) ? "powershell.exe" : "cmd.exe",
                        Arguments = IsPowerShellCommand(command) ? $"-Command \"{command}\"" : $"/c \"{command}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };

                // Event handler for handling output data
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        logger.Log($"Output: {e.Data}", System.Drawing.Color.Green);
                    }
                };

                // Event handler for handling error data
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        logger.Log($"Error: {e.Data}", System.Drawing.Color.Red);
                    }
                };

                process.Start();

                // Begin asynchronous reading of the output and error streams
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // Wait for the process to exit
                await process.WaitForExitAsync();

                // Log command execution
                logger.Log($"Plugin executed command: {command}", System.Drawing.Color.Green);
            }
            catch (Exception ex)
            {
                logger.Log($"Error executing plugin: {command}. Exception: {ex.Message}", System.Drawing.Color.Red);
            }
        }

        // Method to determine if our command should be run with PowerShell
        private bool IsPowerShellCommand(string command)
        {
            // If command starts with "powershell.exe" or contains PowerShell specific cmdlets
            return command.StartsWith("powershell.exe") || command.Contains("Get-") || command.Contains("Set-");
        }

        // Get plugin information
        public string GetPluginInformation()
        {
            return $"{PlugInfo}";
        }

        private static void AddToPluginCategory(TreeNodeCollection pluginCategory, TreeNode node, string category)
        {
            if (pluginCategory == null)
                throw new ArgumentNullException(nameof(pluginCategory));
            //  n.Text == "Plugins"); No more need for static category
            var existingCategory = pluginCategory.Cast<TreeNode>().FirstOrDefault(n => n.Text == category);

            if (existingCategory == null)
            {
                existingCategory = new TreeNode(category)
                {
                    NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Bold),
                    BackColor = System.Drawing.Color.LightBlue,
                    ForeColor = System.Drawing.Color.Black
                };
                pluginCategory.Add(existingCategory);
            }

            node.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular); // Nodes
            existingCategory.Nodes.Add(node);
        }

        public static async Task LoadPlugins(string pluginDirectory, TreeNodeCollection pluginCategory, Logger logger, ContextMenuStrip powerShellScriptsMenu)
        {
            if (Directory.Exists(pluginDirectory))
            {
                var pluginFiles = Directory.GetFiles(pluginDirectory, "*.json");

                foreach (var file in pluginFiles)
                {
                    if (Path.GetFileName(file).Equals("toolDebloater.json", StringComparison.OrdinalIgnoreCase))
                        continue;

                    try
                    {
                        var json = File.ReadAllText(file);
                        var plugin = JsonConvert.DeserializeObject<PluginsBase>(json);

                        if (plugin != null)
                        {
                            plugin.logger = logger; // Set logger for the plugin

                            // Execute all commands for the plugin to check its feature
                            bool isActive = plugin.PlugCheckFeature();

                            var pluginNode = new TreeNode(plugin.PlugID)
                            {
                                // ToolTipText = plugin.PlugInfo,
                                Checked = isActive,
                                NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular),
                                Tag = plugin // Store plugin object in Tag property
                            };

                            // Add to the appropriate category
                            AddToPluginCategory(pluginCategory, pluginNode, plugin.PlugCategory);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Log($"Error loading plugin from file '{file}': {ex.Message}", System.Drawing.Color.Red);
                    }
                }

                await LoadPowerShellScripts(pluginDirectory, powerShellScriptsMenu, logger);
            }
        }

        /* ------------------------------------------------------------------------------ 
         PS Plugin support in ContextMenuStrip
         */
        public static async Task LoadPowerShellScripts(string scriptDirectory, ContextMenuStrip contextPluginsStrip, Logger logger)
        {
            // Lets define a marker for Ps scripts
            const string markerTag = "PS_SCRIPTS_START";

            // Remove existing PowerShell script items if they exist
            for (int i = contextPluginsStrip.Items.Count - 1; i >= 0; i--)
            {
                if (contextPluginsStrip.Items[i].Tag?.ToString() == markerTag)
                {
                    contextPluginsStrip.Items.RemoveAt(i);
                }
            }

            // Add a marker item
            var markerItem = new ToolStripLabel("Plugins")
            {
                Tag = markerTag,
                ForeColor = System.Drawing.Color.Blue,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Underline)
            };

            contextPluginsStrip.Items.Add(markerItem);

            // Add a menu item to open the plugins directory
            var openPluginsDirMenuItem = new ToolStripMenuItem("Open Plugins directory") { Tag = markerTag };
            openPluginsDirMenuItem.Click += (sender, e) =>
            {
                try
                {
                    string pluginsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
                    if (Directory.Exists(pluginsDir))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", pluginsDir);
                    }
                    else
                    {
                        MessageBox.Show("Plugins directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    logger.Log($"Error opening plugins directory: {ex.Message}", System.Drawing.Color.Red);
                }
            };
            contextPluginsStrip.Items.Add(openPluginsDirMenuItem);

            // Check if plugins dir exists
            if (!Directory.Exists(scriptDirectory))
            {
                logger.Log($"Directory {scriptDirectory} does not exist", System.Drawing.Color.Red);

                return;
            }

            // Add Ps plugin items
            var scriptFiles = Directory.GetFiles(scriptDirectory, "*.ps1");
            foreach (var file in scriptFiles)
            {
                var scriptName = Path.GetFileNameWithoutExtension(file);
                var menuItem = new ToolStripMenuItem(scriptName) { Tag = markerTag };
                menuItem.Click += async (sender, e) =>
                {
                    // Ask user to confirm plugin execution
                    var result = MessageBox.Show($"{scriptName}?", scriptName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        await ExecutePowerShellScript(file, logger);
                    }
                };
                contextPluginsStrip.Items.Add(menuItem);
            }
        }

        public static async Task ExecutePowerShellScript(string filePath, Logger logger)
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{filePath}\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    var outputBuilder = new StringBuilder();
                    var errorBuilder = new StringBuilder();

                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            outputBuilder.AppendLine(e.Data);
                            logger.Log($"PowerShell script output: {e.Data}", System.Drawing.Color.Gray);
                        }
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            errorBuilder.AppendLine(e.Data);
                            logger.Log($"PowerShell script error: {e.Data}", System.Drawing.Color.Red);
                        }
                    };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    await Task.Run(() =>
                    {
                        process.WaitForExit();
                    });

                    logger.Log($"PowerShell script executed successfully: {filePath}", System.Drawing.Color.Green);
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error executing PowerShell script: {filePath}. Exception: {ex.Message}", System.Drawing.Color.Red);
            }
        }
    }
}

// Extension method to make WaitForExit async in ExecuteCommand
public static class ProcessExtensions
{
    public static async Task WaitForExitAsync(this Process process)
    {
        var tcs = new TaskCompletionSource<bool>();
        process.EnableRaisingEvents = true;
        process.Exited += (sender, args) => tcs.TrySetResult(true);
        await tcs.Task;
    }
}