using ApiCatalogoJogos.Exceptions;
using ApiCatalogoJogos.InputModels;
using ApiCatalogoJogos.Services;
using ApiCatalogoJogos.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }
        [HttpGet]
        public ActionResult<List<JogoViewModel>> Obter()
        {
            var jogos = _jogoService.Obter();

            if (jogos.Count == 0)
            {
                return NoContent();
            }

            return Ok(jogos);
        }

        [HttpGet("{id:int}")]
        public ActionResult<JogoViewModel> Obter([FromRoute] int id) 
        {
            var jogo = _jogoService.Obter(id);

            if (jogo == null)
            {
                return NotFound();
            }
            
            return Ok(jogo);
        }

        [HttpPost]
        public ActionResult<JogoViewModel> InserirJogo([FromBody] JogoInputModel novoJogo)
        {
            try
            {
                var jogo = _jogoService.Inserir(novoJogo);

                return Created("",jogo);

            }catch(JogoJaCadastradoException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult AtualizarJogo([FromRoute] int id, [FromBody] JogoInputModel jogo)
        {
            try
            {
                var jogoAtualizado = _jogoService.Atualizar(id, jogo);

                return Ok(jogoAtualizado);

            } catch(JogoNaoCadastradoException e)
            {
                return NotFound(e.Message);
            }
            
        }

        [HttpPatch("{id:int}/{preco:double}")]
        public ActionResult AtualizarJogo([FromRoute] int id, [FromRoute] double preco)
        {
            try
            {
                var jogoAtualizado = _jogoService.Atualizar(id, preco);

                return Ok(jogoAtualizado);

            } catch(JogoNaoCadastradoException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeletarJogo([FromRoute] int id)
        {
            try
            {
                _jogoService.Remover(id);

                return NoContent();

            } catch(JogoNaoCadastradoException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
