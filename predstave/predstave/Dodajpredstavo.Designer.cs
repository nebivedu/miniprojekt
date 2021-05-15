
namespace predstave
{
    partial class Dodajpredstavo
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
            this.ime = new System.Windows.Forms.TextBox();
            this.zvrst = new System.Windows.Forms.TextBox();
            this.datum = new System.Windows.Forms.TextBox();
            this.lokacija = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ime
            // 
            this.ime.Location = new System.Drawing.Point(72, 53);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(142, 20);
            this.ime.TabIndex = 0;
            // 
            // zvrst
            // 
            this.zvrst.Location = new System.Drawing.Point(72, 95);
            this.zvrst.Name = "zvrst";
            this.zvrst.Size = new System.Drawing.Size(142, 20);
            this.zvrst.TabIndex = 1;
            // 
            // datum
            // 
            this.datum.Location = new System.Drawing.Point(72, 137);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(142, 20);
            this.datum.TabIndex = 2;
            // 
            // lokacija
            // 
            this.lokacija.Location = new System.Drawing.Point(72, 316);
            this.lokacija.Name = "lokacija";
            this.lokacija.Size = new System.Drawing.Size(142, 20);
            this.lokacija.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(72, 180);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(218, 118);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 355);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dodajpredstavo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 496);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lokacija);
            this.Controls.Add(this.datum);
            this.Controls.Add(this.zvrst);
            this.Controls.Add(this.ime);
            this.Name = "Dodajpredstavo";
            this.Text = "Dodajpredstavo";
            this.Load += new System.EventHandler(this.Dodajpredstavo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ime;
        private System.Windows.Forms.TextBox zvrst;
        private System.Windows.Forms.TextBox datum;
        private System.Windows.Forms.TextBox lokacija;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}