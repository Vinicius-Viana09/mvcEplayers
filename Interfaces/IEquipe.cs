using System.Collections.Generic;
using mvc_eplayers.Models;

namespace mvc_eplayers.Interfaces
{
    public interface IEquipe
    {
         void Criar(Equipe e);

         List<Equipe> LerTodas();

         void Alterar(Equipe q);

         void Deletar(int id);
    }
}