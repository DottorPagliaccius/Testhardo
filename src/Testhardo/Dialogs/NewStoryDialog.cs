using ReaLTaiizor.Forms;
using System.ComponentModel;
namespace Testhardo;

public partial class NewStoryDialog : MaterialForm
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string? NewName { get; set; }

    public NewStoryDialog(string uniqueName)
    {
        InitializeComponent();

        NameTextBox.Text = uniqueName;
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;

        Close();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        NewName = NameTextBox.Text;

        if (string.IsNullOrEmpty(NewName))
        {
            NameTextBox.ErrorMessage = "Name is required";
            return;
        }

        DialogResult = DialogResult.OK;

        Close();
    }
}
