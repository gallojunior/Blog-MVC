using System.ComponentModel.DataAnnotations;

namespace BlogGallo.Models;

public class Postagem
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    public DateTime DataPostagem { get; set; }

    public string Descricao { get; set; }

    public string Texto { get; set; }

    public string Foto { get; set; }

    public string Thumbnail { get; set; }
}
