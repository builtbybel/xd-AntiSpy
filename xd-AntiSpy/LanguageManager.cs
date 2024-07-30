using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using xdAntiSpy;

public class LanguageManager
{
    private readonly HttpClient httpClient;
    private readonly string appDirectory;

    public LanguageManager()
    {
        httpClient = new HttpClient();
        appDirectory = AppDomain.CurrentDomain.BaseDirectory;
    }

    public string GetOSLanguageCode()
    {
        var culture = CultureInfo.CurrentUICulture;
        return culture.TwoLetterISOLanguageName;
    }

    public async Task<bool> IsLanguageFileAvailable(string languageCode)
    {
        string apiUrl = $"https://api.github.com/repos/builtbybel/xd-AntiSpy/contents/languages/{languageCode}";

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "xd-AntiSpyLM");

        try
        {
            var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, apiUrl));
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error checking language availability: " + ex.Message);
            return false;
        }
    }

    public async Task CheckAndPromptForLanguage()
    {
        string osLanguageCode = GetOSLanguageCode();

        bool isInstalled = IsLanguageInstalled(osLanguageCode);

        if (!isInstalled)
        {
            bool isAvailable = await IsLanguageFileAvailable(osLanguageCode);
            if (isAvailable)
            {
                DialogResult result = MessageBox.Show(
                    "A language pack for your system language is available. Do you want to open the Language Manager to install it?",
                    "Language Pack Available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    ShowLanguageManager();
                }
            }
        }
    }

    public bool IsLanguageInstalled(string languageCode)
    {
        string languageDirectory = Path.Combine(appDirectory, languageCode);
        return Directory.Exists(languageDirectory);
    }

    public void ShowLanguageManager()
    {
        var languageManagerForm = new LangManagerForm();
        languageManagerForm.ShowDialog();
    }
}