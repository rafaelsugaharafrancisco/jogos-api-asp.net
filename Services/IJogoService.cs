using ApiCatalogoJogos.InputModels;
using ApiCatalogoJogos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public interface IJogoService
    {
        public List<JogoViewModel> Obter();

        public JogoViewModel Obter(int id);

        public JogoViewModel Inserir(JogoInputModel jogo);

        public JogoViewModel Atualizar(int id, JogoInputModel jogo);

        public JogoViewModel Atualizar(int id, double preco);

        public void Remover(int id);
    }
}
