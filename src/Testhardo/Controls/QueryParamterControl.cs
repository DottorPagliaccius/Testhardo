using System.ComponentModel;

namespace Testhardo;

public partial class QueryParameterControl : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string ParameterName
    {
        get { return NameLabel.Text; }
        set { NameLabel.Text = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string ParameterType
    {
        get { return TypelLabel.Text; }
        set { TypelLabel.Text = value; }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool IsMandatory
    {
        get { return AsteriskLabel.Visible; }
        set
        {
            AsteriskLabel.Visible = value;

            if (!value)
            {
                NameLabel.Location = new Point(3, NameLabel.Location.Y);
            }
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Value
    {
        get { return ValueTextBox.Text; }
        set { ValueTextBox.Text = value; }
    }

    public event EventHandler? Modified;

    public QueryParameterControl(string name, string type, bool isMandatory, string value = "")
    {
        InitializeComponent();

        ParameterName = name;
        ParameterType = type;
        IsMandatory = isMandatory;
        Value = value;
    }

    private void ValueTextBox_Leave(object sender, EventArgs e)
    {
        Modified?.Invoke(this, EventArgs.Empty);
    }
}
