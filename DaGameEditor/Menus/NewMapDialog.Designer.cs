namespace DaGameEditor.Menus
{
    partial class NewMapDialog
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
            this.numericMapWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericMapHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericTileWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericTileHeight = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericMapWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // numericMapWidth
            // 
            this.numericMapWidth.Location = new System.Drawing.Point(102, 18);
            this.numericMapWidth.Name = "numericMapWidth";
            this.numericMapWidth.Size = new System.Drawing.Size(120, 20);
            this.numericMapWidth.TabIndex = 0;
            this.numericMapWidth.Enter += new System.EventHandler(this.numericUpDown_Enter);
            this.numericMapWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Map Height";
            // 
            // numericMapHeight
            // 
            this.numericMapHeight.Location = new System.Drawing.Point(102, 44);
            this.numericMapHeight.Name = "numericMapHeight";
            this.numericMapHeight.Size = new System.Drawing.Size(120, 20);
            this.numericMapHeight.TabIndex = 2;
            this.numericMapHeight.Enter += new System.EventHandler(this.numericUpDown_Enter);
            this.numericMapHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tile Width";
            // 
            // numericTileWidth
            // 
            this.numericTileWidth.Location = new System.Drawing.Point(102, 70);
            this.numericTileWidth.Name = "numericTileWidth";
            this.numericTileWidth.Size = new System.Drawing.Size(120, 20);
            this.numericTileWidth.TabIndex = 4;
            this.numericTileWidth.Enter += new System.EventHandler(this.numericUpDown_Enter);
            this.numericTileWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tile Height";
            // 
            // numericTileHeight
            // 
            this.numericTileHeight.Location = new System.Drawing.Point(102, 96);
            this.numericTileHeight.Name = "numericTileHeight";
            this.numericTileHeight.Size = new System.Drawing.Size(120, 20);
            this.numericTileHeight.TabIndex = 6;
            this.numericTileHeight.Enter += new System.EventHandler(this.numericUpDown_Enter);
            this.numericTileHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown_KeyPress);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(66, 136);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(147, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // NewMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 176);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericTileHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericTileWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericMapHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericMapWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewMapDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewMapDialog";
            ((System.ComponentModel.ISupportInitialize)(this.numericMapWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTileHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericMapWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericMapHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericTileWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericTileHeight;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}