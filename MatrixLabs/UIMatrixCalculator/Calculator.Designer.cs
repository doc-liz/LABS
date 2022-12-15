using UIMatrixCalculator.Components;

namespace UIMatrixCalculator;

partial class Calculator
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
            this.SetSizeButton = new UIMatrixCalculator.Components.SetSizeButton();
            this.SetSizeTestBox = new UIMatrixCalculator.Components.SetSizeTestBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SetSizeButton
            // 
            this.SetSizeButton.Location = new System.Drawing.Point(100, 0);
            this.SetSizeButton.Name = "SetSizeButton";
            this.SetSizeButton.Size = new System.Drawing.Size(50, 25);
            this.SetSizeButton.TabIndex = 0;
            this.SetSizeButton.Text = "SetSize";
            this.SetSizeButton.Click += new System.EventHandler(this.SetSizeClick);
            // 
            // SetSizeTestBox
            // 
            this.SetSizeTestBox.Location = new System.Drawing.Point(0, 0);
            this.SetSizeTestBox.Name = "SetSizeTestBox";
            this.SetSizeTestBox.Size = new System.Drawing.Size(50, 23);
            this.SetSizeTestBox.TabIndex = 1;
            this.SetSizeTestBox.Text = "SetSize";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "int",
            "float",
            "rational",
            "double"});
            this.comboBox1.Location = new System.Drawing.Point(667, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SetSizeButton);
            this.Controls.Add(this.SetSizeTestBox);
            this.Name = "Calculator";
            this.Text = "MatrixCalculator";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion

    protected ComboBox comboBox1;
    protected SetSizeTestBox SetSizeTestBox;
    protected SetSizeButton SetSizeButton;
}