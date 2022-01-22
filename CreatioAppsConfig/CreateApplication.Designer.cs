namespace CreatioAppsConfig
{
    partial class CreateApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VersionBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // VersionBox
            // 
            this.VersionBox.FormattingEnabled = true;
            this.VersionBox.Location = new System.Drawing.Point(12, 24);
            this.VersionBox.Name = "VersionBox";
            this.VersionBox.Size = new System.Drawing.Size(776, 23);
            this.VersionBox.TabIndex = 0;
            // 
            // CreateApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VersionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateApplication";
            this.Text = "CreateApplication";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox VersionBox;
    }
}