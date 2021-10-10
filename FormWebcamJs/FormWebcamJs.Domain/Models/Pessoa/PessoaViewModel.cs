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
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "O campo Data de Nascimento não é uma data válida")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Email", Prompt = "Digite o email")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(50, ErrorMessage = "O campo Email não pode ultrapassar 50 caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Senha", Prompt = "Digite a senha")]
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "O campo Senha não pode ultrapassar 50 caracteres.")]
        public string Senha { get; set; }

        [Display(Name = "Imagem", Prompt = "Escolha a imagem")]
        [Required(ErrorMessage = "O campo Imagem é obrigatório")]
        public string ImagemBase64String { get; set; }
    }
}