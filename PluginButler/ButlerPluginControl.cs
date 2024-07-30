using Newtonsoft.Json;
using PluginInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginButler
{
    public partial class ButlerPluginControl : UserControl, IPlugin
    {
        private List<Item> items;

        public UserControl GetControl()
        {
            return this;
        }

        public ButlerPluginControl()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins", "PluginButler.json");
            string json = File.ReadAllText(jsonFilePath);
            items = JsonConvert.DeserializeObject<List<Item>>(json);
        }

        private void resultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (resultsListBox.SelectedIndex >= 0)
            {
                var selectedItem = items.FirstOrDefault(item => item.Response == resultsListBox.SelectedItem.ToString());
                if (selectedItem != null)
                {
                    ExecuteAction(selectedItem.Action);
                    // Scroll to the bottom of the TextBox
                    resultsTextBox.Focus();
                    resultsTextBox.ScrollToCaret();
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = searchTextBox.Text.ToLower();
            resultsListBox.Items.Clear();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var results = items
                    .Where(item => item.Question.ToLower().Contains(searchTerm))
                    .Select(item => item.Response)
                    .ToList();

                resultsListBox.Items.AddRange(results.ToArray());
            }
        }

        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
        }

        private async void ExecuteAction(string action)
        {
            try
            {
                // Output the action string to help with debugging
                Console.WriteLine($"Executing action: {action}");

                if (action.StartsWith("ms-settings:"))
                {
                    // Open ms-settings URI
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = action,
                        UseShellExecute = true
                    });
                }
                else if (action.StartsWith("cmd:"))
                {
                    // Execute CMD command
                    string command = action.Substring("cmd:".Length);
                    await ExecuteCmdCommand(command);
                }
                else if (action.StartsWith("powershell:"))
                {
                    // Execute PowerShell command
                    string command = action.Substring("powershell:".Length);
                    await ExecutePowerShellCommand(command);
                }
                else if (action.StartsWith("install:"))
                {
                    // Install application using winget
                    string wingetId = action.Substring("install:".Length).Trim();
                    await InstallAppWithWinget(wingetId);
                }
                else
                {
                    // Log unknown action type
                    MessageBox.Show($"Unknown action type: {action}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions
                MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InstallAppWithWinget(string wingetId)
        {
            try
            {
                resultsTextBox.Text = "Installing " + wingetId;

                using (PowerShell powerShell = PowerShell.Create())
                {
                    // Add script to install application with winget
                    powerShell.AddScript($"winget install --id {wingetId} --accept-source-agreements --accept-package-agreements");

                    // Execute script asynchronously
                    var output = await Task.Run(() => powerShell.Invoke());

                    // Capture errors from PowerShell
                    var errors = powerShell.Streams.Error.ReadAll();

                    // Process output
                    if (output.Any())
                    {
                        resultsTextBox.Text = "Output: " + string.Join(Environment.NewLine, output.Select(o => o.ToString()));
                    }

                    // Process errors
                    if (errors.Any())
                    {
                        resultsTextBox.Text += Environment.NewLine + "Error: " + string.Join(Environment.NewLine, errors.Select(e => e.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                resultsTextBox.Text = "Exception: " + ex.Message;
            }
        }

        // Execute PS command
        public async Task ExecutePowerShellCommand(string command)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    // Read output and error asynchronously using Task.Run
                    string output = await Task.Run(() => process.StandardOutput.ReadToEnd());
                    string error = await Task.Run(() => process.StandardError.ReadToEnd());
                    process.WaitForExit(); // Wait for the process to exit (synchronous)

                    // Update UI with results (invoke on UI thread)
                    Invoke((Action)(() =>
                    {
                        resultsTextBox.Text = $"Output: {output}\r\nError: {error}";
                    }));
                }
            }
            catch (Exception ex)
            {
                // Update UI with exception (invoke on UI thread)
                Invoke((Action)(() =>
                {
                    resultsTextBox.Text = $"Exception: {ex.Message}";
                }));
            }
        }

        // Execute CMD command
        public async Task ExecuteCmdCommand(string command)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C \"{command}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    string output = await Task.Run(() => process.StandardOutput.ReadToEnd());
                    string error = await Task.Run(() => process.StandardError.ReadToEnd());
                    process.WaitForExit();

                    Invoke((Action)(() =>
                    {
                        resultsTextBox.Text = $"Output: {output}\r\nError: {error}";
                    }));
                }
            }
            catch (Exception ex)
            {
                Invoke((Action)(() =>
                {
                    resultsTextBox.Text = $"Exception: {ex.Message}";
                }));
            }
        }
    }
}

public class Item
{
    public string Question { get; set; }
    public string Response { get; set; }
    public string Action { get; set; }
}