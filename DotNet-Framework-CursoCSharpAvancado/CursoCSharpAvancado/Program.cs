using Serializador;
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace CursoCSharpAvancado
{
    class Program
    {
        static void Main(string[] args)
        {
            var caminho = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            SerializarDesserializarXml(caminho);
            SerializarDesserializarJSON(caminho);
            Console.ReadLine();
        }

        private static void SerializarDesserializarJSON(string caminho)
        {
            caminho = caminho + @"\testeJSON.json";

            // Serializar
            var jsSerializer = new JavaScriptSerializer();
            string usuarioJSON = jsSerializer.Serialize(PegarUserMock(nome: "Json"));

            //Desserializar
            var usuario = jsSerializer.Deserialize<Usuario>(usuarioJSON);
            ImprimirUsuario(usuario);
        }

        private static void SerializarDesserializarXml(string caminho)
        {
            caminho = caminho + @"\testeXML.xml";

            //Serializar
            StreamWriter stream = new StreamWriter(caminho);
            XmlSerializer serializador = new XmlSerializer(typeof(Usuario));
            serializador.Serialize(stream, PegarUserMock(nome: "Xml"));
            stream.Close();

            // Desserializar
            StreamReader sr = new StreamReader(caminho);
            var usuario = (Usuario)serializador.Deserialize(sr);
            sr.Close();
            ImprimirUsuario(usuario);
        }

        private static void ImprimirUsuario(Usuario usuario)
        {
            Console.WriteLine($"{usuario.Nome} - {usuario.CPF} - {usuario.Email}");
        }

        private static Usuario PegarUserMock(string nome = "Teste", string cpf = "123.456.789-00", string email = "teste@email.com")
        {
            return new Usuario()
            {
                Nome = nome,
                CPF = cpf,
                Email = email
            };
        }
    }
}
