using DevOpsPlayground.Domain.Common;

namespace DevOpsPlayground.Domain.Entities;

public class Cliente : BaseEntity
{
    public string Nome { get; private set; }

    public string Email { get; private set; }

    private Cliente()
    {
        Nome = string.Empty;
        Email = string.Empty;
    }

    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    public void AlterarEmail(string email)
    {
        Email = email;
        MarkAsUpdated();
    }
}