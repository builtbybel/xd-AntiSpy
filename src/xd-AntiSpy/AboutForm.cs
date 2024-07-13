using System;
using System.Diagnostics;
using System.Windows.Forms;
using xdAntiSpy.Locales;

namespace xdAntiSpy
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            InitializeLocalizedStrings();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeLocalizedStrings()
        {
            lblAbout.Text = Strings.formAbout_lblAbout;
            linkOpenDonationPage.Text = Strings.formAbout_linkDonation;
        }

        private void linkOpenDonationPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string paypalUrl = "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = paypalUrl,
                    UseShellExecute = true
                });
                MessageBox.Show("Thank you for your support! 💖", "Thank You!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open the donation page. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}