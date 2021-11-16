using ApiCatalogoJogos.Entity;
using ApiCatalogoJogos.InputModels;
using ApiCatalogoJogos.ViewModels;
using AutoMapper;

namespace ApiCatalogoJogos.Profiles
{
    public class JogoProfile : Profile
    {
        public JogoProfile()
        {
            CreateMap<JogoInputModel, Jogo>();
            CreateMap<Jogo, JogoViewModel>();
        }
    }
}
