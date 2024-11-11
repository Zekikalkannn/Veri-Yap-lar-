namespace InfixPrefixPostfixConverter
{
    partial class Form1
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizle
        /// </summary>
        /// <param name="disposing">Yönetilen kaynakları elden çıkar doğruysa; aksi halde false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli yöntem - bu yöntemin
        /// içeriğini kod düzenleyici ile değiştirmeyin
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInfix = new System.Windows.Forms.TextBox();
            this.btnPostfix = new System.Windows.Forms.Button();
            this.btnPrefix = new System.Windows.Forms.Button();
            this.lblPostfix = new System.Windows.Forms.Label();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInfix
            // 
            this.txtInfix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtInfix.Location = new System.Drawing.Point(50, 30);
            this.txtInfix.Name = "txtInfix";
            this.txtInfix.Size = new System.Drawing.Size(400, 27);
            this.txtInfix.TabIndex = 0;
            // 
            // btnPostfix
            // 
            this.btnPostfix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPostfix.Location = new System.Drawing.Point(50, 80);
            this.btnPostfix.Name = "btnPostfix";
            this.btnPostfix.Size = new System.Drawing.Size(155, 57);
            this.btnPostfix.TabIndex = 1;
            this.btnPostfix.Text = "Postfix\'e Dönüştür";
            this.btnPostfix.UseVisualStyleBackColor = true;
            this.btnPostfix.Click += new System.EventHandler(this.btnPostfix_Click);
            // 
            // btnPrefix
            // 
            this.btnPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPrefix.Location = new System.Drawing.Point(300, 80);
            this.btnPrefix.Name = "btnPrefix";
            this.btnPrefix.Size = new System.Drawing.Size(150, 59);
            this.btnPrefix.TabIndex = 2;
            this.btnPrefix.Text = "Prefix\'e Dönüştür";
            this.btnPrefix.UseVisualStyleBackColor = true;
            this.btnPrefix.Click += new System.EventHandler(this.btnPrefix_Click);
            // 
            // lblPostfix
            // 
            this.lblPostfix.AutoSize = true;
            this.lblPostfix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPostfix.Location = new System.Drawing.Point(50, 140);
            this.lblPostfix.Name = "lblPostfix";
            this.lblPostfix.Size = new System.Drawing.Size(74, 22);
            this.lblPostfix.TabIndex = 3;
            this.lblPostfix.Text = "Postfix: ";
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPrefix.Location = new System.Drawing.Point(50, 180);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(66, 22);
            this.lblPrefix.TabIndex = 4;
            this.lblPrefix.Text = "Prefix: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.lblPrefix);
            this.Controls.Add(this.lblPostfix);
            this.Controls.Add(this.btnPrefix);
            this.Controls.Add(this.btnPostfix);
            this.Controls.Add(this.txtInfix);
            this.Name = "Form1";
            this.Text = "Infix to Prefix and Postfix Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfix;
        private System.Windows.Forms.Button btnPostfix;
        private System.Windows.Forms.Button btnPrefix;
        private System.Windows.Forms.Label lblPostfix;
        private System.Windows.Forms.Label lblPrefix;
    }
}


