using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola {
    public class Usuarios {
        public Usuarios() {
            this.UsuarioNegocio = new UsuarioLogic();
        }

        private Business.Logic.UsuarioLogic _UsuarioNegocio;

        public Business.Logic.UsuarioLogic UsuarioNegocio { get; set; }

        public void Menu() {
            string opt = "0";
            bool salir = false;
            while (!salir) {
                while (opt != "1" && opt != "2" && opt != "3" && opt != "4" && opt != "5" && opt != "6") {
                    Console.Clear();
                    Console.WriteLine("\tMENU - CONSOLA ACADEMIA");
                    Console.WriteLine("\tElija una Opción:");
                    Console.WriteLine();
                    Console.WriteLine("\t1– Listado General");
                    Console.WriteLine("\t2– Consultar");
                    Console.WriteLine("\t3– Agregar");
                    Console.WriteLine("\t4– Modificar");
                    Console.WriteLine("\t5– Eliminar");
                    Console.WriteLine("\t6– Salir");
                    Console.WriteLine();
                    Console.Write("\tOpción: ");
                    opt = Console.ReadLine();
                }

                switch (opt) {
                    case "1": ListadoGeneral(); break;
                    case "2": Consultar(); break;
                    case "3": Agregar(); break;
                    case "4": Modificar(); break;
                    case "5": Eliminar(); break;
                    case "6": {
                            Console.WriteLine("\n\tADIÓS!");
                            Console.WriteLine("\tPresione una Tecla para Continuar...");
                            Console.Write("\t");
                            Console.ReadKey();
                            salir = true;
                            break;
                        }
                    default: break;
                }

                // Reset Loop
                opt = "0";
            }
        }

        public void MostrarDatos(Usuario usr) {
            Console.WriteLine("\t\tUsuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

        public void ListadoGeneral() {
            try {
                Console.Clear();
                foreach (Usuario usr in UsuarioNegocio.GetAll()) {
                    this.MostrarDatos(usr);
                }
            } catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine("\t" + e.Message);
            } finally {
                Console.WriteLine();
                Console.WriteLine("\tPresione una Tecla para Continuar...");
                Console.Write("\t");
                Console.ReadKey();
            }
        }

        public void Consultar() {
            try {
                Console.Clear();
                Console.Write("\tIngrese el ID del Usuario a Consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            } catch (FormatException e) {
                Console.WriteLine();
                Console.WriteLine("\tLa ID Ingresada Debe ser un Número Entero");
            } catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine("\t" + e.Message);
            } finally {
                Console.WriteLine();
                Console.WriteLine("\tPresione una Tecla para Continuar...");
                Console.Write("\t");
                Console.ReadKey();
            }
        }

        public void Agregar() {
            try {
                Usuario usuario = new Usuario();
                Console.Clear();
                Console.Write("\tIngrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("\tIngrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("\tIngrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("\tIngrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("\tIngrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("\tIngrese Habilitación de Usuario (1 = Si /// otro = No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.New;
                UsuarioNegocio.Save(usuario);
                Console.WriteLine("\tUsuario Agregado con el ID: {0}", usuario.ID);
            } catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine("\t" + e.Message);
            } finally {
                Console.WriteLine();
                Console.WriteLine("\tPresione una Tecla para Continuar...");
                Console.Write("\t");
                Console.ReadKey();
            }
        }

        public void Modificar() {
            try {
                Console.Clear();
                Console.Write("\tIngrese el ID del Usuario a Modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("\tIngrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("\tIngrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("\tIngrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("\tIngrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("\tIngrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("\tIngrese Habilitación de Usuario (1 = Si /// otro = No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
                Console.WriteLine("\tUsuario Modificado Correctamente");
            } catch (FormatException e) {
                Console.WriteLine();
                Console.WriteLine("\tLa ID Ingresada Debe ser un Número Entero");
            } catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine("\t" + e.Message);
            } finally {
                Console.WriteLine();
                Console.WriteLine("\tPresione una Tecla para Continuar...");
                Console.Write("\t");
                Console.ReadKey();
            }
        }

        public void Eliminar() {
            try {
                Console.Clear();
                Console.Write("\tIngrese el ID del Usuario a Eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
                Console.WriteLine("\tUsuario Eliminado Correctamente");
            } catch (FormatException e) {
                Console.WriteLine();
                Console.WriteLine("\tLa ID Ingresada Debe ser un Número Entero");
            } catch (Exception e) {
                Console.WriteLine();
                Console.WriteLine("\t" + e.Message);
            } finally {
                Console.WriteLine();
                Console.WriteLine("\tPresione una Tecla para Continuar...");
                Console.Write("\t");
                Console.ReadKey();
            }
        }

    }
}
