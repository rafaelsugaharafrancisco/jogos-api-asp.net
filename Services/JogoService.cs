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
            var jogo = _jogoRepository.Obter(id);

            if (jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }

            _mapper.Map(jogoInput, jogo);

            var jogoAtualizado = _jogoRepository.Atualizar(jogo);

            return _mapper.Map<JogoViewModel>(jogoAtualizado);
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

            return _mapper.Map<JogoViewModel>(jogoAtualizado);
        }

        public JogoViewModel Inserir(JogoInputModel jogo)
        {
            var obtemJogo = _jogoRepository.Obter(jogo.Nome, jogo.Produtora);

            if (obtemJogo != null)
            {
                throw new JogoJaCadastradoException();
            }

            var novoJogo = _mapper.Map<Jogo>(jogo);

            var jogoInserido = _jogoRepository.Inserir(novoJogo);

            return _mapper.Map<JogoViewModel>(jogoInserido);
        }

        public List<JogoViewModel> Obter()
        {
            var jogos = _jogoRepository.Obter();

            return jogos.Select(jogo => _mapper.Map<JogoViewModel>(jogo)).ToList();
        }

        public JogoViewModel Obter(int id)
        {
            var jogo = _jogoRepository.Obter(id);

            if (jogo == null)
            {
                return null;
            }

            return _mapper.Map<JogoViewModel>(jogo);
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
