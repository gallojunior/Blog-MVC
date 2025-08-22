using System.ComponentModel.DataAnnotations;

namespace BlogGallo.Models;

public class LoginVM
{
    [Required(ErrorMessage = "Campo Obrigatório")]
    [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
    [Display(Name = "E-mail de Acesso", Prompt = "E-mail de Acesso")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [Display(Name = "Senha de Acesso", Prompt = "Senha de Acesso")]
    public string Password { get; set; }

    [Display(Name = "Manter Conectado?")]
    public bool RememberMe { get; set; } = false;

    public string ReturnUrl { get; set; } = "";
}
