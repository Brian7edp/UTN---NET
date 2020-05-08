using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {

        public Business.Logic.UsuarioLogic UsuarioNegocio
        { get; set; }


        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            int op=0;
            Console.Clear();

            Console.WriteLine("MENU DE OPCIONES");
            Console.WriteLine();
            Console.WriteLine("1– Listado General");
            Console.WriteLine("2– Consulta");
            Console.WriteLine("3– Agregar");
            Console.WriteLine("4– Modificar");
            Console.WriteLine("5– Eliminar");
            Console.WriteLine("6– Salir");
            Console.WriteLine();

            do
            {
                try
                {

                    Console.WriteLine("Ingrese una opcion del menu");
                    op = int.Parse(Console.ReadLine());
                }

                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("La opcion ingresada debe ser un numero entero del menu!");
                }

                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                }
                
            } while (op < 1  || op > 6);


            if (op != 6)
            {
                switch (op)
                {
                    case 1:
                        ListadoGeneral();
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Menu();
                        break;

                    case 2:
                        Consultar();
                        Menu();
                        break;

                    case 3:
                        Agregar();
                        Console.WriteLine();
                        Console.WriteLine("Presione una tecla para continuar");
                        Console.ReadKey();
                        Menu();
                        break;

                    case 4:
                        Modificar();
                        Menu();
                        break;

                    case 5:
                        Eliminar();
                        Menu();
                        break;

                }

            }
        }
        
        
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

       public void MostrarDatos(Usuario usr)
       {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\t Nombre: {0}", usr.Nombre);
            Console.WriteLine("\t\t Apellido: {0}", usr.Apellido);
            Console.WriteLine("\t\t Nombre de usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\t Clave: {0}", usr.Clave);
            Console.WriteLine("\t\t Email: {0}", usr.Email);
            Console.WriteLine("\t\t Habilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }


        public void Consultar()
        {
            try
            {

                Console.Clear();
                Console.WriteLine("Ingresar el ID de usuario a consultar");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }

            catch(FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La opcion ingresada debe ser un numero entero!");
            }

            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }


        public void Modificar()
        {
            try
            {

                Console.Clear();
                Console.WriteLine("Ingresar el ID de usuario a modificar");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese email: ");
                usuario.Email = Console.ReadLine();
                Console.WriteLine("Ingrese habilitacion del usuario (1-Si / Otro-No): ");
                usuario.Habilitado = (Console.ReadLine()=="1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La opcion ingresada debe ser un numero entero!");
            }

            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.WriteLine("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese clave: ");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese email: ");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingrese habilitacion del usuario (1-Si / Otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
        }

        public void Eliminar()
        {
            try
            {

                Console.Clear();
                Console.WriteLine("Ingresar el ID de usuario a eliminar");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
                
            }

            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La opcion ingresada debe ser un numero entero!");
            }

            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }

        }






    }


}

