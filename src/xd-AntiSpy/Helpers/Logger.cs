using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace xdAntiSpy
{
    public class Logger
    {
        private MainForm mainForm;

        public Logger(MainForm mainForm)
        {
            this.mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
        }

        // Log method for a single string
        public void Log(string message, Color color, float fontSize = 9.0f)
        {
            // Invoke if necessary to ensure UI update on the main thread
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke(new Action(() => Log(message, color, fontSize)));
                return;
            }

            // Append message to description
            AppendMessageToConversation(message, color, fontSize);

            // Update status menu item
            UpdateStatusMenuItem(message, color);
        }

        private void AppendMessageToConversation(string message, Color color, float fontSize)
        {
            RichTextBox description = mainForm.Controls.Find("rtbDescription", true).FirstOrDefault() as RichTextBox;

            if (description != null)
            {
                // Save the current selection
                int start = description.TextLength;
                // Append the new message
                description.AppendText(message + "\n");
                description.Select(start, description.TextLength);

                // Set font size for the appended message
                description.SelectionFont = new Font(description.Font.FontFamily, fontSize);
                description.SelectionColor = color;
            }
        }

        private void UpdateStatusMenuItem(string message, Color color)
        {
            ToolStripMenuItem statusMenuItem = mainForm.MainMenu.Items.Find("statusToolStripMenuItem", true).FirstOrDefault() as ToolStripMenuItem;

            if (statusMenuItem != null)
            {
                // Limit length of the status message to 80 chars
                string statusMessage = message.Length > 80 ? message.Substring(0, 80) + "..." : message;

                statusMenuItem.Text = $"{statusMessage}"; // Last log:
                statusMenuItem.ForeColor = color;
            }
        }
    }
}