using System;
using System.ComponentModel;
using WFrm =System.Windows.Forms;
using GestionDeClientes.Core;

namespace GestionDeClientes.UI
{
    public class MainWindowController
    {
        public MainWindowController()
        {
            this.MainView = new MainView();
            this.Formulario=new Formulario(); 
            this.Clientes=new ColeccionClientes();
            this.VistaDetallada = new VistaDetallada(new Cliente("","","","",""));
            this.MainView.BotonInsertar.Click += this.Operar;
            this.Formulario.botonAceptar.Click +=this.Insertar;
            this.MainView.Lista.Click +=this.Visualizar;
            this.VistaDetallada.botonModificar.Click += this.Modificar;
            this.VistaDetallada.botonEliminar.Click += this.Eliminar;
            this.MainView.BotonGuardar.Click += this.Guardar;
            this.MainView.BotonRecuperar.Click += this.Recuperar;
        }

        void Operar(Object sender, EventArgs e)
        {
            Formulario.ShowDialog();
        }

        void Insertar(Object sender, EventArgs e)
        {
            
            String textNIF = Formulario.EdNIF.Text;
            String textNombre = Formulario.EdNombre.Text;
            String textTelefono = Formulario.EdTelefono.Text;
            String textEmail = Formulario.EdEmail.Text;
            String textDireccion = Formulario.EdDireccion.Text;
            
            Cliente c = new Cliente(textNIF,textNombre,textTelefono,textEmail,textDireccion);

            Clientes.Inserta(c);
            MainView.Lista.Items.Add(c.ToString());
            Formulario.Close();
        }

        Cliente encontrarCliente(String NIF)
        {
            Cliente toret = new Cliente("","","","","");
            
            foreach (Cliente c in Clientes.Clientes) {
                if (c.NIF.Equals(NIF)) {
                    toret = c;
                    break;
                }
            }
            return toret;
        }
        
        void Visualizar(Object sender, EventArgs e)
        {
            String NIF = MainView.Lista.SelectedItems[0].Text.Substring(0, 9);
            Console.WriteLine(NIF);
            Cliente clienteActual = encontrarCliente(NIF);
            VistaDetallada.Cliente = clienteActual;
            VistaDetallada.ShowDialog();
        }

        void Modificar(Object sender, EventArgs e)
        {
            String textNIF = VistaDetallada.EdNIF.Text;
            String textNombre = VistaDetallada.EdNombre.Text;
            String textTelefono = VistaDetallada.EdTelefono.Text;
            String textEmail = VistaDetallada.EdEmail.Text;
            String textDireccion = VistaDetallada.EdDireccion.Text;
            
            Cliente clienteActual = encontrarCliente(textNIF);
            
            clienteActual.Nombre = textNombre;
            clienteActual.Telefono = textTelefono;
            clienteActual.Email = textEmail;
            clienteActual.Direccion = textDireccion;

            int pos = Clientes.Posicion(clienteActual);
            
            MainView.Lista.Items.RemoveAt(pos);
            MainView.Lista.Items.Insert(pos, clienteActual.ToString());
            VistaDetallada.Close();
        }

        void Eliminar(Object sender, EventArgs e)
        {
            String textNIF = VistaDetallada.EdNIF.Text;
            Cliente clienteActual = this.encontrarCliente(textNIF);
            int pos = Clientes.Posicion(clienteActual);
            Clientes.Elimina(clienteActual);
            MainView.Lista.Items.RemoveAt(pos);
            VistaDetallada.Close();
        }

        void Guardar(Object sender, EventArgs e)
        {
            Clientes.VuelcaXML();
        }

        void Recuperar(Object sender, EventArgs e)
        {
            Cliente[] clientesRecuperar = Clientes.LeerClientesXmlDom();
            MainView.Lista.Items.Clear();
            for (int i = 0; i < clientesRecuperar.Length; i++)
            {
                MainView.Lista.Items.Add(clientesRecuperar[i].ToString());
                Clientes.Inserta(clientesRecuperar[i]);
                Console.WriteLine(clientesRecuperar[i].ToString());
            }
            MainView.Lista.Refresh();
        }

        public MainView MainView { get; set; }
        
        public ColeccionClientes Clientes { get; set; }

        public Formulario Formulario { get; set; }
        
        public VistaDetallada VistaDetallada { get; set; }
    }
}