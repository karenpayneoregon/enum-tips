namespace EnumGetDescriptions;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        categoriesComboBox = new ComboBox();
        CurrentButton = new Button();
        SetCurrentButton = new Button();
        SuspendLayout();
        // 
        // categoriesComboBox
        // 
        categoriesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        categoriesComboBox.FormattingEnabled = true;
        categoriesComboBox.Location = new Point(42, 28);
        categoriesComboBox.Name = "categoriesComboBox";
        categoriesComboBox.Size = new Size(253, 28);
        categoriesComboBox.TabIndex = 0;
        // 
        // CurrentButton
        // 
        CurrentButton.Location = new Point(341, 28);
        CurrentButton.Name = "CurrentButton";
        CurrentButton.Size = new Size(144, 29);
        CurrentButton.TabIndex = 1;
        CurrentButton.Text = "Current";
        CurrentButton.UseVisualStyleBackColor = true;
        CurrentButton.Click += CurrentButton_Click;
        // 
        // SetCurrentButton
        // 
        SetCurrentButton.Location = new Point(341, 73);
        SetCurrentButton.Name = "SetCurrentButton";
        SetCurrentButton.Size = new Size(144, 29);
        SetCurrentButton.TabIndex = 2;
        SetCurrentButton.Text = "Set current";
        SetCurrentButton.UseVisualStyleBackColor = true;
        SetCurrentButton.Click += SetCurrentButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(497, 230);
        Controls.Add(SetCurrentButton);
        Controls.Add(CurrentButton);
        Controls.Add(categoriesComboBox);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Enum descriptions";
        ResumeLayout(false);

    }

    #endregion

    private ComboBox categoriesComboBox;
    private Button CurrentButton;
    private Button SetCurrentButton;
}
