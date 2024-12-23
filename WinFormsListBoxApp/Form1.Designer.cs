namespace WinFormsListBoxApp;

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
        listBox1 = new ListBox();
        LoadButton = new Button();
        SaveButton = new Button();
        FreshStartButton = new Button();
        SuspendLayout();
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(0, 0);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(455, 244);
        listBox1.TabIndex = 0;
        // 
        // LoadButton
        // 
        LoadButton.Location = new Point(12, 266);
        LoadButton.Name = "LoadButton";
        LoadButton.Size = new Size(94, 29);
        LoadButton.TabIndex = 1;
        LoadButton.Text = "Load";
        LoadButton.UseVisualStyleBackColor = true;
        LoadButton.Click += LoadButton_Click;
        // 
        // SaveButton
        // 
        SaveButton.Location = new Point(112, 266);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(94, 29);
        SaveButton.TabIndex = 2;
        SaveButton.Text = "Save";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // FreshStartButton
        // 
        FreshStartButton.Location = new Point(212, 266);
        FreshStartButton.Name = "FreshStartButton";
        FreshStartButton.Size = new Size(94, 29);
        FreshStartButton.TabIndex = 3;
        FreshStartButton.Text = "Reset";
        FreshStartButton.UseVisualStyleBackColor = true;
        FreshStartButton.Click += FreshStartButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(459, 326);
        Controls.Add(FreshStartButton);
        Controls.Add(SaveButton);
        Controls.Add(LoadButton);
        Controls.Add(listBox1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Save/Load from file";
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBox1;
    private Button LoadButton;
    private Button SaveButton;
    private Button FreshStartButton;
}
