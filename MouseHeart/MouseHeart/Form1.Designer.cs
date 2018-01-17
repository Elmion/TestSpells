namespace MouseHeart
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
            this.pbHp = new System.Windows.Forms.ProgressBar();
            this.pbHangry = new System.Windows.Forms.ProgressBar();
            this.pbStamina = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLungs = new System.Windows.Forms.TextBox();
            this.tbBlood = new System.Windows.Forms.TextBox();
            this.tbPancreas = new System.Windows.Forms.TextBox();
            this.tbLiver = new System.Windows.Forms.TextBox();
            this.tbHeart = new System.Windows.Forms.TextBox();
            this.tbBrain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbHp
            // 
            this.pbHp.Location = new System.Drawing.Point(65, 15);
            this.pbHp.Name = "pbHp";
            this.pbHp.Size = new System.Drawing.Size(423, 12);
            this.pbHp.TabIndex = 0;
            // 
            // pbHangry
            // 
            this.pbHangry.Location = new System.Drawing.Point(65, 35);
            this.pbHangry.Name = "pbHangry";
            this.pbHangry.Size = new System.Drawing.Size(423, 12);
            this.pbHangry.TabIndex = 0;
            // 
            // pbStamina
            // 
            this.pbStamina.Location = new System.Drawing.Point(65, 55);
            this.pbStamina.Name = "pbStamina";
            this.pbStamina.Size = new System.Drawing.Size(423, 12);
            this.pbStamina.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hangry";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Stamina";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(504, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(504, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(504, 47);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 20);
            this.textBox3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbLungs);
            this.groupBox1.Controls.Add(this.tbBlood);
            this.groupBox1.Controls.Add(this.tbPancreas);
            this.groupBox1.Controls.Add(this.tbLiver);
            this.groupBox1.Controls.Add(this.tbHeart);
            this.groupBox1.Controls.Add(this.tbBrain);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Физика";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Lungs";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Blood";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Рancreas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Liver";
            // 
            // tbLungs
            // 
            this.tbLungs.Location = new System.Drawing.Point(95, 153);
            this.tbLungs.Name = "tbLungs";
            this.tbLungs.ReadOnly = true;
            this.tbLungs.Size = new System.Drawing.Size(56, 20);
            this.tbLungs.TabIndex = 2;
            // 
            // tbBlood
            // 
            this.tbBlood.Location = new System.Drawing.Point(95, 127);
            this.tbBlood.Name = "tbBlood";
            this.tbBlood.ReadOnly = true;
            this.tbBlood.Size = new System.Drawing.Size(56, 20);
            this.tbBlood.TabIndex = 2;
            // 
            // tbPancreas
            // 
            this.tbPancreas.Location = new System.Drawing.Point(95, 99);
            this.tbPancreas.Name = "tbPancreas";
            this.tbPancreas.ReadOnly = true;
            this.tbPancreas.Size = new System.Drawing.Size(56, 20);
            this.tbPancreas.TabIndex = 2;
            // 
            // tbLiver
            // 
            this.tbLiver.Location = new System.Drawing.Point(95, 73);
            this.tbLiver.Name = "tbLiver";
            this.tbLiver.ReadOnly = true;
            this.tbLiver.Size = new System.Drawing.Size(56, 20);
            this.tbLiver.TabIndex = 2;
            // 
            // tbHeart
            // 
            this.tbHeart.Location = new System.Drawing.Point(95, 46);
            this.tbHeart.Name = "tbHeart";
            this.tbHeart.ReadOnly = true;
            this.tbHeart.Size = new System.Drawing.Size(56, 20);
            this.tbHeart.TabIndex = 2;
            // 
            // tbBrain
            // 
            this.tbBrain.Location = new System.Drawing.Point(95, 20);
            this.tbBrain.Name = "tbBrain";
            this.tbBrain.ReadOnly = true;
            this.tbBrain.Size = new System.Drawing.Size(56, 20);
            this.tbBrain.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Heart";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Brain";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(184, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 203);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Stamina";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Stamina";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Stamina";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Открыть формулы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 299);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbStamina);
            this.Controls.Add(this.pbHangry);
            this.Controls.Add(this.pbHp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbHp;
        private System.Windows.Forms.ProgressBar pbHangry;
        private System.Windows.Forms.ProgressBar pbStamina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLungs;
        private System.Windows.Forms.TextBox tbBlood;
        private System.Windows.Forms.TextBox tbPancreas;
        private System.Windows.Forms.TextBox tbLiver;
        private System.Windows.Forms.TextBox tbHeart;
        private System.Windows.Forms.TextBox tbBrain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}

