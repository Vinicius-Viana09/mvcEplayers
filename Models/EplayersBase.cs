using System.Collections.Generic;
using System.IO;

namespace mvc_eplayers.Models
{
    public abstract class EplayersBase
    {
        public void CriarPastaEArquivo(string caminho)
        {

            string pasta = caminho.Split("/")[0];
            string arquivo = caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close();
            }
        }


        public List<string> LerTodasLinhascsv(string caminho)
        {

            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(caminho))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }

            }

            return linhas;
        }


        public void Reescrevercsv(string caminho, List<string> linhas)
        {
            using (StreamWriter output = new StreamWriter(caminho))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}