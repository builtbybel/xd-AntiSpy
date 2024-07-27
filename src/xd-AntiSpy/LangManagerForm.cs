using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace xdAntiSpy
{
    public partial class LangManagerForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private readonly Dictionary<string, string> languageNames = new Dictionary<string, string>
        {
            { "en", "English (default)" },
            { "de", "Deutsch" },
            { "es", "Español" },
            { "it", "Italiano" },
            { "fr", "Français" },
            { "ja", "日本語" },
            { "zh", "中文" },     // Chinese
            { "ru", "Русский" }, 
            { "pt", "Português" }, 
            { "ar", "العربية" }, // Arabic
            { "ko", "한국어" },  // Korean
            { "vi", "Tiếng Việt" }, // Vietnamese
            { "tr", "Türkçe" }   // Turkish
        };



        public LangManagerForm()
        {
            InitializeComponent();
            LoadLanguages();
        }

        private async void LoadLanguages()
        {
            this.Text = "Loading languages...";

            // Fetch the language contents from GitHub
            string apiUrl = "https://api.github.com/repos/builtbybel/xd-AntiSpy/contents/languages";

            // Set User-Agent headers for GitHub
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "xd-AntiSpyLM");

            try
            {
                // Fetch the directory listing from GitHub
                var response = await httpClient.GetStringAsync(apiUrl);

                // Parse the JSON response
                var items = JArray.Parse(response);

                // Extract language directory names
                var languages = new List<string> { "en - English (default)" }; // Add English statically
                foreach (var item in items)
                {
                    if (item["type"].ToString() == "dir")
                    {
                        string language = item["name"].ToString();
                        if (language != "en") // Avoid adding English again
                        {
                            if (languageNames.TryGetValue(language, out string languageName))
                            {
                                languages.Add($"{language} - {languageName}");
                            }
                            else
                            {
                                languages.Add(language); // Fallback to just the code if name is not found
                            }
                        }
                    }
                }

                // Get installed languages
                var installedLanguages = GetInstalledLanguages();

                // Bind the list of languages to our CheckedListBox
                checkedListBoxLanguages.Items.Clear();
                foreach (var language in languages)
                {
                    string languageCode = language.Split(' ')[0];
                    if (installedLanguages.Contains(languageCode))
                    {
                        // Append "(installed)" to installed languages
                        checkedListBoxLanguages.Items.Add(language + " (installed)", false);
                    }
                    else
                    {
                        checkedListBoxLanguages.Items.Add(language, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading languages: " + ex.Message);
            }
            finally
            {
                this.Text = "Language Manager";
            }
        }

        private List<string> GetInstalledLanguages()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var installedLanguages = new List<string>();

            foreach (var directory in Directory.GetDirectories(appDirectory))
            {
                string dirName = new DirectoryInfo(directory).Name;
                if (languageNames.ContainsKey(dirName))
                {
                    installedLanguages.Add(dirName);
                }
            }

            return installedLanguages;
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            // Check if exactly one language is selected
            if (checkedListBoxLanguages.CheckedItems.Count != 1)
            {
                MessageBox.Show("Please select exactly one language.");
                return;
            }

            // Get the selected language
            string selectedLanguageItem = checkedListBoxLanguages.CheckedItems[0].ToString();
            string selectedLanguageCode = selectedLanguageItem.Split(' ')[0]; // Extract the lang code

            // Handle the "English" case separately
            if (selectedLanguageCode == "en")
            {
                MessageBox.Show("To activate English, please manually delete your current language files and restart the application.");
                return;
            }

            // URL to download the language file
            string downloadUrl = $"https://github.com/builtbybel/xd-AntiSpy/raw/main/languages/{selectedLanguageCode}/xd-AntiSpy.resources.dll";
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string languageDirectory = Path.Combine(appDirectory, selectedLanguageCode);
            string destinationFilePath = Path.Combine(languageDirectory, "xd-AntiSpy.resources.dll");

            try
            {
                // Ensure the language directory does not exist before downloading
                if (Directory.Exists(languageDirectory))
                {
                    Directory.Delete(languageDirectory, true);
                }

                // Create the language directory
                Directory.CreateDirectory(languageDirectory);

                // Download the language file
                using (var client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(new Uri(downloadUrl), destinationFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading or installing the language file: " + ex.Message);
                return;
            }

            // Restart the application to apply the new language
            Application.Restart();
        }

        private void linkTranslate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => Process.Start("https://github.com/builtbybel/xd-AntiSpy/discussions/12#discussioncomment-10012049");
    }
}