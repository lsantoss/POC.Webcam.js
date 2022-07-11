using POC.Webcam.js.Domain.Models.Pessoa;
using System.Collections.Generic;

namespace POC.Webcam.js.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        long Salvar(PessoaViewModel pessoa);
        void Atualizar(PessoaViewModel pessoa);
        void Deletar(long id);

        PessoaViewModel Obter(long id);
        List<PessoaViewModel> Listar();
    }
}