namespace RepeatPath_03
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
            this.btnBegin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbPicBoxWidth = new System.Windows.Forms.TextBox();
            this.tbPicBoxHeight = new System.Windows.Forms.TextBox();
            this.btnMakePlace = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(118, 63);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(100, 74);
            this.btnBegin.TabIndex = 1;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кубов по ширине";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Кубов по высоте";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // tbPicBoxWidth
            // 
            this.tbPicBoxWidth.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbPicBoxWidth.Location = new System.Drawing.Point(108, 6);
            this.tbPicBoxWidth.Name = "tbPicBoxWidth";
            this.tbPicBoxWidth.Size = new System.Drawing.Size(72, 20);
            this.tbPicBoxWidth.TabIndex = 5;
            this.tbPicBoxWidth.Text = "4-10";
            this.tbPicBoxWidth.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbPicBoxWidth_MouseClick);
            this.tbPicBoxWidth.TextChanged += new System.EventHandler(this.tbPicBoxWidth_TextChanged);
            // 
            // tbPicBoxHeight
            // 
            this.tbPicBoxHeight.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbPicBoxHeight.Location = new System.Drawing.Point(110, 37);
            this.tbPicBoxHeight.Name = "tbPicBoxHeight";
            this.tbPicBoxHeight.Size = new System.Drawing.Size(70, 20);
            this.tbPicBoxHeight.TabIndex = 6;
            this.tbPicBoxHeight.Text = "4-10";
            this.tbPicBoxHeight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbPicBoxHeight_MouseClick);
            this.tbPicBoxHeight.TextChanged += new System.EventHandler(this.tbPicBoxHeight_TextChanged);
            // 
            // btnMakePlace
            // 
            this.btnMakePlace.Location = new System.Drawing.Point(197, 21);
            this.btnMakePlace.Name = "btnMakePlace";
            this.btnMakePlace.Size = new System.Drawing.Size(75, 23);
            this.btnMakePlace.TabIndex = 7;
            this.btnMakePlace.Text = "Make Place";
            this.btnMakePlace.UseVisualStyleBackColor = true;
            this.btnMakePlace.Click += new System.EventHandler(this.btnMakePlace_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(79, 169);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 8;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(37, 198);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(118, 198);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 10;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(79, 227);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 11;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(199, 198);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(199, 227);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 23);
            this.btnReverse.TabIndex = 13;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnMakePlace);
            this.Controls.Add(this.tbPicBoxHeight);
            this.Controls.Add(this.tbPicBoxWidth);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbPicBoxWidth;
        private System.Windows.Forms.TextBox tbPicBoxHeight;
        private System.Windows.Forms.Button btnMakePlace;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReverse;
    }
}

