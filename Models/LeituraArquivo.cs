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

            Suite suiteMaster = new Suite(id: 1, tipoSuite: "MASTER", capacidade: 6, valorDiaria: 80);
            Suite suitePremium = new Suite(id: 2, tipoSuite: "PREMIUM", capacidade: 4, valorDiaria: 70);
            Suite suiteDuplex = new Suite(id: 3, tipoSuite: "DUPLEX", capacidade: 2, valorDiaria: 30);

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

            suiteSeialize = JsonConvert.SerializeObject(listSuite, Formatting.Indented);
            File.WriteAllText("Arquivos/suites.json", suiteSeialize);

            //string curFile = @"Arquivos/suites.json";
            //Console.WriteLine(" Se existe arquivo " + File.Exists(curFile));
        }

        public List<Suite> LerArquivo(string caminho)
        {
            try
            {
                string conteudo = File.ReadAllText(caminho);
                List<Suite> listSuites = JsonConvert.DeserializeObject<List<Suite>>(conteudo);

                /* 
                        foreach (Suite cont in listSuites)
                        {
                            //"TipoSuite": "MASTER","Capacidade": 6, "ValorDiaria": 80.0 
                             Console.WriteLine($"Id: {cont.Id}, Tipo de Suite: {cont.TipoSuite}, Capacidades {cont.Capacidade}, Valor da Diaria: {cont.ValorDiaria:c} ");
                        }
                 */

                return listSuites;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}