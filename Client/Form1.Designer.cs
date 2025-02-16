namespace GameExplorer
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
            headerLabel = new Label();
            joinBtn = new Button();
            nameTextBox = new TextBox();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.BackColor = SystemColors.ActiveCaptionText;
            headerLabel.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.ForeColor = SystemColors.ControlLightLight;
            headerLabel.Location = new Point(280, 113);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(231, 59);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Connect";
            // 
            // joinBtn
            // 
            joinBtn.BackColor = SystemColors.ActiveCaptionText;
            joinBtn.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            joinBtn.ForeColor = SystemColors.ButtonHighlight;
            joinBtn.Location = new Point(323, 256);
            joinBtn.Name = "joinBtn";
            joinBtn.Size = new Size(142, 56);
            joinBtn.TabIndex = 2;
            joinBtn.Text = "Join";
            joinBtn.UseVisualStyleBackColor = false;
            joinBtn.Click += joinBtn_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(280, 206);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "Put Your Name ... !";
            nameTextBox.Size = new Size(231, 27);
            nameTextBox.TabIndex = 3;
            nameTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(nameTextBox);
            Controls.Add(joinBtn);
            Controls.Add(headerLabel);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Button joinBtn;
        private TextBox nameTextBox;
    }
}
