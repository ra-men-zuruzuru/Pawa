namespace PawaModoki
{
    partial class FormStartMenu
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(319, 207);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(172, 39);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "ゲームをはじめる";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(319, 282);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(172, 39);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "エディット";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Location = new System.Drawing.Point(616, 399);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(172, 39);
            this.buttonEnd.TabIndex = 2;
            this.buttonEnd.Text = "おわる";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // FormStartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNewGame);
            this.Location = new System.Drawing.Point(100, 0);
            this.Name = "FormStartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "スタートメニュー";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonEnd;
    }
}

