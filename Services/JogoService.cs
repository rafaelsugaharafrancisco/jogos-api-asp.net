using ApiCatalogoJogos.Entity;
using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.InputModels;
using ApiCatalogoJogos.Repositories;
using ApiCatalogoJogos.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IMapper _mapper;

        public JogoService(IJogoRepository jogoRepository, IMapper mapper)
        {
            _jogoRepository = jogoRepository;
            _mapper = mapper;
        }
        public JogoViewModel Atualizar(int id, JogoInputModel jogoInput)
        {
            var jogo =  _jogoRepository.Obter(id);

            if (jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            jogo.Nome = jogoInput.Nome;
            jogo.Produtora = jogoInput.Produtora;
            jogo.Preco = jogoInput.Preco;


            var jogoAtualizado = _jogoRepository.Atualizar(jogo);


            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogoAtualizado.Nome,
                Produtora = jogoAtualizado.Produtora,
                Preco = jogoAtualizado.Preco
            };

        }

        public JogoViewModel Atualizar(int id, double preco)
        {
            var jogo = _jogoRepository.Obter(id);

            if (jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            jogo.Preco = preco;

            var jogoAtualizado = _jogoRepository.Atualizar(jogo);

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogoAtualizado.Preco
            };

        }

        public JogoViewModel Inserir(JogoInputModel jogo)
        {
            var obtemJogo = _jogoRepository.Obter(jogo.Nome, jogo.Produtora);

            if (obtemJogo != null)
            {
                throw new JogoJaCadastradoException();
            }

            var novoJogo = new Jogo
            {
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };


            var jogoInserido = _jogoRepository.Inserir(novoJogo);

            return new JogoViewModel
            {
                Id = jogoInserido.Id,
                Nome = jogoInserido.Nome,
                Produtora = jogoInserido.Produtora,
                Preco = jogoInserido.Preco
            };

        }

        public List<JogoViewModel> Obter()
        {
            var jogos = _jogoRepository.Obter();

            return jogos.Select(jogos => new JogoViewModel
            {
                Id = jogos.Id,
                Nome = jogos.Nome,
                Produtora = jogos.Produtora,
                Preco = jogos.Preco

            }).ToList();

        }

        public JogoViewModel Obter(int id)
        {
            var jogo = _jogoRepository.Obter(id);

            if (jogo == null)
            {
                return null;
            }

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

        }

        public void Remover(int id)
        {
            var jogo = _jogoRepository.Obter(id);

            if (jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            _jogoRepository.Remover(jogo);
        }
    }
}
