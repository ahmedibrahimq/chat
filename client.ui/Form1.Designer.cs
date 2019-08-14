namespace client.ui
{
    partial class frm
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
            this.lstMsgs = new MaterialSkin.Controls.MaterialListView();
            this.cMsgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtMsg = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAttachFile = new MaterialSkin.Controls.MaterialFlatButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMsgs
            // 
            this.lstMsgs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMsgs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cMsgs});
            this.lstMsgs.Depth = 0;
            this.lstMsgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lstMsgs.FullRowSelect = true;
            this.lstMsgs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstMsgs.Location = new System.Drawing.Point(12, 77);
            this.lstMsgs.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lstMsgs.MouseState = MaterialSkin.MouseState.OUT;
            this.lstMsgs.Name = "lstMsgs";
            this.lstMsgs.OwnerDraw = true;
            this.lstMsgs.Size = new System.Drawing.Size(287, 380);
            this.lstMsgs.TabIndex = 3;
            this.lstMsgs.UseCompatibleStateImageBehavior = false;
            this.lstMsgs.View = System.Windows.Forms.View.Details;
            // 
            // cMsgs
            // 
            this.cMsgs.Text = "conversation";
            this.cMsgs.Width = 287;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(0, 457);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(311, 1);
            this.materialDivider1.TabIndex = 5;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(243, 463);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(56, 36);
            this.materialFlatButton1.TabIndex = 6;
            this.materialFlatButton1.Text = "send";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Depth = 0;
            this.txtMsg.Hint = "";
            this.txtMsg.Location = new System.Drawing.Point(12, 476);
            this.txtMsg.MaxLength = 32767;
            this.txtMsg.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.PasswordChar = '\0';
            this.txtMsg.SelectedText = "";
            this.txtMsg.SelectionLength = 0;
            this.txtMsg.SelectionStart = 0;
            this.txtMsg.Size = new System.Drawing.Size(222, 23);
            this.txtMsg.TabIndex = 7;
            this.txtMsg.TabStop = false;
            this.txtMsg.UseSystemPasswordChar = false;
            this.txtMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMsg_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::client.ui.Properties.Resources.attach;
            this.pictureBox1.Location = new System.Drawing.Point(262, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.AutoSize = true;
            this.btnAttachFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAttachFile.Depth = 0;
            this.btnAttachFile.Icon = null;
            this.btnAttachFile.Location = new System.Drawing.Point(196, 80);
            this.btnAttachFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAttachFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Primary = false;
            this.btnAttachFile.Size = new System.Drawing.Size(92, 36);
            this.btnAttachFile.TabIndex = 10;
            this.btnAttachFile.Text = "attach    .";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 511);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.lstMsgs);
            this.Name = "frm";
            this.Text = "chat client";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public MaterialSkin.Controls.MaterialListView lstMsgs;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private System.Windows.Forms.ColumnHeader cMsgs;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialFlatButton btnAttachFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

