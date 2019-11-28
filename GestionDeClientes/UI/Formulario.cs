using System;
using WFrms = System.Windows.Forms;
using System.Drawing;
using System.Security.Permissions;

namespace GestionDeClientes.UI
{
    public partial class Formulario : WFrms.Form
    {
        public Formulario()
        {
            this.Build();
        }

        private void Build()
        {
            var mainPanel = new WFrms.TableLayoutPanel
            {
                Dock=WFrms.DockStyle.Fill,
                Font = new Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            
            mainPanel.Controls.Add(this.BuildNIF());
            mainPanel.Controls.Add(this.BuildNombre());
            mainPanel.Controls.Add(this.BuildTelefono());
            mainPanel.Controls.Add(this.BuildEmail());
            mainPanel.Controls.Add(this.BuildDireccion());
            mainPanel.Controls.Add(this.BuildBotonAceptar());
            this.Controls.Add(mainPanel);
        }

        private WFrms.Panel BuildNIF()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblNIF= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "NIF"
            };
            this.EdNIF = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text="??"
            };
            
            pnl.Controls.Add(this.EdNIF);
            pnl.Controls.Add(lblNIF);
            return pnl;
        }
        
        private WFrms.Panel BuildNombre()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblNombre= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Nombre"
            };
            this.EdNombre = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
            
            pnl.Controls.Add(this.EdNombre);
            pnl.Controls.Add(lblNombre);
            return pnl;
        }
        
        private WFrms.Panel BuildTelefono()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblTelefono= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Teléfono"
            };
            this.EdTelefono = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
            
            pnl.Controls.Add(this.EdTelefono);
            pnl.Controls.Add(lblTelefono);
            return pnl;
        }
        
        private WFrms.Panel BuildEmail()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblEmail= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Email"
            };
            this.EdEmail = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
            
            pnl.Controls.Add(this.EdEmail);
            pnl.Controls.Add(lblEmail);
            return pnl;
        }

        private WFrms.Panel BuildDireccion()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            var lblDireccion= new WFrms.Label {
                Dock = WFrms.DockStyle.Left,
                BackColor = Color.Turquoise,
                Text = "Dirección"
            };
            this.EdDireccion = new WFrms.TextBox {
                Dock = WFrms.DockStyle.Fill,
                BackColor = SystemColors.Window,
                Margin = new WFrms.Padding(3, 2, 3, 2),
                Text = "??"
            };
                     
            pnl.Controls.Add(this.EdDireccion);
            pnl.Controls.Add(lblDireccion);
            return pnl;
        }

        WFrms.Panel BuildBotonAceptar()
        {
            var pnl = new WFrms.Panel {
                Dock = WFrms.DockStyle.Top
            };
            this.botonAceptar = new WFrms.Button {
                Dock=WFrms.DockStyle.Top,
                BackColor = Color.Turquoise,
                Size = new Size(100, 50),
                Text = "INSERTAR"
            };
            pnl.Controls.Add(botonAceptar);
            return pnl;
        }
        public WFrms.TextBox EdNIF { get; private set; }
        public WFrms.TextBox EdNombre { get; private set; }
        public WFrms.TextBox EdTelefono { get; private set; }
        public WFrms.TextBox EdEmail { get; private set; }
        public WFrms.TextBox EdDireccion { get; private set; }
        public WFrms.Button botonAceptar { get; private set; }
        
    }
}