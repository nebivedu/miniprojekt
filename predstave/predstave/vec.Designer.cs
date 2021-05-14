
namespace predstave
{
    partial class vec
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
            this.Ime = new System.Windows.Forms.Label();
            this.Zvrst = new System.Windows.Forms.Label();
            this.Datum = new System.Windows.Forms.Label();
            this.Opis = new System.Windows.Forms.Label();
            this.Lokacija = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Kraj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Ime
            // 
            this.Ime.AutoSize = true;
            this.Ime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ime.Location = new System.Drawing.Point(47, 66);
            this.Ime.Name = "Ime";
            this.Ime.Size = new System.Drawing.Size(79, 29);
            this.Ime.TabIndex = 0;
            this.Ime.Text = "label1";
            // 
            // Zvrst
            // 
            this.Zvrst.AutoSize = true;
            this.Zvrst.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Zvrst.Location = new System.Drawing.Point(47, 126);
            this.Zvrst.Name = "Zvrst";
            this.Zvrst.Size = new System.Drawing.Size(79, 29);
            this.Zvrst.TabIndex = 1;
            this.Zvrst.Text = "label2";
            // 
            // Datum
            // 
            this.Datum.AutoSize = true;
            this.Datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datum.Location = new System.Drawing.Point(47, 193);
            this.Datum.Name = "Datum";
            this.Datum.Size = new System.Drawing.Size(79, 29);
            this.Datum.TabIndex = 3;
            this.Datum.Text = "label3";
            // 
            // Opis
            // 
            this.Opis.AutoSize = true;
            this.Opis.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Opis.Location = new System.Drawing.Point(47, 256);
            this.Opis.Name = "Opis";
            this.Opis.Size = new System.Drawing.Size(79, 29);
            this.Opis.TabIndex = 2;
            this.Opis.Text = "label4";
            // 
            // Lokacija
            // 
            this.Lokacija.AutoSize = true;
            this.Lokacija.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lokacija.Location = new System.Drawing.Point(47, 314);
            this.Lokacija.Name = "Lokacija";
            this.Lokacija.Size = new System.Drawing.Size(79, 29);
            this.Lokacija.TabIndex = 4;
            this.Lokacija.Text = "label5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Uredi";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Kraj
            // 
            this.Kraj.AutoSize = true;
            this.Kraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kraj.Location = new System.Drawing.Point(47, 367);
            this.Kraj.Name = "Kraj";
            this.Kraj.Size = new System.Drawing.Size(79, 29);
            this.Kraj.TabIndex = 6;
            this.Kraj.Text = "label6";
            // 
            // vec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 619);
            this.Controls.Add(this.Kraj);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Lokacija);
            this.Controls.Add(this.Datum);
            this.Controls.Add(this.Opis);
            this.Controls.Add(this.Zvrst);
            this.Controls.Add(this.Ime);
            this.Name = "vec";
            this.Text = "vec";
            this.Load += new System.EventHandler(this.vec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Ime;
        private System.Windows.Forms.Label Zvrst;
        private System.Windows.Forms.Label Datum;
        private System.Windows.Forms.Label Opis;
        private System.Windows.Forms.Label Lokacija;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Kraj;
    }
}