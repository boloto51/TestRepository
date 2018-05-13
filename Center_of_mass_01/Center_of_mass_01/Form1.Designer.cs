namespace Center_of_mass_01
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCentre = new System.Windows.Forms.Button();
            this.tbListOfPoints = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.tbNumberOfPoints = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(96, 219);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Генерация";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCentre
            // 
            this.btnCentre.Location = new System.Drawing.Point(178, 219);
            this.btnCentre.Name = "btnCentre";
            this.btnCentre.Size = new System.Drawing.Size(75, 23);
            this.btnCentre.TabIndex = 2;
            this.btnCentre.Text = "Центр масс";
            this.btnCentre.UseVisualStyleBackColor = true;
            this.btnCentre.Click += new System.EventHandler(this.btnCentre_Click);
            // 
            // tbListOfPoints
            // 
            this.tbListOfPoints.Location = new System.Drawing.Point(219, 13);
            this.tbListOfPoints.Multiline = true;
            this.tbListOfPoints.Name = "tbListOfPoints";
            this.tbListOfPoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbListOfPoints.Size = new System.Drawing.Size(200, 200);
            this.tbListOfPoints.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(259, 218);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Очистка";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tbNumberOfPoints
            // 
            this.tbNumberOfPoints.Location = new System.Drawing.Point(12, 221);
            this.tbNumberOfPoints.Name = "tbNumberOfPoints";
            this.tbNumberOfPoints.Size = new System.Drawing.Size(50, 20);
            this.tbNumberOfPoints.TabIndex = 5;
            this.tbNumberOfPoints.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 262);
            this.Controls.Add(this.tbNumberOfPoints);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbListOfPoints);
            this.Controls.Add(this.btnCentre);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCentre;
        private System.Windows.Forms.TextBox tbListOfPoints;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox tbNumberOfPoints;
    }
}

