using Banco;
using System;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco b = new Banco("Breach");

            // Cargar datos desde txt
            CargarClientesDesdeArchivo(b, "clientes.txt");
            CargarCuentasDesdeArchivo(b, "cuentas.txt");

            int opcion;

            do
            {
                Console.WriteLine("\nBienvenido a " + b.Nombre);
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1: Agregar cuenta al banco");
                Console.WriteLine("2: Eliminar cuenta del banco");
                Console.WriteLine("3: Lista de clientes que tienen mas de una cuenta");
                Console.WriteLine("4: Realizar una extaccion");
                Console.WriteLine("5: Depositar dinero");
                Console.WriteLine("6: Transferir dinero entre dos cuentas");
                Console.WriteLine("7: Mostrar lista Clientes");
                Console.WriteLine("8: Mostrar lista Cuentas");
                Console.WriteLine("9: Salir");
                Console.Write("Seleccione una opcion: ");

                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion < 1)
                    {
                        throw new excepcionMenu();
                    }
                    else if (opcion > 9)
                    {
                        throw new excepcionMenu();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("                             ");
                    Console.WriteLine("Debe ingresar un numero mayor a 0 o menor a 10!: ");

                    opcion = 0;
                }
                catch (excepcionMenu e)
                {
                    Console.WriteLine(e.Message);
                    opcion = 0;
                }


                switch (opcion)
                {
                    case 1: // Agregar cuenta al banco

                        //Random random = new Random();

                        Cuenta cuentaNueva = new Cuenta(1005, "Di Chiano", "12345678", 90000);

                        AgregarNuevaCuenta(b, cuentaNueva); // agrega cuenta

                        break; 

                    case 2: // Eliminar cuenta del banco

                        int numeroCuenta = 1001;

                        EliminarCuenta(b, numeroCuenta);
                        break;

                    case 3: // Lista de clientes que tiene mas de una cuenta

                        string dni = "12345678";

                        ClienteCuentas(b, dni);
                        break;

                    case 4: // Realizar Extraccion

                        int numeroCuentaExtraer = 1002;

                        double extraer = 10000;

                        Extraccion(b, numeroCuentaExtraer, extraer);
                        break;

                    case 5: // Depositar dinero

                        int numeroCuentaDepositar = 1002;

                        double depositar = 5000;

                        Deposito(b, numeroCuentaDepositar, depositar);
                        break;

                    case 6: // Transferencia de dinero entre dos cuentas

                        int numeroCuentaOrigen = 1002;

                        int numeroCuentaDestino = 1003;

                        double transferir = 2000;

                        Transferir(b, numeroCuentaOrigen, numeroCuentaDestino, transferir);
                        break;

                    case 7: // Mostrar lista Clientes

                        MostrarListaClientes(b);
                        break;

                    case 8: // Mostrar lista Cuentas

                        MostrarListaCuentas(b);
                        break;

                    case 9:

                        Console.WriteLine("Saliendo!");
                        break;
                }
                Console.WriteLine();
            }while (opcion!=9);
        }


        public static void MostrarListaClientes(Banco b)
        {
            Console.WriteLine("\n--- LISTA DE CLIENTES ---");

            foreach (Cliente c in b.GetListaClientes())
            {
                Console.WriteLine(
                    $"Apellido: {c.Apellido} | Nombre: {c.Nombre} | DNI: {c.Dni} | Dirección: {c.Direccion} | Mail: {c.Mail} | Tel: {c.Telefono}"
                );
            }
        }

        public static void MostrarListaCuentas(Banco b)
        {
            Console.WriteLine("\n--- LISTA DE CUENTAS ---");

            foreach (Cuenta c in b.GetListaCuentas())
            {
                Console.WriteLine(
                    $"Cuenta: {c.NumeroCuenta} | Apellido: {c.Apellido} | DNI: {c.Dni} | Saldo: {c.Saldo}"
                );
            }
        }
        public static void AgregarNuevaCuenta(Banco b, Cuenta cuenta)
        {
            bool igual = false;

            foreach (var c in b.GetListaCuentas())
            {
                if (c.Dni == cuenta.Dni)
                {
                    igual = true;
                    break;
                }
            }

            if (igual == false)
            {
                Cliente clienteNuevo = AgregarNuevoCliente();

                b.AgregarNuevoCliente(clienteNuevo);

                Console.Write("\nCliente nuevo agregado.");
            }

            b.AgregarNuevaCuenta(cuenta);

            cuenta.Deposito(250000);

            Console.Write("\nCuenta agregada.");
        }
        public static Cliente AgregarNuevoCliente()
        {
            Cliente cliente = new Cliente();

            Console.WriteLine("Apellido: ");
            cliente.Apellido = Console.ReadLine();
            Console.WriteLine("Nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.WriteLine("DNI: ");
            cliente.Dni = Console.ReadLine();
            Console.WriteLine("Direccion: ");
            cliente.Direccion = Console.ReadLine();
            Console.WriteLine("Mail: ");
            cliente.Mail = Console.ReadLine();
            Console.WriteLine("Telefono: ");
            cliente.Telefono = Console.ReadLine();

            return cliente;
        }
        public static void EliminarCuenta(Banco b, int numeroCuenta)
        {
            Cuenta eliminarCuenta = null;

            foreach (Cuenta c in b.GetListaCuentas())
            {
                if (c.NumeroCuenta == numeroCuenta)
                {
                    eliminarCuenta = c;
                    break;
                }
            }
           
            if (eliminarCuenta == null)
            {
                Console.WriteLine("\nLa cuenta no existe.");
                return;
            }
            
            b.EliminarCuenta(eliminarCuenta);
            Console.WriteLine("\nCuenta eliminada.");

            bool cuentas = false;

            foreach (Cuenta c in b.GetListaCuentas())
            {
                if (c.Dni == eliminarCuenta.Dni)
                {
                    cuentas = true;
                    break;
                }
            }

            if (!cuentas)
            {
                Cliente eliminarCliente = null;

                foreach (Cliente c in b.GetListaClientes())
                {
                    if (c.Dni == eliminarCuenta.Dni)
                    {
                        eliminarCliente = c;
                        break;
                    }
                }

                if (eliminarCliente != null)
                {
                    b.EliminarCliente(eliminarCliente);
                    Console.WriteLine("\nCliente eliminado.");
                }  
            }
        }
        public static void ClienteCuentas(Banco b, string dni)
        {
            int contador = 0;
            
            Console.WriteLine($"\nCuentas con DNI {dni}");

            for (int i = 0; i < b.GetListaCuentas().Count; i++)
            {
                if (b.GetListaCuentas()[i].Dni == dni)
                {
                    contador++;
                }
            }
            
            if (contador > 1)
            {
                foreach(Cuenta c in b.GetListaCuentas())
                {
                    if (c.Dni == dni)
                    {
                        Console.WriteLine($"\nCuenta N° {c.NumeroCuenta} - Saldo: {c.Saldo}");
                    }
                }
            }

            Console.WriteLine($"\nTotal: {contador}");
        }
        public static void Transferir(Banco b,int cuenta1, int cuenta2, double transferir)
        {
            Cuenta c1 = null;
            Cuenta c2 = null;

            foreach (Cuenta c in b.GetListaCuentas())
            {
                if (c.NumeroCuenta == cuenta1)
                {
                    c1 = c;
                    break;
                }
            }

            foreach (Cuenta c in b.GetListaCuentas())
            {
                if (c.NumeroCuenta == cuenta2)
                {
                    c2 = c;
                    break;
                }
            }

            if (transferir > c1.Saldo)
            {
                throw new Exception("\nSaldo insuficiente para transferir");
            }

            c1.Saldo -= transferir;
            c2.Saldo += transferir;
            
            Console.WriteLine($"\nTransferencia exitosa.");
            Console.WriteLine($"\nNuevo saldo cuenta {cuenta1}: {c1.Saldo}");
            Console.WriteLine($"\nNuevo saldo cuenta {cuenta2}: {c2.Saldo}");
        }

        public static void Deposito(Banco b, int numeroCuenta, double deposito)
        {
            foreach(Cuenta c in b.GetListaCuentas())
            {
                if(c.NumeroCuenta == numeroCuenta)
                {
                    c.Deposito(deposito);
                    Console.WriteLine($"\nSaldo actual: {c.Saldo}");
                    break;
                }
            }
        }
        public static void Extraccion(Banco b, int numeroCuenta, double extraccion)
        {
            foreach (Cuenta c in b.GetListaCuentas())
            {
                if (c.NumeroCuenta == numeroCuenta)
                {
                    if (extraccion > c.Saldo)
                    {
                        throw new Exception("\nSaldo insuficiente");
                    }

                    c.Extraccion(extraccion);

                    Console.WriteLine($"\nSaldo actual: {c.Saldo}");
                    break;
                }
            }        
        }

        public static void CargarClientesDesdeArchivo(Banco b, string ruta)
        {
            string[] lineas = File.ReadAllLines(ruta);

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(';');

                Cliente c = new Cliente(
                    datos[0],
                    datos[1],
                    datos[2],
                    datos[3],
                    datos[4],
                    datos[5]
                );

                b.GetListaClientes().Add(c);
            }
        }

        public static void CargarCuentasDesdeArchivo(Banco b, string ruta)
        {
            string[] lineas = File.ReadAllLines(ruta);

            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(';');

                Cuenta cuenta = new Cuenta(
                    int.Parse(datos[0]),
                    datos[1],
                    datos[2],
                    double.Parse(datos[3])
                );

                b.GetListaCuentas().Add(cuenta);
            }
        }
    }

    public class excepcionMenu : Exception
    {
        public excepcionMenu() : base("------------------------------->" + "  Opcion invalida, intente nuevamente!" + "             ")
        { }
        public excepcionMenu(string mensaje) : base(mensaje) { }

    }
}