using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace DesafioProjetoHospedagem.Models
{
    public class LeituraArquivo
    {
        //construtor
        public LeituraArquivo()
        {
            //this.VerificarSeExisteArquivo();
        }

        public bool VerificarSeExisteArquivo(string caminhoArquivo)
        {
            //string caminhoArquivo = @"Arquivos/suites.json";
            //Console.WriteLine("leitura arquivo " + caminhoArquivo);
            return File.Exists(caminhoArquivo) ? true : false;
        }

        public static void MontarArquivoSuites()
        {
            //Criando suites VERIFICAR E MUDAR PARA UMA CLASS
            List<Suite> listSuite = new List<Suite>();

            Suite suiteMaster = new Suite(tipoSuite: "MASTER", capacidade: 6, valorDiaria: 80);
            Suite suitePremium = new Suite(tipoSuite: "PREMIUM", capacidade: 4, valorDiaria: 70);
            Suite suiteDuplex = new Suite(tipoSuite: "DUPLEX", capacidade: 2, valorDiaria: 30);

            listSuite.Add(suiteMaster);
            listSuite.Add(suitePremium);
            listSuite.Add(suiteDuplex);

            CriarArquivoSerialize(listSuite);
        }

        public static void CriarArquivoSerialize(List<Suite> listSuite)
        {
            //Criando um serialize
            string suiteSeialize = JsonConvert.SerializeObject(listSuite, Formatting.Indented);

            File.WriteAllText("Arquivos/suites.json", suiteSeialize);

            Suite suiteTeste = new Suite(tipoSuite: "TESTE", capacidade: 10, valorDiaria: 130);
            listSuite.Add(suiteTeste);

            suiteSeialize = JsonConvert.SerializeObject(listSuite, Formatting.Indented);
            File.WriteAllText("Arquivos/suites.json", suiteSeialize);

            //string curFile = @"Arquivos/suites.json";
            //Console.WriteLine(" Se existe arquivo " + File.Exists(curFile));
        }

        public void LerArquivo(string caminho)
        {
            try
            {
                string conteudo = File.ReadAllText(caminho);

                List<Suite> listSuites = JsonConvert.DeserializeObject<List<Suite>>(conteudo);

                foreach (Suite cont in listSuites)
                {
                    Console.WriteLine($"{cont.TipoSuite}");
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}