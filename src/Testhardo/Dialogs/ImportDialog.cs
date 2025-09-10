using ReaLTaiizor.Forms;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Testhardo;

public partial class ImportDialog : MaterialForm
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Uri? SwaggerUri { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string? BaseUrl => SwaggerUri == null ? null : SwaggerUrlRegex().Replace(SwaggerUri.AbsoluteUri, string.Empty);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public OpenApiDocument? OpenApiDocument { get; set; }

    public ImportDialog()
    {
        InitializeComponent();
    }

    private void ImportDialog_Load(object sender, EventArgs e)
    {

    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;

        Close();
    }

    private async void ImportButton_Click(object sender, EventArgs e)
    {
        ErrorLabel.Text = string.Empty;

        Enabled = false;
        Cursor = Cursors.WaitCursor;

        await LoadSwaggerDocumentAsync();

        Enabled = true;
        Cursor = Cursors.Default;

        if (OpenApiDocument == null)
            return;

        DialogResult = DialogResult.OK;

        Close();
    }

    private void SwaggerUrlTextBox_TextChanged(object sender, EventArgs e)
    {
        ImportButton.Enabled = Uri.TryCreate(SwaggerUrlTextBox.Text, UriKind.Absolute, out var uri);

        SwaggerUri = uri;
    }

    private async Task LoadSwaggerDocumentAsync()
    {
        if (SwaggerUri == null)
            return;

        try
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(SwaggerUri);

            response.EnsureSuccessStatusCode();

            OpenApiDocument = await response.Content.ReadFromJsonAsync<OpenApiDocument>();
        }
        catch (HttpRequestException)
        {
            ErrorLabel.Text = "Error fetching Swagger document";
        }
        catch (JsonException)
        {
            ErrorLabel.Text = "Error parsing Swagger document";
        }
        catch (Exception)
        {
            ErrorLabel.Text = "Unexpected error";
        }
    }

    [GeneratedRegex(@"/swagger/[^/]+/swagger\.json$")]
    public static partial Regex SwaggerUrlRegex();
}
