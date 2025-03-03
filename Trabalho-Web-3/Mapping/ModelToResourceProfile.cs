using AutoMapper;
using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Resources;

namespace Trabalho_Web_3.Mapping
{
    public class ModelToResourceProfile : Profile
    { 
        public ModelToResourceProfile()
        {
            CreateMap<Contato, ContatoResource>();
            CreateMap<SaveContatoResource, Contato>();

            CreateMap<Experiencia, ExperienciaResource>();
            CreateMap<SaveExperienciaResource, Experiencia>();

            CreateMap<Projeto, ProjetoResource>();
            CreateMap<SaveProjetoResource, Projeto>();

            CreateMap<Qualificacao, QualificacaoResource>();
            CreateMap<SaveQualificacaoResource, Qualificacao>();
        }
    }
}
