using System;
using System.Xml;
using System.Xml.Schema;

namespace validarDTD
{
    class Program
    {
        static bool DocumentoValido = true;
        static string Mensagem = "";

        private static void ErroValidacao(object sender, ValidationEventArgs e)
        {
            DocumentoValido = false;
            Mensagem = "Erro: " + e.Message;
        }

        static void Main(string[] args)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ErroValidacao);

            try
            {
                XmlReader reader = XmlReader.Create(@"aiml2.xml", settings);

                while (reader.Read()) ;

                if (DocumentoValido)
                    Console.WriteLine("O documento XML está de acordo com o DTD");
                else
                    Console.WriteLine(Mensagem);

                reader.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível encontrar um ou dois arquivos. Coloque os dois arquivos na mesma pasta deste programa.");
            }

            Console.ReadKey();
        }
    }
}
