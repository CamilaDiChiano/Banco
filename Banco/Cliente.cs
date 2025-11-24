using System;

namespace Banco
{

    public class Cliente
    {
        // Atributos

        private string apellido;
        private string nombre;
        private string dni;
        private string direccion;
        private string mail;
        private string telefono;

        // Constructor
        public Cliente(string apellido, string nombre, string dni, string direccion, string mail, string telefono)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
            this.direccion = direccion;
            this.mail = mail; 
            this.telefono = telefono;
        }

        // Sobrecarga del constructor
        public Cliente()
        {
        }

        //Propiedades
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

    }
}