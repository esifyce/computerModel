namespace lab3
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TeachSVM_Button = new System.Windows.Forms.Button();
            this.SaveSVM_Button = new System.Windows.Forms.Button();
            this.LoadSVM_Button = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ImageFolderName_Button = new System.Windows.Forms.Button();
            this.ImageFileName_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ImageFolderName = new System.Windows.Forms.TextBox();
            this.ImageRec_Button = new System.Windows.Forms.Button();
            this.FolderRec_Buttton = new System.Windows.Forms.Button();
            this.ImageFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Chocolate;
            this.panel1.Controls.Add(this.panel2); 
            this.panel1.Location = new System.Drawing.Point(335, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 550);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.pictureBox);
            this.panel2.Location = new System.Drawing.Point(12, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 516);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(716, 510);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.BackColor = System.Drawing.Color.BurlyWood;
            this.pictureBox.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.TeachSVM_Button);
            this.panel3.Controls.Add(this.SaveSVM_Button);
            this.panel3.Controls.Add(this.LoadSVM_Button);
            this.panel3.Location = new System.Drawing.Point(14, 300);
            this.panel3.Name = "panel3";
            this.panel3.BackColor = System.Drawing.Color.BurlyWood;
            this.panel3.Size = new System.Drawing.Size(314, 173);
            this.panel3.TabIndex = 2;
            // 
            // TeachSVM_Button
            // 
            this.TeachSVM_Button.Location = new System.Drawing.Point(59, 111);
            this.TeachSVM_Button.Name = "TeachSVM_Button";
            this.TeachSVM_Button.Size = new System.Drawing.Size(191, 23);
            this.TeachSVM_Button.TabIndex = 7;
            this.TeachSVM_Button.Text = "Обучить ";
            this.TeachSVM_Button.UseVisualStyleBackColor = true;
            this.TeachSVM_Button.Click += new System.EventHandler(this.TrainSVM_Button_Click);
            // 
            // SaveSVM_Button
            // 
            this.SaveSVM_Button.Location = new System.Drawing.Point(59, 71);
            this.SaveSVM_Button.Name = "SaveSVM_Button";
            this.SaveSVM_Button.Size = new System.Drawing.Size(191, 23);
            this.SaveSVM_Button.TabIndex = 8;
            this.SaveSVM_Button.Text = "Сохранить";
            this.SaveSVM_Button.UseVisualStyleBackColor = true;
            this.SaveSVM_Button.Click += new System.EventHandler(this.SaveSVM_Button_Click);
            // 
            // LoadSVM_Button
            // 
            this.LoadSVM_Button.Location = new System.Drawing.Point(59, 30);
            this.LoadSVM_Button.Name = "LoadSVM_Button";
            this.LoadSVM_Button.Size = new System.Drawing.Size(191, 23);
            this.LoadSVM_Button.TabIndex = 9;
            this.LoadSVM_Button.Text = "Загрузить";
            this.LoadSVM_Button.UseVisualStyleBackColor = true;
            this.LoadSVM_Button.Click += new System.EventHandler(this.LoadSVM_Button_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.BackColor = System.Drawing.Color.BurlyWood;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.ImageFolderName_Button);
            this.panel4.Controls.Add(this.ImageFileName_Button);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.ImageFolderName);
            this.panel4.Controls.Add(this.ImageRec_Button);
            this.panel4.Controls.Add(this.FolderRec_Buttton);
            this.panel4.Controls.Add(this.ImageFileName);
            this.panel4.Location = new System.Drawing.Point(14, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(314, 213);
            this.panel4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Выберите каталог с изображениями";
            // 
            // ImageFolderName_Button
            // 
            this.ImageFolderName_Button.Location = new System.Drawing.Point(234, 121);
            this.ImageFolderName_Button.Name = "ImageFolderName_Button";
            this.ImageFolderName_Button.Size = new System.Drawing.Size(75, 23);
            this.ImageFolderName_Button.TabIndex = 13;
            this.ImageFolderName_Button.Text = "Обзор";
            this.ImageFolderName_Button.UseVisualStyleBackColor = true;
            this.ImageFolderName_Button.Click += new System.EventHandler(this.SelectFolder_Button_Click);
            // 
            // ImageFileName_Button
            // 
            this.ImageFileName_Button.Location = new System.Drawing.Point(229, 23);
            this.ImageFileName_Button.Name = "ImageFileName_Button";
            this.ImageFileName_Button.Size = new System.Drawing.Size(75, 23);
            this.ImageFileName_Button.TabIndex = 12;
            this.ImageFileName_Button.Text = "Обзор";
            this.ImageFileName_Button.UseVisualStyleBackColor = true;
            this.ImageFileName_Button.Click += new System.EventHandler(this.LoadImage_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выберите изображение";
            // 
            // ImageFolderName
            // 
            this.ImageFolderName.Location = new System.Drawing.Point(12, 123);
            this.ImageFolderName.Name = "ImageFolderName";
            this.ImageFolderName.Size = new System.Drawing.Size(216, 20);
            this.ImageFolderName.TabIndex = 10;
            // 
            // ImageRec_Button
            // 
            this.ImageRec_Button.Location = new System.Drawing.Point(179, 52);
            this.ImageRec_Button.Name = "ImageRec_Button";
            this.ImageRec_Button.Size = new System.Drawing.Size(125, 23);
            this.ImageRec_Button.TabIndex = 9;
            this.ImageRec_Button.Text = "Распознать";
            this.ImageRec_Button.UseVisualStyleBackColor = true;
            this.ImageRec_Button.Click += new System.EventHandler(this.RecognizeImage_Button_Click);
            // 
            // FolderRec_Buttton
            // 
            this.FolderRec_Buttton.Location = new System.Drawing.Point(184, 148);
            this.FolderRec_Buttton.Name = "FolderRec_Buttton";
            this.FolderRec_Buttton.Size = new System.Drawing.Size(125, 23);
            this.FolderRec_Buttton.TabIndex = 8;
            this.FolderRec_Buttton.Text = "Загрузить";
            this.FolderRec_Buttton.UseVisualStyleBackColor = true;
            this.FolderRec_Buttton.Click += new System.EventHandler(this.RecognizeFolder_Button_Click);
            // 
            // ImageFileName
            // 
            this.ImageFileName.Location = new System.Drawing.Point(12, 25);
            this.ImageFileName.Name = "ImageFileName";
            this.ImageFileName.Size = new System.Drawing.Size(211, 20);
            this.ImageFileName.TabIndex = 0;
       
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1120, 650);
            this.MinimumSize = new System.Drawing.Size(1120, 650);
            this.Name = "MainForm";
            this.Text = "Распознавание пешеходов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();



        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button TeachSVM_Button;
        private System.Windows.Forms.Button SaveSVM_Button;
        private System.Windows.Forms.Button LoadSVM_Button;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ImageFolderName_Button;
        private System.Windows.Forms.Button ImageFileName_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ImageFolderName;
        private System.Windows.Forms.Button ImageRec_Button;
        private System.Windows.Forms.Button FolderRec_Buttton;
        private System.Windows.Forms.TextBox ImageFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}

