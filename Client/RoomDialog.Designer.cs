namespace GameExplorer.Client
{
    partial class RoomDialog
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
            roomsContainer = new FlowLayoutPanel();
            roomsHeader = new Label();
            createRoomBtn = new Button();
            joinRoomBtn = new Button();
            SuspendLayout();
            // 
            // roomsContainer
            // 
            roomsContainer.AutoSize = true;
            roomsContainer.BackColor = SystemColors.ActiveCaptionText;
            roomsContainer.Location = new Point(-9, 84);
            roomsContainer.Name = "roomsContainer";
            roomsContainer.Size = new Size(819, 292);
            roomsContainer.TabIndex = 0;
            // 
            // roomsHeader
            // 
            roomsHeader.AutoSize = true;
            roomsHeader.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roomsHeader.ForeColor = SystemColors.ControlLightLight;
            roomsHeader.Location = new Point(169, 16);
            roomsHeader.Name = "roomsHeader";
            roomsHeader.Size = new Size(444, 60);
            roomsHeader.TabIndex = 0;
            roomsHeader.Text = "No Room Created Yet";
            // 
            // createRoomBtn
            // 
            createRoomBtn.BackColor = SystemColors.ActiveCaptionText;
            createRoomBtn.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createRoomBtn.ForeColor = SystemColors.ButtonHighlight;
            createRoomBtn.Location = new Point(416, 391);
            createRoomBtn.Name = "createRoomBtn";
            createRoomBtn.Size = new Size(119, 43);
            createRoomBtn.TabIndex = 3;
            createRoomBtn.Text = "Create";
            createRoomBtn.UseVisualStyleBackColor = false;
            createRoomBtn.Click += createRoomBtn_Click;
            // 
            // joinRoomBtn
            // 
            joinRoomBtn.BackColor = SystemColors.ActiveCaptionText;
            joinRoomBtn.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            joinRoomBtn.ForeColor = SystemColors.ButtonHighlight;
            joinRoomBtn.Location = new Point(230, 391);
            joinRoomBtn.Name = "joinRoomBtn";
            joinRoomBtn.Size = new Size(119, 43);
            joinRoomBtn.TabIndex = 3;
            joinRoomBtn.Text = "Join";
            joinRoomBtn.UseVisualStyleBackColor = false;
            // 
            // RoomDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(joinRoomBtn);
            Controls.Add(createRoomBtn);
            Controls.Add(roomsHeader);
            Controls.Add(roomsContainer);
            Name = "RoomDialog";
            Text = "RoomDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel roomsContainer;
        private Label roomsHeader;
        private Button createRoomBtn;
        private Button joinRoomBtn;
    }
}