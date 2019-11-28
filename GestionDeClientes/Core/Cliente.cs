using System;
using System.Text;

namespace GestionDeClientes.Core
{
    public class Cliente
    {
		public Cliente(string nif, string nombre, string telefono, string email, string direccion)
        {
			this.NIF = nif;
			this.Nombre = nombre;
			this.Telefono = telefono;
			this.Email = email;
			this.Direccion = direccion;
        }
		public string NIF{
			get; set;
		}
		public string Nombre{
			get; set;
		}
		public string Telefono{
			get; set;
		}
		public string Email{
			get; set;
		}
		public string Direccion{
			get; set;
		}

		public override string ToString()
		{
			StringBuilder toret = new StringBuilder();

			toret.Append(NIF)
				.Append(", ")
				.Append(Nombre)
				/*.Append("||")
				.Append(Telefono)
				.Append("||->")
				.Append(Email)
				.Append(", ")
				.Append(Direccion)*/
				;

			return toret.ToString();
		}
    }
}
