namespace CajeroAutomatico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lidentificador="";
            string lpassword="";
            string newPass="";
            int opcion = 0;
            int saldo = 0;
            int cantidadAdepositar = 0;
            int cantidadARetirar = 0;
            string cbuTransferencia = "";
            int montoATransferir =0;
            Console.WriteLine("***** BIENVENIDO A SANTANDER INGRESE SU USUARIO Y CONTRASEÑA *****");
            do
            {
                Console.WriteLine("Ingrese el usuario de su identificador");
                lidentificador = Console.ReadLine();
                Console.WriteLine("Ingrese el Password");  
                lpassword = Console.ReadLine();

            } while (f_validacion(lidentificador, lpassword)); // AGREGAR VALIDACION 3 VECES NOS DIGA GRACIAS .

            // APARTIR DE ACA INGRESA AL MENU
            Console.WriteLine("***** SELECCIONE UNA OPCION *****");
            Console.WriteLine("1. Verificar Saldo.");
            Console.WriteLine("2. Deposito.");
            Console.WriteLine("3. Retiro.");
            Console.WriteLine("4. Transferencia.");
            Console.WriteLine("5. Cambio de Clave.");
            Console.WriteLine("6. Salir.");
            opcion = int.Parse(Console.ReadLine());
     
              //AGREGAR VALIDACION DE TIPO ENTERO Y QUE SEA DEL 1 A 4 (OPCIONES)
          switch (opcion)
            {   
                case 1:                    
                    Console.WriteLine("Su saldo es: " + getverificarSaldo(saldo));
                    break;
                case 2:
                    Console.WriteLine("Ingrese la cantidad que desea depositar en su cuenta");
                    cantidadAdepositar = int.Parse(Console.ReadLine());
                    saldo = setDeposito(saldo, cantidadAdepositar);
                    Console.WriteLine("Su saldo es: " + getverificarSaldo(saldo));
                    break;
                case 3:
                    Console.WriteLine("Ingrese la cantidad que desea retirar de su cuenta");
                    cantidadARetirar = int.Parse(Console.ReadLine());
                    if (validarSaldo(saldo, cantidadARetirar)) { 
                    saldo = retiroSaldo(saldo, cantidadARetirar);
                    }
                    else
                    {
                        Console.WriteLine("Bloqueado...");  
                    }
                    Console.WriteLine("Su saldo actual es : " + saldo);
                    break;
                case 4:
                    Console.WriteLine("Ingrese el CBU a donde quiera hacer la transferencia");
                    cbuTransferencia = Console.ReadLine();
                    Console.WriteLine("Ingrese la cantidad que desea transferir");
                    montoATransferir = int.Parse(Console.ReadLine());

                    if (validarSaldo(saldo, montoATransferir))
                    {
                       saldo = setTransferencia(saldo, montoATransferir);
                        Console.WriteLine("Se realizo la transferencia exitosamente su saldo actual es : " + saldo);
                    }else
                    {
                        Console.WriteLine("Operacion Rechazada");
                    }                   
                    break;
                case 5:

                    lpassword = cambioClave(lpassword, newPass);
                    Console.WriteLine("OPCIONES 5");
                    break;
                case 6:

                    Console.WriteLine("CHAU HASTA LUEGO");
                    break;
                default:
                    Console.WriteLine("OPCION ICONRRECTA");
                    break;
            }

        }
        public static Boolean f_validacion(string user, string pass)
        {
            bool lreturn = false;
            if (user == "1234" & pass == "1111")
            {   
                lreturn = true;
            }
            else
            {
                Console.WriteLine("Error de Ingreso, Vuelva a Ingresar");
            }
            return lreturn;
        }
        public static int getverificarSaldo(int saldo)
        {
           return saldo; 
        }
        public static int setDeposito(int saldo, int cantidadDepositada) 
        {   
            saldo = saldo + cantidadDepositada;
            return saldo; 
        
        }
        public static int retiroSaldo(int saldo, int cantidadDeRetiro)
        {
            saldo = saldo - cantidadDeRetiro;
            return saldo;
        }
        public static int setTransferencia(int saldo, int transferencia)
        {
            saldo = saldo - transferencia;
            return saldo;
        }
        public static bool validarSaldo(int saldo ,int movimiento)
        {
            bool cuentaConSaldo = false;
            while (cuentaConSaldo = false)
            {                             

                if (saldo >= movimiento)
                {

                    cuentaConSaldo = true;
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente seleccione otro importe");
                    cuentaConSaldo = false;
                }
               
            }
            return cuentaConSaldo = false;
        }
        public static string cambioClave(String clave, String nuevaClave)
        {
           return clave = nuevaClave;
        }
    }
}