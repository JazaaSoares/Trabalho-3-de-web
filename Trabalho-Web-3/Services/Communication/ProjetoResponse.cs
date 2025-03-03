using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Services.Communication
{
    public class ProjetoResponse : BaseResponse
    {
        public Projeto Projeto { get; private set; }

        private ProjetoResponse(bool success, string message, Projeto projeto) : base(success, message)
        {
            Projeto = projeto;
        }

        public ProjetoResponse(Projeto projeto) : this(true, string.Empty, projeto)
        { }

        public ProjetoResponse(string message) : this(false, message, null)
        { }
    }
}
