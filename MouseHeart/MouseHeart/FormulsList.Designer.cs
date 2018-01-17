namespace MouseHeart
{
    partial class FormulsList
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
            this.dgvFormulsList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulsList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFormulsList
            // 
            this.dgvFormulsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormulsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFormulsList.Location = new System.Drawing.Point(0, 0);
            this.dgvFormulsList.Name = "dgvFormulsList";
            this.dgvFormulsList.Size = new System.Drawing.Size(284, 261);
            this.dgvFormulsList.TabIndex = 0;
            // 
            // FormulsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dgvFormulsList);
            this.Name = "FormulsList";
            this.Text = "FormulsList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFormulsList;
    }
}