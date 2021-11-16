using ApiCatalogoJogos.Context;
using ApiCatalogoJogos.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogoContext _jogoContext;

        public JogoRepository(JogoContext jogoContext)
        {
            _jogoContext = jogoContext;
        }
        public Jogo Atualizar(Jogo jogo)
        {
            var jogoAtualizado = _jogoContext.Jogos.Update(jogo);
            _jogoContext.SaveChanges();

            return jogoAtualizado.Entity;
        }

        public Jogo Inserir(Jogo jogo)
        {
            var novoJogo = _jogoContext.Jogos.Add(jogo);
            _jogoContext.SaveChanges();

            return novoJogo.Entity;
        }

        public List<Jogo> Obter()
        {
            return _jogoContext.Jogos.ToList();
        }

        public Jogo Obter(int id)
        {
            return _jogoContext.Jogos
                .FirstOrDefault(jogo => jogo.Id == id);
        }

        public Jogo Obter(string nome, string produtora)
        {
            return _jogoContext.Jogos
                .FirstOrDefault(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora));
        }

        public void Remover(Jogo jogo)
        {
            _jogoContext.Jogos.Remove(jogo);
            _jogoContext.SaveChanges();
        }
    }
}
