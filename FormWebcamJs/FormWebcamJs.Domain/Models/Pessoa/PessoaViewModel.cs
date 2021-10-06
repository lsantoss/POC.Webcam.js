using System;
using System.ComponentModel.DataAnnotations;

namespace FormWebcamJs.Domain.Models.Pessoa
{
    public class PessoaViewModel
    {
        [Display(Name = "Id", Prompt = "Digite o Id")]
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "O campo Id deve ser maior ou igual a 1 e menor que 9223372036854775807.")]
        public long Id { get; set; }

        [Display(Name = "Nome", Prompt = "Digite o nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo Nome não pode ultrapassar 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento", Prompt = "Digite a data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Email", Prompt = "Digite o email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo Email não pode ultrapassar 50 caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Senha", Prompt = "Digite a senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo Senha não pode ultrapassar 50 caracteres.")]
        public string Senha { get; set; }

        [Display(Name = "Imagem", Prompt = "Escolha a imagem")]
        [Required(ErrorMessage = "O campo Imagem é obrigatório")]
        public string ImagemBase64String { get; set; }

        public void DefinirImagemBase64StringGenerica()
        {
            ImagemBase64String = "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";
        }
    }
}