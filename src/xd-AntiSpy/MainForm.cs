using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views;
using xdAntiSpy.Locales;

namespace xdAntiSpy
{
    public partial class MainForm : Form
    {
        public Control INavPage;
        private Logger logger;
        private bool initializing = true; // Flag to indicate Check phase
        private Dictionary<TreeNode, bool> pendingChanges = new Dictionary<TreeNode, bool>(); // Store pending changes
        private const string pluginDirectory = "plugins";

        // Initialize Logger with MainForm instance
        private void InitializeLogger()
        {
            logger = new Logger(this);
        }

        public MainForm()
        {
            InitializeComponent();
            // Localization test with lang code
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            InitializeLocalizedStrings();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitializeLogger();
            AddDefaultFeatures();
            SetStyle();
            RunFeatureChecks();
        }

        private void InitializeLocalizedStrings()
        {
            btnApply.Text = Locales.Strings.ctl_btnApply;

            undoContextItem.Text = Locales.Strings.menuUndoContextItem;
            doContextItem.Text = Locales.Strings.menuDoContextItem;
            pinContextItem.Text = Locales.Strings.menuPinContextItem;

            profilesToolStripMenuItem.Text = Locales.Strings.menu_profilesToolStripMenuItem;
            profileImportToolStripMenuItem.Text = Locales.Strings.menu_profilesImportToolStripMenuItem;
            profileExportToolStripMenuItem.Text = Locales.Strings.menu_profileExportToolStripMenuItem;
            profileCopyToolStripMenuItem.Text = Locales.Strings.menu_profileCopyToolStripMenuItem;
            profileShareToolStripMenuItem.Text = Locales.Strings.menu_profileShareSettingsToolStripMenuItem;
            toolsToolStripMenuItem.Text = Locales.Strings.menu_toolsToolStripMenuItem;
            toolsRefreshToolStripMenuItem.Text = Locales.Strings.menu_toolsRefreshToolStripMenuItem;
            toolsDebloaterToolStripMenuItem.Text = Locales.Strings.menu_toolsToolDebloaterToolStripMenuItem;
            modeToolStripMenuItem.Text = Locales.Strings.menu_modeToolStripMenuItem;
            modeStandardToolStripMenuItem.Text = Locales.Strings.menu_modeStandardToolStripMenuItem;
            modeAccessibleToolStripMenuItem.Text = Locales.Strings.menu_modeAccessibleToolStripMenuItem;
            aboutToolStripMenuItem.Text = Locales.Strings.menu_aboutToolStripMenuItem;
            aboutAppToolStripMenuItem.Text = Locales.Strings.menu_aboutToolStripMenuItem;
            aboutAppToolStripMenuItem.Text = Locales.Strings.menu_aboutAppToolStripMenuItem;
            aboutWebsiteToolStripMenuItem.Text = Locales.Strings.menu_aboutWebsiteToolStripMenuItem;
            aboutUpdateToolStripMenuItem.Text = Locales.Strings.menu_aboutUpdateToolStripMenuItem;
            aboutSymbolReferenceToolStripMenuItem.Text = Locales.Strings.menu_aboutSymbolReferenceToolStripMenuItem;
        }

        // Run feature checks in background
        private async void RunFeatureChecks()
        {
            Cursor = Cursors.WaitCursor;
            pnlMain.Enabled = false;

            try
            {
                // Perform feature checks
                await CheckAndUpdateFeatures();
                // Perform plugin checks
                await RunPluginChecks();
                // Show some messages regarding the project
                RunFinalChecksAndMessages();
            }
            finally
            {
                // After background tasks are completed, revert to default cursor and re-enable UI controls
                Cursor = Cursors.Default;
                pnlMain.Enabled = true;
                rtbDescription.ScrollToCaret();
            }
        }

        private void SetStyle()
        {
            // Set default form title
            this.Text = $"xd-AntiSpy V{Program.GetCurrentVersionTostring()} ...";
            UpdateTitleWithOSVersion();

            // Set default style for RichTextBox
            rtbDescription.BackColor = Color.FromArgb(255, 255, 206);

            // Segoe MDL2 Assets
            pluginsToolStripMenuItem.Text = "\uE70D"; // Plugins menu

            // Set default NavPage
            Views.SwitchView.INavPage = pnlForm.Controls[0];
            Views.SwitchView.mainForm = this;
        }

        private async void UpdateTitleWithOSVersion()
        {
            string osVersion = await OSHelper.OSHelper.GetWindowsVersion();
            this.Text = $"xd-AntiSpy V{Program.GetCurrentVersionTostring()} - {osVersion}";
        }

