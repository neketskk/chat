
namespace Client
{
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
            this.SendButton = new System.Windows.Forms.Button();
            this.OutInfo = new System.Windows.Forms.TextBox();
            this.InputInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(14, 307);
            this.SendButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(278, 55);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Отправить";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // OutInfo
            // 
            this.OutInfo.Location = new System.Drawing.Point(14, 16);
            this.OutInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OutInfo.Multiline = true;
            this.OutInfo.Name = "OutInfo";
            this.OutInfo.ReadOnly = true;
            this.OutInfo.Size = new System.Drawing.Size(341, 211);
            this.OutInfo.TabIndex = 5;
            // 
            // InputInfo
            // 
            this.InputInfo.Location = new System.Drawing.Point(14, 235);
            this.InputInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InputInfo.Multiline = true;
            this.InputInfo.Name = "InputInfo";
            this.InputInfo.Size = new System.Drawing.Size(278, 65);
            this.InputInfo.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 371);
            this.Controls.Add(this.InputInfo);
            this.Controls.Add(this.OutInfo);
            this.Controls.Add(this.SendButton);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox OutInfo;
        private System.Windows.Forms.TextBox InputInfo;
    }
}

