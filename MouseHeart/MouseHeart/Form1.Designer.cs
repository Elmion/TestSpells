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
            this.bEat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bEat
            // 
            this.bEat.Location = new System.Drawing.Point(55, 33);
            this.bEat.Name = "bEat";
            this.bEat.Size = new System.Drawing.Size(59, 54);
            this.bEat.TabIndex = 0;
            this.bEat.Text = "Еда";
            this.bEat.UseVisualStyleBackColor = true;
            this.bEat.Click += new System.EventHandler(this.bEat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 299);
            this.Controls.Add(this.bEat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bEat;
    }
}

