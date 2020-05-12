namespace DaGameEditor.Menus
{
    partial class EditTilesetDialog
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
            this.tilesetPreviewer = new DaGameEditor.Controls.TilesetPreviewer();
            this.buttonGenerateFrames = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tilesetPreviewer
            // 
            this.tilesetPreviewer.AutoScroll = true;
            this.tilesetPreviewer.Location = new System.Drawing.Point(12, 12);
            this.tilesetPreviewer.Name = "tilesetPreviewer";
            this.tilesetPreviewer.Size = new System.Drawing.Size(776, 386);
            this.tilesetPreviewer.TabIndex = 0;
            this.tilesetPreviewer.Tileset = null;
            // 
            // buttonGenerateFrames
            // 
            this.buttonGenerateFrames.Location = new System.Drawing.Point(12, 406);
            this.buttonGenerateFrames.Name = "buttonGenerateFrames";
            this.buttonGenerateFrames.Size = new System.Drawing.Size(134, 32);
            this.buttonGenerateFrames.TabIndex = 1;
            this.buttonGenerateFrames.Text = "Generate Frames";
            this.buttonGenerateFrames.UseVisualStyleBackColor = true;
            this.buttonGenerateFrames.Click += new System.EventHandler(this.buttonGenerateFrames_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(704, 406);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 32);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(614, 406);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(84, 32);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // EditTilesetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGenerateFrames);
            this.Controls.Add(this.tilesetPreviewer);
            this.Name = "EditTilesetDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditTilesetDialog";
            this.Load += new System.EventHandler(this.EditTilesetDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TilesetPreviewer tilesetPreviewer;
        private System.Windows.Forms.Button buttonGenerateFrames;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}