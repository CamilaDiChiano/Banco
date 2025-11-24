using System;

namespace Banco
{
    public class Cuenta
    {
        // Atributos
        private int numeroCuenta;
        private string apellido;
        private string dni;
        private double saldo;

        // Constructor
        public Cuenta(int numeroCuenta, string apellido, string dni, double saldo)
        {
            this.numeroCuenta = numeroCuenta;
            this.apellido = apellido;
            this.dni = dni;
            this.saldo = saldo;
        }

        // Propiedades
        public int NumeroCuenta
        {
            get { return numeroCuenta; }
            set { numeroCuenta = value; }
        }
        
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        public double Extraccion(double extraccion)
        {
            this.saldo -= extraccion;

            return this.saldo;
        }
        public double Deposito(double deposito)
        {
            this.saldo += deposito;

            return this.saldo;
        }
    }
}
