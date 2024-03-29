﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models
{
    [Table("tb_m_rey_roles")]
    public class Role
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Required, Column("name"), MaxLength(50)]
        public string Name { get; set; }

        //cardinality
        [JsonIgnore]
        public ICollection<AccountRole>? AccountRole { get; set; }
    }
}
