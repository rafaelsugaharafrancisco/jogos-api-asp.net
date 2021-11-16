using ApiCatalogoJogos.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public interface IJogoRepository
    {
        List<Jogo> Obter();

        Jogo Obter(int id);

        Jogo Obter(string nome, string produtora);

        Jogo Inserir(Jogo jogo);

        Jogo Atualizar(Jogo jogo);

        void Remover(Jogo jogo);
    }
}
