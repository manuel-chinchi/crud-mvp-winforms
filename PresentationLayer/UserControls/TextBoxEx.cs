using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.UserControls
{
    /// <summary>
    /// Clase tipo TextBox con paddings ajustables
    /// </summary>
    public partial class TextBoxEx : UserControl
    {
        private Color _borderColor = SystemColors.Window;
        private int _borderWidth = 1;
        private Color _innerBackColor = Color.White;
        private Color _paddingColor;

        public TextBoxEx()
        {
            InitializeComponent();
            SetupCustomProperties();
            SetupCutomEvents();
        }

        private void SetupCustomProperties()
        {
            // TODO agregar propiedades de inicio aquí
        }

        private void SetupCutomEvents()
        {
            this.DoubleClick += TextBoxEx_DoubleClick;
            lblPaddingLeft.DoubleClick += TextBoxEx_DoubleClick;
            lblPaddingTop.DoubleClick += TextBoxEx_DoubleClick;
            lblPaddingRight.DoubleClick += TextBoxEx_DoubleClick;
            lblPaddingBottom.DoubleClick += TextBoxEx_DoubleClick;

            this.Click += TextBoxEx_Click;
            lblPaddingLeft.Click += TextBoxEx_Click;
            lblPaddingTop.Click += TextBoxEx_Click;
            lblPaddingRight.Click += TextBoxEx_Click;
            lblPaddingBottom.Click += TextBoxEx_Click;
        }

        private void TextBoxEx_DoubleClick(object sender, EventArgs e)
        {
            txtTextBox.SelectAll();
        }

        private void TextBoxEx_Click(object sender, EventArgs e)
        {
            txtTextBox.Select(0, 0);
        }

        #region Paddings

        public int PaddingLeft
        {
            get => lblPaddingLeft.Width;
            set => lblPaddingLeft.Width = value;
        }
        public int PaddingTop
        {
            get => lblPaddingTop.Height;
            set => lblPaddingTop.Height = value;
        }
        public int PaddingRight
        {
            get => lblPaddingRight.Width;
            set => lblPaddingRight.Width = value;
        }
        public int PaddingBottom
        {
            get => lblPaddingBottom.Height;
            set => lblPaddingBottom.Height = value;
        }

        public Color PaddingsColor
        {
            get => _paddingColor;
            set
            {
                _paddingColor = value;
                lblPaddingTop.BackColor = value;
                lblPaddingLeft.BackColor = value;
                lblPaddingRight.BackColor = value;
                lblPaddingBottom.BackColor = value;
            }
        }

        #endregion

        #region BackColor

        [Category("Appearance")]
        public Color InnerBackColor
        {
            get => _innerBackColor;
            set { _innerBackColor = value; pnlContainer.BackColor = value; }
        }

        #endregion

        #region Text

        [Category("Appearance")]
        [Description("Texto contenido en el control")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]  // permite serializacion
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get => txtTextBox.Text;
            set => txtTextBox.Text = value;
        }

        public bool Multiline
        {
            get => txtTextBox.Multiline;
            set => txtTextBox.Multiline = value;
        }

        [Category("Appearance")]  // para que aparezca en la categoría "Apariencia" en el diseñador
        [Description("Fuente del texto dentro del TextBox.")]
        public Font FontTextBoxEx
        {
            get => txtTextBox.Font;
            set => txtTextBox.Font = value;
        }
        #endregion

        #region Border

        [Category("Appearance")]
        [Description("Color del borde del control")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                UpdateBorderAppearance();
            }
        }

        [Category("Appearance")]
        [Description("Ancho del borde en píxeles")]
        public int BorderWidth
        {
            get => _borderWidth;
            set
            {
                _borderWidth = value;
                UpdateBorderAppearance();
            }
        }

        private void UpdateBorderAppearance()
        {
            if (pnlContainer != null)
            {
                // ERROR    Si el textbox no es multilinea se ve el panel de fondo si este no
                //          tiene el mismo BackColor

                //// 1. Configurar el Panel como borde
                //pnlContainer.BackColor = _borderColor;
                //pnlContainer.Padding = new Padding(_borderWidth);

                //// 2. Ajustar el TextBox para que coincida con el borde
                //txtTextBox.BackColor = this.BackColor;
                //txtTextBox.Location = new Point(_borderWidth, _borderWidth);
                //txtTextBox.Size = new Size(
                //    this.Width - (_borderWidth * 2),
                //    this.Height - (_borderWidth * 2));

                // TODO hacer pruebas
                this.BackColor = _borderColor;
                this.Padding = new Padding(_borderWidth);

                //// 2. Ajustar el TextBox para que coincida con el borde
                //txtTextBox.Location = new Point(_borderWidth, _borderWidth);
                //txtTextBox.Size = new Size(
                //    this.Width - (_borderWidth * 2),
                //    this.Height - (_borderWidth * 2));
            }
        }
        #endregion

        #region Events
        public event KeyEventHandler TextBoxEx_KeyDown
        {
            add { txtTextBox.KeyDown += value; }
            remove { txtTextBox.KeyDown -= value; }
        }
        #endregion
    }
}
