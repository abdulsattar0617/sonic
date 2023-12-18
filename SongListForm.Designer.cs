namespace Sonic_Music_Player
{
    partial class SongListForm
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
            songSelectListPanel = new Panel();
            selectAllCB = new CheckBox();
            label1 = new Label();
            nameLabel = new Label();
            poundSymbolLabel = new Label();
            headingLabel = new Label();
            saveButton = new Button();
            tagLineLabel = new Label();
            horizontalLineLabel = new Label();
            SetPlaylistCB = new CheckBox();
            songSelectListPanel.SuspendLayout();
            SuspendLayout();
            // 
            // songSelectListPanel
            // 
            songSelectListPanel.AutoScroll = true;
            songSelectListPanel.BorderStyle = BorderStyle.FixedSingle;
            songSelectListPanel.Controls.Add(SetPlaylistCB);
            songSelectListPanel.Controls.Add(selectAllCB);
            songSelectListPanel.Controls.Add(label1);
            songSelectListPanel.Controls.Add(nameLabel);
            songSelectListPanel.Controls.Add(poundSymbolLabel);
            songSelectListPanel.Location = new Point(22, 99);
            songSelectListPanel.Name = "songSelectListPanel";
            songSelectListPanel.Size = new Size(370, 250);
            songSelectListPanel.TabIndex = 1;
            // 
            // selectAllCB
            // 
            selectAllCB.AutoSize = true;
            selectAllCB.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            selectAllCB.ForeColor = Color.DodgerBlue;
            selectAllCB.Location = new Point(278, 7);
            selectAllCB.Name = "selectAllCB";
            selectAllCB.Size = new Size(72, 17);
            selectAllCB.TabIndex = 10;
            selectAllCB.Text = "Select All";
            selectAllCB.UseVisualStyleBackColor = true;
            selectAllCB.CheckedChanged += selectAllCB_CheckedChanged;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 25);
            label1.Name = "label1";
            label1.Size = new Size(350, 2);
            label1.TabIndex = 9;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            nameLabel.Location = new Point(50, 5);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(44, 17);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "Name";
            // 
            // poundSymbolLabel
            // 
            poundSymbolLabel.AutoSize = true;
            poundSymbolLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            poundSymbolLabel.Location = new Point(16, 5);
            poundSymbolLabel.Name = "poundSymbolLabel";
            poundSymbolLabel.Size = new Size(16, 17);
            poundSymbolLabel.TabIndex = 7;
            poundSymbolLabel.Text = "#";
            // 
            // headingLabel
            // 
            headingLabel.AutoSize = true;
            headingLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            headingLabel.Location = new Point(12, 9);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(154, 37);
            headingLabel.TabIndex = 2;
            headingLabel.Text = "Add Songs";
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.Red;
            saveButton.BackgroundImageLayout = ImageLayout.None;
            saveButton.Cursor = Cursors.Hand;
            saveButton.FlatStyle = FlatStyle.Popup;
            saveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(302, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(90, 34);
            saveButton.TabIndex = 3;
            saveButton.Text = "Done";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // tagLineLabel
            // 
            tagLineLabel.AutoSize = true;
            tagLineLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tagLineLabel.Location = new Point(12, 79);
            tagLineLabel.Name = "tagLineLabel";
            tagLineLabel.Size = new Size(168, 17);
            tagLineLabel.TabIndex = 4;
            tagLineLabel.Text = "Select songs from the list :";
            // 
            // horizontalLineLabel
            // 
            horizontalLineLabel.BorderStyle = BorderStyle.FixedSingle;
            horizontalLineLabel.FlatStyle = FlatStyle.Flat;
            horizontalLineLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            horizontalLineLabel.Location = new Point(12, 45);
            horizontalLineLabel.Name = "horizontalLineLabel";
            horizontalLineLabel.Size = new Size(150, 2);
            horizontalLineLabel.TabIndex = 5;
            // 
            // SetPlaylistCB
            // 
            SetPlaylistCB.AutoSize = true;
            SetPlaylistCB.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            SetPlaylistCB.ForeColor = Color.DodgerBlue;
            SetPlaylistCB.Location = new Point(192, 7);
            SetPlaylistCB.Name = "SetPlaylistCB";
            SetPlaylistCB.Size = new Size(80, 17);
            SetPlaylistCB.TabIndex = 11;
            SetPlaylistCB.Text = "Set Playlist";
            SetPlaylistCB.UseVisualStyleBackColor = true;
            // 
            // SongListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(414, 371);
            Controls.Add(horizontalLineLabel);
            Controls.Add(tagLineLabel);
            Controls.Add(saveButton);
            Controls.Add(headingLabel);
            Controls.Add(songSelectListPanel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SongListForm";
            Text = "...";
            Load += SongListForm_Load;
            songSelectListPanel.ResumeLayout(false);
            songSelectListPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel songSelectListPanel;
        private Label headingLabel;
        private Button saveButton;
        private Label tagLineLabel;
        private Label horizontalLineLabel;
        private Label label1;
        private Label nameLabel;
        private Label poundSymbolLabel;
        private CheckBox selectAllCB;
        private CheckBox SetPlaylistCB;
    }
}