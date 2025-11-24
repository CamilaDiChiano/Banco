using System;

namespace Banco
{
    public class Banco
    {
        private string nombre;
        private List<Cliente> clientes;
        private List<Cuenta> cuentas;

        public Banco(string nombre)
        {
            this.nombre = nombre;
            this.clientes = new List<Cliente>();
            this.cuentas = new List<Cuenta>();
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Cliente> GetListaClientes()
        {
            return clientes;
        }
        public List<Cuenta> GetListaCuentas()
        {
            return cuentas;
        }

        public void AgregarNuevaCuenta(Cuenta cuenta)
        {
           cuentas.Add(cuenta);
        }
        public void AgregarNuevoCliente(Cliente cliente)
        {
           clientes.Add(cliente);
        }

        public void EliminarCuenta(Cuenta cuenta)
        {
            cuentas.Remove(cuenta);
        }

        public void EliminarCliente(Cliente cliente)
        {
            clientes.Remove(cliente);
        }
    }
}
