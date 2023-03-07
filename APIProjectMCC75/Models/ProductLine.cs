using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProjectMCC75.Models;

[Table("tb_m_rey_productline")]
public class ProductLine
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("Name"), MaxLength(255)]
    public string Name { get; set; }

    //relasi & kardinalitas
    [JsonIgnore]
    public ICollection<ProductLine>? Products { get; set; }
}
