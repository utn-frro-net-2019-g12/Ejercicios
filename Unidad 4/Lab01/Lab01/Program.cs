using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Lab01 {
    class Program {
        static void Main(string[] args) {

            // Leer Caracter por Caracter
            Console.WriteLine("Leer Texto Caracter por Caracter: ");
            FileStream lector1 = new FileStream("agenda.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            while (lector1.Length > lector1.Position) {
                Console.Write((char)lector1.ReadByte());
            }
            lector1.Close();
            Console.WriteLine();

            // Leer Línea por Línea
            Console.WriteLine("Leer Texto Línea por Línea: ");
            StreamReader lector2 = File.OpenText("agenda.txt");
            string linea;
            do {
                linea = lector2.ReadLine();
                if (linea != null) {
                    Console.WriteLine(linea);
                }
            } while (linea != null);
            lector2.Close();
            Console.WriteLine();

            // Leer Línea por Línea, usar Split, y Extraer Método
            Console.WriteLine("Leer Texto Línea por Línea (Más Lindo): ");
            LeerBetter("agenda.txt");
            Console.WriteLine();

            // Agregar Nuevas Entradas al Texto, y Luego volver a Leerlo:
            Escribir("agenda.text");
            Console.WriteLine("\nEl Texto Actualizado es:");
            LeerBetter("agenda.text");
            Console.WriteLine();

            // Generar y luego leer un Archivo XML con los datos del Texto Anterior
            Console.WriteLine("Presione una tecla para generar el archivo 'agendaxml.xml' con los datos de 'agenda.txt'");
            Console.ReadKey();
            EscribirXML("agendaxml.xml", "agenda.txt");
            Console.WriteLine("\nArchivo agendaxml.xml generado correctamente\nPresione una tecla para ver su contenido");
            Console.ReadKey();
            Console.WriteLine();
            LeerXML("agendaxml.xml");
            Console.ReadKey();

        }

        private static void LeerBetter(string texto) {
            StreamReader lectorMejor = File.OpenText(texto);
            string lineaMejor;
            do {
                lineaMejor = lectorMejor.ReadLine();
                if (lineaMejor != null) {
                    string[] valores = lineaMejor.Split(';');
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", valores[0], valores[1], valores[2], valores[3]);
                }
            } while (lineaMejor != null);
            lectorMejor.Close();
        }

        private static void Escribir(string texto) {
            StreamWriter escritor = File.AppendText(texto);
            Console.WriteLine("Ingrese Nuevo Contacto:");
            String rta = "S";
            while (rta == "S") {
                Console.Write("Ingrese Nombre: ");
                string Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                string Apellido = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                string Email = Console.ReadLine();
                Console.Write("Ingrese Teléfono: ");
                string Telefono = Console.ReadLine();
                Console.WriteLine();

                escritor.WriteLine(Nombre + ';' + Apellido + ';' + Email + ';' + Telefono);

                Console.Write("¿Desea Ingresar Otro Contacto? (S/N)");
                rta = Console.ReadLine().ToUpper();
            }
            escritor.Close();
            
        }

        private static void EscribirXML(string xmlfile, string texto) {
            XmlTextWriter escritorXML = new XmlTextWriter(xmlfile, null);
            escritorXML.Formatting = Formatting.Indented; // Identación para el XML
            escritorXML.WriteStartDocument(true);
            escritorXML.WriteStartElement("DocumentElement");
            // Este Elemento no es necesario, lo agregamos para compatibilidad con los XML generados en el siguiente laboratorio
            StreamReader lector = File.OpenText(texto);
            string linea;
            do {
                linea = lector.ReadLine();
                if (linea != null) {
                    string[] valores = linea.Split(';');
                    escritorXML.WriteStartElement("contactos");
                    escritorXML.WriteStartElement("nombre");
                    escritorXML.WriteValue(valores[0]);
                    escritorXML.WriteEndElement(); // Cerramos el Tag de Nombre
                    escritorXML.WriteStartElement("apellido");
                    escritorXML.WriteValue(valores[1]);
                    escritorXML.WriteEndElement(); // Cerramos el Tag de Apellido
                    escritorXML.WriteStartElement("email");
                    escritorXML.WriteValue(valores[2]);
                    escritorXML.WriteEndElement(); // Cerramos el Tag de Email
                    escritorXML.WriteStartElement("telefono");
                    escritorXML.WriteValue(valores[3]);
                    escritorXML.WriteEndElement(); // Cerramos el Tag de Teléfono
                    escritorXML.WriteEndElement(); // Cerramos el Tag de Contactos
                }
            } while (linea != null);
            escritorXML.WriteEndElement(); // Cerramos el Tag de DocumentElement
            escritorXML.WriteEndDocument();
            escritorXML.Close();
            lector.Close();
        }

        private static void LeerXML(string xmlfile) {
            XmlTextReader lectorXML = new XmlTextReader(xmlfile);
            string tagAnterior = "";
            while (lectorXML.Read()) {
                if (lectorXML.NodeType == XmlNodeType.Element) {
                    tagAnterior = lectorXML.Name;
                } else if (lectorXML.NodeType == XmlNodeType.Text) {
                    Console.WriteLine(tagAnterior + ": " + lectorXML.Value);
                }
            }
            lectorXML.Close();

        }

    }
}