        public void AddDefaultFeatures()
        {
            treeSettings.BeginUpdate();
            treeSettings.Nodes.Clear();

            // Define categories and their respective settings nodes
            var categories = new[]
            {
        new { CategoryName = Strings._catAdblock, SettingsNodes = new[]
        {
            new SettingsNode(new Settings.Ads.FileExplorerAds(logger)),
            new SettingsNode(new Settings.Ads.FinishSetupAds(logger)),
            new SettingsNode(new Settings.Ads.LockScreenAds(logger)),
            new SettingsNode(new Settings.Ads.PersonalizedAds(logger)),
            new SettingsNode(new Settings.Ads.SettingsAds(logger)),
            new SettingsNode(new Settings.Ads.StartmenuAds(logger)),
            new SettingsNode(new Settings.Ads.TailoredExperiences(logger)),
            new SettingsNode(new Settings.Ads.TipsAndSuggestions(logger)),
            new SettingsNode(new Settings.Ads.WelcomeExperienceAds(logger))
        }},
        new { CategoryName = Strings._catAI, SettingsNodes = new[]
        {
            new SettingsNode(new Settings.AI.CopilotTaskbar(logger)),
            new SettingsNode(new Settings.AI.RecallCurrentUser(logger)),
            new SettingsNode(new Settings.AI.RecallLocalMachine(logger))
        }},
        new { CategoryName = Strings._catMSEdge, SettingsNodes = new[]
        {
            new SettingsNode(new Settings.Edge.FirstRunExperience(logger)),
            new SettingsNode(new Settings.Edge.ImportOnEachLaunch(logger)),
            new SettingsNode(new Settings.Edge.DefautBrowserSetting(logger)),
            new SettingsNode(new Settings.Edge.GamerMode(logger)),
            new SettingsNode(new Settings.Edge.HubsSidebar(logger)),
            new SettingsNode(new Settings.Edge.EdgeShoppingAssistant(logger)),
            new SettingsNode(new Settings.Edge.DefaultTopSites(logger)),
            new SettingsNode(new Settings.Edge.TabPageQuickLinks(logger)),
            new SettingsNode(new Settings.Edge.BrowserSignin(logger)),
            new SettingsNode(new Settings.Edge.UserFeedback(logger)),
            new SettingsNode(new Settings.Edge.EdgeCollections(logger)),
            new SettingsNode(new Settings.Edge.StartupBoost(logger))
        }},
        new { CategoryName = Strings._catPrivacy, SettingsNodes = new[]
        {
            new SettingsNode(new Settings.Privacy.BackgroundApps(logger)),
            new SettingsNode(new Settings.Privacy.FindMyDevice(logger)),
            new SettingsNode(new Settings.Privacy.PrivacyExperience(logger)),
            new SettingsNode(new Settings.Privacy.Telemetry(logger))
        }},
        new { CategoryName = Strings._catGaming, SettingsNodes = new[]
        {
            new SettingsNode(new Settings.Gaming.GameDVR(logger)),
            new SettingsNode(new Settings.Gaming.PowerThrottling(logger)),
            new SettingsNode(new Settings.Gaming.VisualFX(logger))
        }},
        new { CategoryName = Strings._catSystem, SettingsNodes = new[]
        {
            new SettingsNode(new Settings.System.FaxPrinter(logger)),
            new SettingsNode(new Settings.System.FullContextMenus(logger)),
            new SettingsNode(new Settings.System.LockScreen(logger)),
            new SettingsNode(new Settings.System.VerboseMessages(logger)),
            new SettingsNode(new Settings.System.XPSWriter(logger))
        }},
        new { CategoryName = Strings._catTaskbar, SettingsNodes = new[]
        {
            new SettingsNode(new Settings.Taskbar.BingSearch(logger)),
            new SettingsNode(new Settings.Taskbar.MostUsedApps(logger)),
            new SettingsNode(new Settings.Taskbar.StartmenuLayout(logger)),
            new SettingsNode(new Settings.Taskbar.TaskbarChat(logger)),
            new SettingsNode(new Settings.Taskbar.TaskView(logger)),
            new SettingsNode(new Settings.Taskbar.Widgets(logger)),
            new SettingsNode(new Settings.Taskbar.Searchbox(logger)),
            new SettingsNode(new Settings.Taskbar.StartButtonAlignment(logger))
        }}
    };

            // Create and add parent nodes to the TreeView
            foreach (var category in categories)
            {
                var parent = CreateStyledParentNode(category.CategoryName, category.SettingsNodes);
                treeSettings.Nodes.Add(parent);
            }

            // Expand all nodes
            ExpandAllNodes(treeSettings.Nodes);

            treeSettings.EndUpdate();
        }

