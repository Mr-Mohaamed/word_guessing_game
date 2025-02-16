namespace GameExplorer.Components
{
    partial class RoomComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            roomNameLabel = new Label();
            gameTypeLabel = new Label();
            joinBtn = new Button();
            playersCountLabel = new Label();
            SuspendLayout();
            // 
            // roomNameLabel
            // 
            roomNameLabel.AutoSize = true;
            roomNameLabel.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roomNameLabel.Location = new Point(23, 42);
            roomNameLabel.Name = "roomNameLabel";
            roomNameLabel.Size = new Size(130, 26);
            roomNameLabel.TabIndex = 0;
            roomNameLabel.Text = "Room Name";
            // 
            // gameTypeLabel
            // 
            gameTypeLabel.AutoSize = true;
            gameTypeLabel.Font = new Font("Showcard Gothic", 16F);
            gameTypeLabel.Location = new Point(8, 9);
            gameTypeLabel.Name = "gameTypeLabel";
            gameTypeLabel.Size = new Size(161, 33);
            gameTypeLabel.TabIndex = 1;
            gameTypeLabel.Text = "Game Type";
            // 
            // joinBtn
            // 
            joinBtn.BackColor = SystemColors.ActiveCaptionText;
            joinBtn.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            joinBtn.ForeColor = SystemColors.HighlightText;
            joinBtn.Location = new Point(40, 127);
            joinBtn.Name = "joinBtn";
            joinBtn.Size = new Size(96, 46);
            joinBtn.TabIndex = 2;
            joinBtn.Text = "Join";
            joinBtn.UseVisualStyleBackColor = false;
            // 
            // playersCountLabel
            // 
            playersCountLabel.AutoSize = true;
            playersCountLabel.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playersCountLabel.Location = new Point(60, 87);
            playersCountLabel.Name = "playersCountLabel";
            playersCountLabel.Size = new Size(56, 37);
            playersCountLabel.TabIndex = 3;
            playersCountLabel.Text = "1/2";
            // 
            // Room
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(playersCountLabel);
            Controls.Add(joinBtn);
            Controls.Add(gameTypeLabel);
            Controls.Add(roomNameLabel);
            Name = "Room";
            Size = new Size(176, 176);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label roomNameLabel;
        private Label gameTypeLabel;
        private Button joinBtn;
        private Label playersCountLabel;
    }
}
