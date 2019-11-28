using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace GestionDeClientes.Core
{
    public class ColeccionClientes
    {
        public ColeccionClientes()
        {
            Clientes = new List<Cliente>();
        }

        public void Inserta(Cliente c)
        {
            Clientes.Add(c);
        }
        
        public Cliente Inserta(string nif, string nombre, string telefono, string email, string direccion) {
            Cliente nuevo = new Cliente(nif,nombre, telefono, email, direccion);
            Clientes.Add(nuevo);
            return nuevo;
        }

        public void Modifica(Cliente c) {
            int i = 0; //ver en que posición está el cliente que se desea modificar
            if(Clientes.Contains(c)){
                foreach(Cliente actual in Clientes){
                    if(actual.NIF.Equals(c.NIF)){
                        Clientes.Insert(i, c);
                        break;
                    }
                    i++;
                }
            }
        }

        public int Posicion(Cliente c)
        {
            int i = 0; //ver en que posición está el cliente que se desea modificar
            if(Clientes.Contains(c)){
                foreach(Cliente actual in Clientes){
                    if(actual.NIF.Equals(c.NIF)){
                        break;
                    }
                    i++;
                }
            }
            return i;
        }
        
        public string VuelcaXML()
        {
            using (var xw = new XmlTextWriter("clientes.xml", Encoding.UTF8))
            {
                xw.WriteStartElement("clientes");

                foreach(Cliente c in Clientes)
                {
                    string NIF = c.NIF;
                    string nombre = c.Nombre;
                    string telefono = c.Telefono;
                    string email = c.Email;
                    string direccion = c.Direccion;
                    xw.WriteStartElement("cliente");
                    xw.WriteStartElement("NIF");
                    xw.WriteString(NIF);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Nombre");
                    xw.WriteString(nombre);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Telefono");
                    xw.WriteString(telefono);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Email");
                    xw.WriteString(email);
                    xw.WriteEndElement();
                    xw.WriteStartElement("Direccion");
                    xw.WriteString(direccion);
                    xw.WriteEndElement();
                    
                    xw.WriteEndElement();
                }

                xw.WriteEndElement();
                xw.Close();
                return xw.ToString();
            }
        }
        
        public Cliente[] LeerClientesXmlDom()
        {
            var doc = new XmlDocument();
            var toret = new List<Cliente>();

            doc.Load("clientes.xml");

            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string NIF = "";
                string Nombre = "";
                string Telefono = "";
                string Email = "";
                string Direccion = "";

                foreach(XmlNode subnode in node)
                {
                    if(subnode.Name == "NIF")
                    {
                        NIF = subnode.InnerText;
                    } else if(subnode.Name == "Nombre")
                    {
                        Nombre = subnode.InnerText;
                    } else if(subnode.Name == "Telefono")
                    {
                        Telefono = subnode.InnerText;
                    } else if(subnode.Name == "Email")
                    {
                        Email = subnode.InnerText;
                    } else if(subnode.Name == "Direccion")
                    {
                        Direccion = subnode.InnerText;
                    }
                }
                if (!string.IsNullOrWhiteSpace(NIF))
                {
                    toret.Add(new Cliente(NIF,Nombre,Telefono,Email,Direccion));
                }
            }
            return toret.ToArray();
        }

        public void Elimina(Cliente c) {
            if (Clientes.Contains(c)) {
                foreach (Cliente actual in Clientes) {
                    if (actual.NIF.Equals(c.NIF)) {
                        Clientes.Remove(c);
                        break;
                    }
                }
            }
        }

        public List<Cliente> Clientes { get; set; }
    }
}