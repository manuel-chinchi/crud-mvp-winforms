
namespace PresentationLayer.Views
{
    partial class MainView
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
            this.btnArticles = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnReports = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnArticles
            // 
            this.btnArticles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArticles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticles.Location = new System.Drawing.Point(0, 53);
            this.btnArticles.Name = "btnArticles";
            this.btnArticles.Size = new System.Drawing.Size(256, 50);
            this.btnArticles.TabIndex = 0;
            this.btnArticles.Text = "Articles";
            this.btnArticles.UseVisualStyleBackColor = true;
            this.btnArticles.Click += new System.EventHandler(this.btnArticles_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.Location = new System.Drawing.Point(0, 109);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(256, 50);
            this.btnCategories.TabIndex = 1;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(3, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(250, 50);
            this.lblMenu.TabIndex = 2;
            this.lblMenu.Text = "Menu";
            this.lblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReports
            // 
            this.btnReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(0, 165);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(256, 50);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.btnArticles);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(256, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnArticles;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnReports;
    }
}
