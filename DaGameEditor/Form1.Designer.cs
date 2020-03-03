namespace DaGameEditor
{
    partial class Form1
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
            this.monoGameEditor1 = new DaGameEditor.MonoGameEditor();
            this.SuspendLayout();
            // 
            // monoGameEditor1
            // 
            this.monoGameEditor1.Location = new System.Drawing.Point(12, 12);
            this.monoGameEditor1.MouseHoverUpdatesOnly = false;
            this.monoGameEditor1.Name = "monoGameEditor1";
            this.monoGameEditor1.Size = new System.Drawing.Size(776, 426);
            this.monoGameEditor1.TabIndex = 0;
            this.monoGameEditor1.Text = "monoGameEditor1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monoGameEditor1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MonoGameEditor monoGameEditor1;
    }
}

