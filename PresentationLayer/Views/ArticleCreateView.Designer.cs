
namespace PresentationLayer.Views
{
    partial class ArticleCreateView
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(5, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(324, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ARTICLE DATA";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlBody.Controls.Add(this.lblResult);
            this.pnlBody.Controls.Add(this.cmbCategories);
            this.pnlBody.Controls.Add(this.lblCategories);
            this.pnlBody.Controls.Add(this.txtStock);
            this.pnlBody.Controls.Add(this.lblStock);
            this.pnlBody.Controls.Add(this.txtDescription);
            this.pnlBody.Controls.Add(this.lblDescription);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.lblName);
            this.pnlBody.Location = new System.Drawing.Point(5, 61);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(324, 271);
            this.pnlBody.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblResult.Location = new System.Drawing.Point(0, 198);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(324, 73);
            this.lblResult.TabIndex = 44;
            this.lblResult.Text = "result";
            this.lblResult.Visible = false;
            // 
            // cmbCategories
            // 
            this.cmbCategories.DisplayMember = "Name";
            this.cmbCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(0, 170);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(324, 28);
            this.cmbCategories.TabIndex = 42;
            // 
            // lblCategories
            // 
            this.lblCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.Location = new System.Drawing.Point(0, 150);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(324, 20);
            this.lblCategories.TabIndex = 43;
            this.lblCategories.Text = "Category";
            // 
            // txtStock
            // 
            this.txtStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(0, 123);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(324, 27);
            this.txtStock.TabIndex = 5;
            // 
            // lblStock
            // 
            this.lblStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(0, 100);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(324, 23);
            this.lblStock.TabIndex = 4;
            this.lblStock.Text = "Stock";
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(0, 73);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(324, 27);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(0, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(324, 23);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(0, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(324, 27);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(324, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnAccept);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(5, 338);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(324, 90);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(0, 50);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(324, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(0, 0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(324, 40);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // ArticleCreateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 433);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArticleCreateView";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArticleCreateView";
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}