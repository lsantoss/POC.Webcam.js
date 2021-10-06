using FormWebcamJs.Domain.Models.Pessoa;
using System.Collections.Generic;

namespace FormWebcamJs.Domain.Interfaces.Repositories
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