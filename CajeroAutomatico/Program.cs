namespace CajeroAutomatico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool valido = false;
            String finalizar = "N";
            string lUseridentificador = "";
            string lpassword = "";
            string newPass = "";
            int opcion = 0;
            int saldo = 1;
            int intentos = 0;
            int cantidadAdepositar = 0;
            int cantidadARetirar = 0;
            string cbuTransferencia = "";
            int montoATransferir = 0;
            string[] opciones = { "1.- Verifica Saldo", "2.- Deposito", "3.- Retiro", "4.- Transferencia", "5.- Cambio de Clave", "6.- Salir" };

            Console.WriteLine("***** BIENVENIDO A SANTANDER INGRESE SU USUARIO Y CONTRASEÑA *****");
            do
            {
                intentos++;
                // validacion de 3 intentos maximo que puedes equivocarte. .
                if (intentos <= 3)
                {
                    Console.WriteLine("Ingrese el usuario de su identificador");
                    lUseridentificador = Console.ReadLine();
                    Console.WriteLine("Ingrese el Password");
                    lpassword = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Demasiados intentos fallidos, Comuniquese con un administrador");
                   
                    break;
                }
            } while (!f_validacion(lUseridentificador, lpassword)); //funcion que valida el password.
            if ((intentos <= 3))
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n***** SELECCIONE UNA OPCION *****");
                foreach (string i in opciones) //RECORRE EL ARRAY Y MUESTRA LAS OPCIONES POR PANTALLA
                    {
                    Console.WriteLine($"{i}"); 
                }
                opcion = int.Parse(Console.ReadLine());
                    //AGREGAR VALIDACION DE TIPO ENTERO Y QUE SEA EL LARGO DEL ARRAY
                    if (opcion is int && opcion <= opciones.Length)
                    {
                        switch (opcion) // VALIDA CADA CASE POR CADA TIPO DE MOVIMIENTO.
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
                                do
                                {
                                    Console.WriteLine("Ingrese la cantidad que desea retirar de su cuenta");
                                    cantidadARetirar = int.Parse(Console.ReadLine());
                                    {
                                        if (validarSaldo(saldo, cantidadARetirar)) //FUNCION VALIDA SI NUESTRO SALDO ES OPTIMO A LA OPERACION
                                        {
                                            saldo = retiroSaldo(saldo, cantidadARetirar);
                                            Console.WriteLine("Su saldo actual es : " + getverificarSaldo(saldo));
                                            break;

                                        }
                                        else if (intentos < 3) //VALIDACION DE 3 INTENTOS FALLIDOS.
                                        {
                                            intentos++;
                                            Console.Clear();
                                            Console.WriteLine("\nSu saldo es insuficiente para la operacion ingrese otro monto");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nDemasiados intentos fallidos seleccione otra opcion");
                                            break;
                                        }
                                    }
                                } while (valido = true);
                                break;
                            case 4:
                                do
                                {
                                    Console.WriteLine("Ingrese el CBU a donde quiera hacer la transferencia");
                                    cbuTransferencia = Console.ReadLine();
                                    Console.WriteLine("Ingrese la cantidad que desea transferir");
                                    montoATransferir = int.Parse(Console.ReadLine());

                                    if (validarSaldo(saldo, montoATransferir))
                                    {
                                        saldo = setTransferencia(saldo, montoATransferir);
                                        Console.WriteLine("Transferencia realizada con exito a la cuenta " + cbuTransferencia);
                                        Console.WriteLine("Su saldo actual es : " + getverificarSaldo(saldo));
                                        //valido = false;
                                        break;
                                    }
                                    else if (intentos < 3)
                                    {
                                        intentos++;
                                        Console.Clear();
                                        Console.WriteLine("\nSu saldo es insuficiente para la operacion ingrese otro monto");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nDemasiados intentos fallidos seleccione otra opcion");
                                        break;
                                    }
                                } while (valido = true);
                                break;
                            case 5:
                                Console.WriteLine("Digite la nueva contraseña");
                                newPass = Console.ReadLine();
                                lpassword = cambioClave(lpassword, newPass);
                                Console.WriteLine("Su contraseña ha sido cambiada por " + lpassword);
                                break;
                            default:
                                Console.WriteLine("Ha Salido de las opciones.\n");
                                break;

                        }
                            Console.WriteLine("\nDesea Realizar otra movimiento?"); 
                            finalizar = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Opcion Incorrecta adios");
                    }              
                                         
                 } while (finalizar == "si"); // SI COLOCAMOS QUE SI AL REALIZAR OTRO MOVIMIENTO NOS VOLVERA APARECER LAS OPCIONES.
                Console.WriteLine("GRACIAS POR USAR NUESTRO BANCO VUELVA PRONTO");               
                Console.ReadKey();
            }
        }
        public static Boolean f_validacion(string user, string pass) // FUNCION QUE VALIDA PASSWORD.
        {
            bool lreturn = false;
            if (user == "1111" & pass == "1111")
            {   
                lreturn = true;
            }
            else
            {
                Console.WriteLine("Error de Ingreso, Vuelva a Ingresar");
            }
            return lreturn;
        }
        public static int getverificarSaldo(int saldo) // FUNCION QUE DEVUELVE EL SALDO SE LO COLOCA ASI POR SI EN UN FUTURO QUEREMOS MODIFICAR CAMBIOS YA SEA UN PARSEO A STRING O EN GENERAL.
        {
           return saldo; 
        }
        public static int setDeposito(int saldo, int cantidadDepositada)  // HACE LA SUMA DEL SALDO ACTUAL POR EL INGRESADO
        {   
            saldo = saldo + cantidadDepositada;
            return saldo; 
        
        }
        public static int retiroSaldo(int saldo, int cantidadDeRetiro)//RESTA SALDO - ACTUAL POR EL INGRESADO
        {
            saldo = saldo - cantidadDeRetiro;
            return saldo;
        }
        public static int setTransferencia(int saldo, int transferencia) // RESTA SALDO  ACTUAL POR EL INGRESADO, NO SE USO RETIRO SALDO YA QUE HACE OTRA COSA SE PUEDE EXPANDIR.
        {
            saldo = saldo - transferencia;
            return saldo;
        }
        public static bool validarSaldo(int saldo ,int movimiento) // ESTA VALIDA SI NEUSTRO SALDO ES OPTIMO AL MOVIMIENTO EN CASO CASE 3, 4
        {
           bool cuentaConSaldo = false;

                if (saldo >= movimiento)
                {
                    cuentaConSaldo = true;
                }
            return  cuentaConSaldo;
        }
        public static string cambioClave(String clave, String nuevaClave) // CAMBIA LA CLAVE VIEJA POR LA INGRESADA.
        {
           return clave = nuevaClave;
        }
      
    }
}