        private TreeNode CreateStyledParentNode(string text, TreeNode[] children)
        {
            return new TreeNode(text, children)
            {
                Checked = false,
                NodeFont = new Font(treeSettings.Font.FontFamily, treeSettings.Font.Size, FontStyle.Bold),
                BackColor = Color.FromArgb(228, 226, 221),
                ForeColor = Color.Black
            };
        }

        public void RunFinalChecksAndMessages()
        {
            // Final checks in progress...
            logger.Log(Strings._logFinalCheck, Color.DarkGray);

            logger.Log(Strings._logFinalCheckMessage, Color.Purple);
            logger.Log(Strings._logFinalCheckMessage2, Color.Black);

            // All checks completed.
            logger.Log(Strings._logFinalCheck_complete, Color.DarkGray);
        }

        private async Task RunPluginChecks()
        {
            if (Directory.Exists("plugins"))
            {
                // Starting plugin checks...
                logger.Log(Strings._logPluginsFeatureCheck, Color.Blue);
                treeSettings.BeginUpdate();

                await PluginsBase.LoadPlugins(pluginDirectory, treeSettings.Nodes, logger, contextPluginsStrip);

                treeSettings.EndUpdate();
                // Plugin checks completed.
                logger.Log(Strings._logPluginsFeatureCheck_complete, Color.Blue);

                ExpandAllNodes(treeSettings.Nodes);
            }
        }

        private async Task CheckAndUpdateFeatures()
        {
            //Starting native feature checks...
            logger.Log(Strings._logNativeFeatureCheck, Color.Blue);
            treeSettings.Enabled = false;

            // Set initializing to true to skip unnecessary processing
            initializing = true;

            foreach (TreeNode root in treeSettings.Nodes)
            {
                await CheckNodeFeatures(root);
            }

            // Set initializing to false after all checks are done
            initializing = false;

            // Feature checks completed.
            logger.Log(Strings._logNativeFeatureCheck_complete, Color.Green);
            treeSettings.Enabled = true;
        }

        private async Task CheckNodeFeatures(TreeNode node)
        {
            if (node is SettingsNode settingsNode)
            {
                bool isActive = await Task.Run(() => settingsNode.Feature.CheckFeature());
                settingsNode.Checked = isActive;
                UpdateNodeColor(settingsNode, isActive);
            }

            foreach (TreeNode child in node.Nodes)
            {
                await CheckNodeFeatures(child);
            }
        }

        private void UpdateNodeColor(TreeNode node, bool isActive)
        {
            node.ForeColor = isActive ? Color.DarkGray : Color.Black;
        }

