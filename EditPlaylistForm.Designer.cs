namespace Sonic_Music_Player
{
    partial class EditPlaylistForm
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
            playlistNameTB = new TextBox();
            editDetailsLabel = new Label();
            termsAndConditionRichTB = new RichTextBox();
            nameLabel = new Label();
            saveButton = new Button();
            choosePictureLabel = new Label();
            playlistCoverImagePB = new PictureBox();
            warningMessageLabel = new Label();
            editSongListButton = new Button();
            ((System.ComponentModel.ISupportInitialize)playlistCoverImagePB).BeginInit();
            SuspendLayout();
            // 
            // playlistNameTB
            // 
            playlistNameTB.BackColor = Color.Black;
            playlistNameTB.BorderStyle = BorderStyle.FixedSingle;
            playlistNameTB.Cursor = Cursors.IBeam;
            playlistNameTB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            playlistNameTB.ForeColor = Color.White;
            playlistNameTB.Location = new Point(180, 138);
            playlistNameTB.Name = "playlistNameTB";
            playlistNameTB.PlaceholderText = "Enter playlist name here";
            playlistNameTB.Size = new Size(253, 29);
            playlistNameTB.TabIndex = 1;
            playlistNameTB.Text = "My Playlsit #1";
            playlistNameTB.TextChanged += playlistNameTB_TextChanged;
            // 
            // editDetailsLabel
            // 
            editDetailsLabel.AutoSize = true;
            editDetailsLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            editDetailsLabel.ForeColor = Color.White;
            editDetailsLabel.Location = new Point(12, 9);
            editDetailsLabel.Name = "editDetailsLabel";
            editDetailsLabel.Size = new Size(160, 37);
            editDetailsLabel.TabIndex = 2;
            editDetailsLabel.Text = "Edit details";
            // 
            // termsAndConditionRichTB
            // 
            termsAndConditionRichTB.BackColor = Color.Black;
            termsAndConditionRichTB.BorderStyle = BorderStyle.None;
            termsAndConditionRichTB.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            termsAndConditionRichTB.ForeColor = Color.White;
            termsAndConditionRichTB.Location = new Point(15, 309);
            termsAndConditionRichTB.Name = "termsAndConditionRichTB";
            termsAndConditionRichTB.ReadOnly = true;
            termsAndConditionRichTB.ScrollBars = RichTextBoxScrollBars.None;
            termsAndConditionRichTB.Size = new Size(418, 40);
            termsAndConditionRichTB.TabIndex = 3;
            termsAndConditionRichTB.TabStop = false;
            termsAndConditionRichTB.Text = "By Proceeding, you agree to Give Sonic access to the image you choose to upload. Please make sure you have rights to upload the image.";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.ForeColor = Color.White;
            nameLabel.Location = new Point(171, 105);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(97, 30);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "- Name -";
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.White;
            saveButton.Cursor = Cursors.Hand;
            saveButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            saveButton.ForeColor = Color.Black;
            saveButton.Location = new Point(313, 263);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(120, 40);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // choosePictureLabel
            // 
            choosePictureLabel.AutoSize = true;
            choosePictureLabel.BackColor = Color.Transparent;
            choosePictureLabel.FlatStyle = FlatStyle.Flat;
            choosePictureLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            choosePictureLabel.ForeColor = Color.White;
            choosePictureLabel.Location = new Point(20, 210);
            choosePictureLabel.Name = "choosePictureLabel";
            choosePictureLabel.Size = new Size(139, 25);
            choosePictureLabel.TabIndex = 6;
            choosePictureLabel.Text = "Choose Picture";
            choosePictureLabel.Visible = false;
            // 
            // playlistCoverImagePB
            // 
            playlistCoverImagePB.BackgroundImageLayout = ImageLayout.Zoom;
            playlistCoverImagePB.Cursor = Cursors.Hand;
            playlistCoverImagePB.Image = Properties.Resources.playlist_cover_image;
            playlistCoverImagePB.Location = new Point(15, 105);
            playlistCoverImagePB.Name = "playlistCoverImagePB";
            playlistCoverImagePB.Size = new Size(150, 150);
            playlistCoverImagePB.SizeMode = PictureBoxSizeMode.Zoom;
            playlistCoverImagePB.TabIndex = 1;
            playlistCoverImagePB.TabStop = false;
            playlistCoverImagePB.Click += playlistCoverImagePB_Click;
            playlistCoverImagePB.MouseEnter += playlistCoverImagePB_MouseEnter;
            playlistCoverImagePB.MouseLeave += playlistCoverImagePB_MouseLeave;
            // 
            // warningMessageLabel
            // 
            warningMessageLabel.AutoSize = true;
            warningMessageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            warningMessageLabel.ForeColor = Color.Red;
            warningMessageLabel.Location = new Point(130, 60);
            warningMessageLabel.Name = "warningMessageLabel";
            warningMessageLabel.Size = new Size(172, 21);
            warningMessageLabel.TabIndex = 7;
            warningMessageLabel.Text = "You can't use comma ','";
            warningMessageLabel.Visible = false;
            // 
            // editSongListButton
            // 
            editSongListButton.BackColor = Color.Black;
            editSongListButton.Cursor = Cursors.Hand;
            editSongListButton.FlatStyle = FlatStyle.Flat;
            editSongListButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            editSongListButton.ForeColor = Color.White;
            editSongListButton.Location = new Point(180, 190);
            editSongListButton.Name = "editSongListButton";
            editSongListButton.Size = new Size(166, 34);
            editSongListButton.TabIndex = 8;
            editSongListButton.Text = "Edit song list";
            editSongListButton.UseVisualStyleBackColor = false;
            editSongListButton.Click += editSongListButton_Click;
            // 
            // EditPlaylistForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            ClientSize = new Size(454, 361);
            Controls.Add(editSongListButton);
            Controls.Add(warningMessageLabel);
            Controls.Add(choosePictureLabel);
            Controls.Add(saveButton);
            Controls.Add(playlistNameTB);
            Controls.Add(nameLabel);
            Controls.Add(termsAndConditionRichTB);
            Controls.Add(editDetailsLabel);
            Controls.Add(playlistCoverImagePB);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "EditPlaylistForm";
            Load += EditPlaylistForm_Load;
            ((System.ComponentModel.ISupportInitialize)playlistCoverImagePB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox playlistNameTB;
        private Label editDetailsLabel;
        private RichTextBox termsAndConditionRichTB;
        private Label nameLabel;
        private Button saveButton;
        private Label choosePictureLabel;
        private PictureBox playlistCoverImagePB;
        private Label warningMessageLabel;
        private Button editSongListButton;
    }
}