using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Services.Communication
{
    public class QualificacaoResponse : BaseResponse
    {
        public Qualificacao Qualificacao { get; private set; }

        private QualificacaoResponse(bool success, string message, Qualificacao qualificacao) : base(success, message)
        {
            Qualificacao = qualificacao;
        }

        public QualificacaoResponse(Qualificacao qualificacao) : this(true, string.Empty, qualificacao)
        { }

        public QualificacaoResponse(string message) : this(false, message, null)
        { }
    }
}