        private void ExpandAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Expand();
                ExpandAllNodes(node.Nodes);
            }
        }

        private void treeSettings_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Skip feature processing if check is running during initialization
            if (initializing)
            {
                if (e.Node is SettingsNode initializingSettingsNode)
                {
                    bool isActive = initializingSettingsNode.Feature.CheckFeature();
                    string status = isActive ? Strings.statusEnabled : Strings.statusDisabled;
                    Color statusColor = isActive ? Color.Black : Color.DarkGray;

                    logger.Log($"{initializingSettingsNode.Feature.ID()} {Strings.statusIsCurrently} {status.ToLower()}", statusColor);
                }
                return;
            }

            // Save pending changes for the current node
            pendingChanges[e.Node] = e.Node.Checked;

            // Handle parent node click events to enable/disable all child nodes
            if (e.Node != null && e.Node.Nodes.Count > 0)
            {
                UpdateChildNodesAndFeatures(e.Node, e.Node.Checked);
            }

            // Enable Apply button if any node is checked/unchecked
            btnApply.Enabled = true;
        }

        // Enable or disable all child nodes and features based on parent node's checked state
        private void UpdateChildNodesAndFeatures(TreeNode parentNode, bool isChecked)
        {
            foreach (TreeNode childNode in parentNode.Nodes)
            {
                if (childNode is SettingsNode settingsNode)
                {
                    // Set checked state of node
                    childNode.Checked = isChecked;

                    // Save pending changes for the child node
                    pendingChanges[childNode] = isChecked;
                }
            }
        }

        // Apply all pending changes
        private void btnApply_Click(object sender, System.EventArgs e)
        {
            foreach (var change in pendingChanges)
            {
                if (change.Key is SettingsNode nodeSettingsNode)
                {
                    bool result;
                    if (change.Value)
                    {
                        result = nodeSettingsNode.Feature.DoFeature();
                    }
                    else
                    {
                        result = nodeSettingsNode.Feature.UndoFeature();
                    }

                    // Log the action
                    string action = change.Value ? Strings.statusEnabled : Strings.statusDisabled;
                    logger.Log($"{Strings.statusApplied}  '{nodeSettingsNode.Feature.ID()}' {Strings.statusHasBeen} {action.ToLower()}.", Color.Black);

                    // Mark the node as applied with yellow color
                    nodeSettingsNode.BackColor = Color.Yellow;
                }
                else if (change.Key is TreeNode pluginNode)
                {
                    var pluginSettings = (PluginsBase)pluginNode.Tag;
                    if (pluginSettings != null)
                    {
                        if (change.Value)
                        {
                            pluginSettings.PlugDoFeature();
                        }
                        else
                        {
                            pluginSettings.PlugUndoFeature();
                        }

                        // Log the action
                        string action = change.Value ? Strings.statusEnabled : Strings.statusDisabled;
                        logger.Log($"{Strings.statusApplied} '{pluginSettings.PlugID}' {Strings.statusHasBeen} {action.ToLower()}.", Color.Black);

                        // Mark the node as applied with yellow color
                        pluginNode.BackColor = Color.Yellow;
                    }
                }
            }

            // Clear pending changes after applying
            pendingChanges.Clear();
        }

        private void profileImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            openFileDialog.Title = "Import Profile";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Example usage to import profile
                var profileManager = new ProfileManager();
                profileManager.ImportProfile(filePath, treeSettings);
            }
        }

        private void profileExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";
            saveFileDialog.Title = "Export Profile";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Example usage to export profile
                var profileManager = new ProfileManager();
                profileManager.ExportProfile(treeSettings, filePath);
            }
        }

        private void profileCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileManager profileManager = new ProfileManager();
            profileManager.CopySettingsToClipboard(treeSettings);
        }

        private void profileShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileManager profileManager = new ProfileManager();
            profileManager.CaptureShareSettings(this);
        }

        private void toolsRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear and reload the features
            AddDefaultFeatures();

            // Refresh plugins
            RunFeatureChecks();
        }

        private void toolsDebloaterToolStripMenuItem_Click(object sender, EventArgs e)
            => Views.SwitchView.SetView(new toolDebloaterPageView());

        private void aboutAppToolStripMenuItem_Click(object sender, EventArgs e)
             => new AboutForm().ShowDialog();

        private void aboutWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
             => Process.Start("https://github.com/builtbybel/xd-Antispy");

        private void aboutUpdateToolStripMenuItem_Click(object sender, EventArgs e)
            => new Updater.Updater().CheckForAppUpdates(logger);

        private void aboutSymbolReferenceToolStripMenuItem_Click(object sender, EventArgs e)
            => new SymbolRefForm().ShowDialog();

        private void rtbDescription_LinkClicked(object sender, LinkClickedEventArgs e)
            => Utils.LaunchUri(e.LinkText);

        private void pluginsToolStripMenuItem_Click(object sender, EventArgs e)
           => this.contextPluginsStrip.Show(Cursor.Position.X, Cursor.Position.Y);

        private void contextMenuDo_Click(object sender, EventArgs e)
        {
            if (treeSettings.SelectedNode is SettingsNode settingsNode)
            {
                bool result = settingsNode.Feature.DoFeature();
                if (result)
                {
                    settingsNode.BackColor = Color.Yellow;
                    settingsNode.Checked = true;
                    logger.Log($"{Strings.statusApplied}  '{settingsNode.Feature.ID()}' {Strings.statusIsEnabled}", Color.Black);
                }
            }
            else if (treeSettings.SelectedNode is TreeNode pluginNode && pluginNode.Tag is PluginsBase pluginSettings)
            {
                pluginSettings.PlugDoFeature();
                pluginNode.BackColor = Color.Yellow;
                pluginNode.Checked = true;
                logger.Log($"{Strings.statusApplied}  '{pluginSettings.PlugID}' {Strings.statusIsEnabled}", Color.Black);
            }
        }

        private void contextMenuUndo_Click(object sender, EventArgs e)
        {
            if (treeSettings.SelectedNode is SettingsNode settingsNode)
            {
                bool result = settingsNode.Feature.UndoFeature();
                if (result)
                {
                    settingsNode.BackColor = Color.Yellow;
                    settingsNode.Checked = false;
                    logger.Log($"Undone: '{settingsNode.Feature.ID()}' {Strings.statusIsDisabled}", Color.Black);
                }
            }
            else if (treeSettings.SelectedNode is TreeNode pluginNode && pluginNode.Tag is PluginsBase pluginSettings)
            {
                pluginSettings.PlugUndoFeature();
                pluginNode.BackColor = Color.Yellow;
                pluginNode.Checked = false;
                logger.Log($"Undone: '{pluginSettings.PlugID}' {Strings.statusIsDisabled}", Color.Black);
            }
        }

        // Attach context menu to each node
        private void treeSettings_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = treeSettings.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    treeSettings.SelectedNode = node;
                    contextManualMenu.Show(Cursor.Position);
                }
            }
        }

        private void treeSettings_MouseMove(object sender, MouseEventArgs e)
        {
            if (!pinContextItem.Checked) // Only update if the description is not pinned
            {
                TreeNode node = treeSettings.GetNodeAt(e.Location);
                if (node != null)
                {
                    if (node is SettingsNode settingsNode)
                    {
                        rtbDescription.Text = settingsNode.Feature.Info();
                    }
                    else if (node.Tag is PluginsBase plugin)
                    {
                        rtbDescription.Text = plugin.GetPluginInformation();
                    }
                    else
                    {
                        rtbDescription.Clear();
                    }
                }
                else
                {
                    rtbDescription.Clear();
                }
            }
        }

        private void pinContextItem_CheckedChanged(object sender, EventArgs e)
        {
            if (pinContextItem.Checked && treeSettings.SelectedNode != null)
            {
                treeSettings.SelectedNode.BackColor = Color.Crimson;
                treeSettings.SelectedNode.ForeColor = Color.White;
            }
            else if (treeSettings.SelectedNode != null)
            {
                treeSettings.SelectedNode.BackColor = treeSettings.BackColor;
                treeSettings.SelectedNode.ForeColor = treeSettings.ForeColor;
                rtbDescription.Clear();
            }
        }

        private void UpdateAccessibilityMode(bool accessibilityMode)
        {
            void UpdateNodeText(TreeNode node)
            {
                if (node is SettingsNode settingsNode)
                {
                    bool isActive = settingsNode.Checked;
                    node.Text = accessibilityMode
                        ? $"{(settingsNode.Checked ? Strings.statusEnabled : Strings.statusDisabled)} - {settingsNode.Feature.ID()}"
                        : settingsNode.Feature.ID();

                    if (accessibilityMode)
                    {
                        node.BackColor = isActive ? Color.LightGreen : Color.LightCoral;
                        node.ForeColor = Color.Black;
                    }
                    else
                    {
                        node.BackColor = Color.Transparent; // Reset to default
                        node.ForeColor = isActive ? Color.DarkGray : Color.Black;
                    }
                }
                else if (node.Tag is PluginsBase plugin)
                {
                    bool isActive = plugin.PlugCheckFeature();
                    node.Text = accessibilityMode
                        ? $"{(plugin.PlugCheckFeature() ? Strings.statusEnabled : Strings.statusDisabled)} - {plugin.PlugID}"
                        : plugin.PlugID;

                    if (accessibilityMode)
                    {
                        node.BackColor = isActive ? Color.LightGreen : Color.LightCoral;
                        node.ForeColor = Color.Black;
                    }
                    else
                    {
                        node.BackColor = Color.Transparent; // Reset to default
                        node.ForeColor = isActive ? Color.DarkGray : Color.Black;
                    }
                }

                // Recursively update child nodes
                foreach (TreeNode childNode in node.Nodes)
                {
                    UpdateNodeText(childNode);
                }
            }

            // Update all nodes in the TreeView
            foreach (TreeNode node in treeSettings.Nodes)
            {
                UpdateNodeText(node);
            }
        }

        private void modeAccessibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAccessibilityMode(true);
            modeAccessibleToolStripMenuItem.CheckState = CheckState.Indeterminate;
            modeStandardToolStripMenuItem.CheckState = CheckState.Unchecked;
        }

        private void modeStandardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAccessibilityMode(false);
            modeStandardToolStripMenuItem.CheckState = CheckState.Indeterminate;
            modeAccessibleToolStripMenuItem.CheckState = CheckState.Unchecked;
        }
    }
}