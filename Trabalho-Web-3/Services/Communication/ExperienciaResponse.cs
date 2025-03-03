using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Services.Communication
{
    public class ExperienciaResponse : BaseResponse
    {
        public Experiencia Experiencia { get; private set; }

        private ExperienciaResponse(bool success, string message, Experiencia experiencia) : base(success, message)
        {
            Experiencia = experiencia;
        }

        public ExperienciaResponse(Experiencia experiencia) : this(true, string.Empty, experiencia)
        { }

        public ExperienciaResponse(string message) : this(false, message, null)
        { }
    }
}