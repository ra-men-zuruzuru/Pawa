namespace PawaModoki
{
    partial class EditMenu
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
            this.buttonInEditMenuReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInEditMenuReturn
            // 
            this.buttonInEditMenuReturn.Location = new System.Drawing.Point(546, 424);
            this.buttonInEditMenuReturn.Name = "buttonInEditMenuReturn";
            this.buttonInEditMenuReturn.Size = new System.Drawing.Size(204, 39);
            this.buttonInEditMenuReturn.TabIndex = 10;
            this.buttonInEditMenuReturn.Text = "メインメニューに戻る";
            this.buttonInEditMenuReturn.UseVisualStyleBackColor = true;
            this.buttonInEditMenuReturn.Click += new System.EventHandler(this.buttonInEditMenuReturn_Click);
            // 
            // EditMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 544);
            this.Controls.Add(this.buttonInEditMenuReturn);
            this.Name = "EditMenu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditMenu";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonInEditMenuReturn;
    }
}