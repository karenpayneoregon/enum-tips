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
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.CurrentButton = new System.Windows.Forms.Button();
            this.SetCurrentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoriesComboBox
            // 
            this.categoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Location = new System.Drawing.Point(42, 28);
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.Size = new System.Drawing.Size(253, 28);
            this.categoriesComboBox.TabIndex = 0;
            // 
            // CurrentButton
            // 
            this.CurrentButton.Location = new System.Drawing.Point(341, 28);
            this.CurrentButton.Name = "CurrentButton";
            this.CurrentButton.Size = new System.Drawing.Size(144, 29);
            this.CurrentButton.TabIndex = 1;
            this.CurrentButton.Text = "Current";
            this.CurrentButton.UseVisualStyleBackColor = true;
            this.CurrentButton.Click += new System.EventHandler(this.CurrentButton_Click);
            // 
            // SetCurrentButton
            // 
            this.SetCurrentButton.Location = new System.Drawing.Point(341, 73);
            this.SetCurrentButton.Name = "SetCurrentButton";
            this.SetCurrentButton.Size = new System.Drawing.Size(144, 29);
            this.SetCurrentButton.TabIndex = 2;
            this.SetCurrentButton.Text = "Set current";
            this.SetCurrentButton.UseVisualStyleBackColor = true;
            this.SetCurrentButton.Click += new System.EventHandler(this.SetCurrentButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.SetCurrentButton);
            this.Controls.Add(this.CurrentButton);
            this.Controls.Add(this.categoriesComboBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enum descriptions";
            this.ResumeLayout(false);

    }

    #endregion

    private ComboBox categoriesComboBox;
    private Button CurrentButton;
    private Button SetCurrentButton;
}
