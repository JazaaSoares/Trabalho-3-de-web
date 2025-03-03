using Trabalho_Web_3.Domains.Models;

namespace Trabalho_Web_3.Services.Communication
{
    public class ContatoResponse : BaseResponse
    {
            public Contato Contato { get; private set; }

            private ContatoResponse(bool success, string message, Contato contato) : base(success, message)
            {
                Contato = contato;
            }

            public ContatoResponse(Contato contato) : this(true, string.Empty, contato)
            { }

            public ContatoResponse(string message) : this(false, message, null)
            { }
    }
}
