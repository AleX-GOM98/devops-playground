using System.ComponentModel.DataAnnotations;

namespace DevOpsPlayground.Application.Clientes.DTOs;

public class UpdateClienteDto
{
    [Required]
    [StringLength(150, MinimumLength = 3)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}