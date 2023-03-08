using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProjectMCC75.Models
{
    [Table("tb_tr_rey_account_roles")]
    public class AccountRole
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("accountid", TypeName = "nchar(3)")]
        public string AccountId { get; set; }
        [Required, Column("role_id")]
        public int RoleId { get; set; }

        //relation n cardinality
        [JsonIgnore]
        [ForeignKey(nameof(AccountId))]
        public Account? Account { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }
    }
}
