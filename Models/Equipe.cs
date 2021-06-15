using System;
using System.Collections.Generic;
using System.IO;
using mvc_eplayers.Interfaces;

namespace mvc_eplayers.Models
{
    public class Equipe : EplayersBase, IEquipe
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        private const string CAMINHO = "DataBase/equipe.csv";

        public Equipe(){
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Alterar(Equipe e)
        {
            List<string> linhas = LerTodasLinhascsv(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(Preparar(e));
            Reescrevercsv(CAMINHO, linhas);
        }

        public void Criar(Equipe e)
        {
            string[] linha = {Preparar(e)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhascsv(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            Reescrevercsv(CAMINHO, linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();

                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }

            return equipes;
        }
    }
}