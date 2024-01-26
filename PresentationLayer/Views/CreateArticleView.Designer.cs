
namespace PresentationLayer.Views
{
    partial class CreateArticleView
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStock = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(3, 170);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(47, 18);
            this.lblStock.TabIndex = 36;
            this.lblStock.Text = "Stock";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(3, 113);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 18);
            this.lblDescription.TabIndex = 35;
            this.lblDescription.Text = "Description";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 56);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 18);
            this.lblName.TabIndex = 34;
            this.lblName.Text = "Name";
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(6, 191);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(317, 27);
            this.txtStock.TabIndex = 33;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(6, 134);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(317, 27);
            this.txtDescription.TabIndex = 32;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(6, 77);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(317, 27);
            this.txtName.TabIndex = 31;
            // 
            // btnAccept
            // 
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(6, 332);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(317, 39);
            this.btnAccept.TabIndex = 37;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(6, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(317, 39);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(99, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(141, 20);
            this.lblTitle.TabIndex = 39;
            this.lblTitle.Text = "ARTICLE DATA";
            // 
            // cmbCategories
            // 
            this.cmbCategories.DisplayMember = "Name";
            this.cmbCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(6, 265);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(317, 28);
            this.cmbCategories.TabIndex = 40;
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.Location = new System.Drawing.Point(3, 242);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(76, 20);
            this.lblCategories.TabIndex = 41;
            this.lblCategories.Text = "Category";
            // 
            // CreateArticleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Name = "CreateArticleView";
            this.Size = new System.Drawing.Size(328, 445);
            this.Load += new System.EventHandler(this.CreateArticleView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label lblCategories;
    }
}
