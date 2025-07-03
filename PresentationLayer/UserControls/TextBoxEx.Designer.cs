
namespace PresentationLayer.UserControls
{
    partial class TextBoxEx
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.txtTextBox = new System.Windows.Forms.TextBox();
            this.lblPaddingBottom = new System.Windows.Forms.Label();
            this.lblPaddingTop = new System.Windows.Forms.Label();
            this.lblPaddingRight = new System.Windows.Forms.Label();
            this.lblPaddingLeft = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.txtTextBox);
            this.pnlContainer.Controls.Add(this.lblPaddingBottom);
            this.pnlContainer.Controls.Add(this.lblPaddingTop);
            this.pnlContainer.Controls.Add(this.lblPaddingRight);
            this.pnlContainer.Controls.Add(this.lblPaddingLeft);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(150, 150);
            this.pnlContainer.TabIndex = 0;
            // 
            // txtTextBox
            // 
            this.txtTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTextBox.Location = new System.Drawing.Point(15, 15);
            this.txtTextBox.Multiline = true;
            this.txtTextBox.Name = "txtTextBox";
            this.txtTextBox.Size = new System.Drawing.Size(120, 120);
            this.txtTextBox.TabIndex = 4;
            // 
            // lblPaddingBottom
            // 
            this.lblPaddingBottom.BackColor = System.Drawing.Color.Yellow;
            this.lblPaddingBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPaddingBottom.Location = new System.Drawing.Point(15, 135);
            this.lblPaddingBottom.Name = "lblPaddingBottom";
            this.lblPaddingBottom.Size = new System.Drawing.Size(120, 15);
            this.lblPaddingBottom.TabIndex = 3;
            this.lblPaddingBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaddingTop
            // 
            this.lblPaddingTop.BackColor = System.Drawing.Color.Lime;
            this.lblPaddingTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPaddingTop.Location = new System.Drawing.Point(15, 0);
            this.lblPaddingTop.Name = "lblPaddingTop";
            this.lblPaddingTop.Size = new System.Drawing.Size(120, 15);
            this.lblPaddingTop.TabIndex = 2;
            this.lblPaddingTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaddingRight
            // 
            this.lblPaddingRight.BackColor = System.Drawing.Color.Blue;
            this.lblPaddingRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPaddingRight.Location = new System.Drawing.Point(135, 0);
            this.lblPaddingRight.Name = "lblPaddingRight";
            this.lblPaddingRight.Size = new System.Drawing.Size(15, 150);
            this.lblPaddingRight.TabIndex = 1;
            this.lblPaddingRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaddingLeft
            // 
            this.lblPaddingLeft.BackColor = System.Drawing.Color.Red;
            this.lblPaddingLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPaddingLeft.Location = new System.Drawing.Point(0, 0);
            this.lblPaddingLeft.Name = "lblPaddingLeft";
            this.lblPaddingLeft.Size = new System.Drawing.Size(15, 150);
            this.lblPaddingLeft.TabIndex = 0;
            this.lblPaddingLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Name = "TextBoxEx";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.TextBox txtTextBox;
        private System.Windows.Forms.Label lblPaddingBottom;
        private System.Windows.Forms.Label lblPaddingTop;
        private System.Windows.Forms.Label lblPaddingRight;
        private System.Windows.Forms.Label lblPaddingLeft;
    }
}
