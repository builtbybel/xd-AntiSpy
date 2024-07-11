using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using System.Windows.Forms;
using xdAntiSpy.Locales;

namespace Views
{
    public partial class toolDebloaterPageView : UserControl
    {
        private List<AppInfo> appsInfo;
        private bool selectAll = true;

        public toolDebloaterPageView()
        {
            InitializeComponent();
            InitializeLocalizedStrings();
        }

        private void InitializeLocalizedStrings()
        {
            btnRemoveSelected.Text = Strings.formToolDebloater_btnRemoveSelected;
            btnChooseDB.Text = Strings.formToolDebloater_btnChooseDB;
            btnBack.Text = Strings.formToolDebloater_btnBack;
            linkLabelSelectAll.Text = Strings.formToolDebloater_selectAll;
        }

        private async void toolDebloaterPageView_Load(object sender, EventArgs e)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins", "toolDebloater.json");
            await LoadAppsFromJson(jsonFilePath);
        }

        public class AppInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string RemoveCommand { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Description}";
            }
        }

        private async Task LoadAppsFromJson(string jsonFilePath)
        {
            try
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                appsInfo = JsonConvert.DeserializeObject<List<AppInfo>>(jsonString);

                // Clear existing items in CheckedListBox
                checkedListBoxApps.Items.Clear();

                // Iterate through each app info and add to CheckedListBox if installed
                foreach (var appInfo in appsInfo)
                {
                    bool isInstalled = await IsAppInstalled(appInfo.Name);
                    if (isInstalled)
                    {
                        checkedListBoxApps.Items.Add(appInfo, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> IsAppInstalled(string appName)
        {
            bool isInstalled = false;
            try
            {
                lblStatus.Text = $"{Strings.formToolDebloater_statusChecking} {appName}..."; // Checking
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddScript($"Get-AppxPackage -Name *{appName}*");
                    var results = await Task.Run(() => powerShell.Invoke());

                    isInstalled = results.Count > 0;
                }
                lblStatus.Text = $"{appName} {Strings.formToolDebloater_statusCheckComplete}"; // Check completed.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking app {appName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblStatus.Text = Strings.formToolDebloater_statusCheckComplete; // Check completed.
            return isInstalled;
        }

        private async Task ExecutePowerShellCommand(string command)
        {
            try
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.AddScript(command);
                    await Task.Run(() => ps.Invoke());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing PowerShell command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnChooseDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files|*.json";
            openFileDialog.Title = "Select a JSON file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonFilePath = openFileDialog.FileName;
                await LoadAppsFromJson(jsonFilePath);
            }
        }

        private async void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            // Ensure at least one app is checked
            if (checkedListBoxApps.CheckedItems.Count == 0)
            {
                // Please select at least one app to remove
                MessageBox.Show(Strings.formToolDebloater_errorNoAppsCount, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Disable delete button during deletion process
            btnRemoveSelected.Enabled = false;

            // Create a copy of checked items to iterate over
            var checkedItems = checkedListBoxApps.CheckedItems.Cast<AppInfo>().ToList();

            // Iterate through checked items and execute remove command asynchronously
            foreach (var checkedItem in checkedItems)
            {
                AppInfo appInfo = checkedItem as AppInfo;
                if (appInfo != null)
                {
                    // Removing
                    lblStatus.Text = $"{Strings.formToolDebloater_statusRemoving} {appInfo.Name}...";
                    await ExecutePowerShellCommand(appInfo.RemoveCommand);
                    lblStatus.Text = $"{appInfo.Name} {Strings.formToolDebloater_statusRemoved}"; //removed.

                    // Remove the app from CheckedListBox after deletion
                    checkedListBoxApps.Items.Remove(appInfo);
                }
            }

            // Re-enable delete button after deletion process completes
            btnRemoveSelected.Enabled = true;

            lblStatus.Text = Strings.formToolDebloater_successRemoved; // Apps successfully removed.
            MessageBox.Show(Strings.formToolDebloater_successRemoved, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            Views.SwitchView.GoBack();
        }

        private void linkLabelSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < checkedListBoxApps.Items.Count; i++)
            {
                checkedListBoxApps.SetItemChecked(i, selectAll);
            }
            selectAll = !selectAll;
            linkLabelSelectAll.Text = selectAll ? Strings.formToolDebloater_selectAll : Strings.formToolDebloater_DeselectAll;
        }
    }
}