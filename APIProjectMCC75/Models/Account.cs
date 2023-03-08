using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProjectMCC75.Models
{
    [Table("tb_m_rey_accounts")]
    public class Account
    {
        [Key, Column("employee_id", TypeName = "nchar(3)")]
        public string Employee_Id { get; set; }
        [Column("password"), MaxLength(255)]
        public string Password { get; set; } 

        //cardinalitty
        [JsonIgnore]
        public ICollection<AccountRole>? AccountRoles { get; set; }
        [JsonIgnore]
        public Employee? Employee { get; set; }
    }
}
