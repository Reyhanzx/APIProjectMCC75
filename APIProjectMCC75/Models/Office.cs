﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProjectMCC75.Models;

[Table("tb_m_rey_office")]
public class Office
{
    [Key, Column("code")]
    public int Code { get; set; }
    [Required, Column("city"), MaxLength(255)]
    public string City { get; set; }
    [Required, Column("phone number"), MaxLength(255)]
    public string PhoneNumber { get; set; }
    [Required, Column("address1"), MaxLength(255)]
    public string Address1 { get; set; }
    [Column("address2"), MaxLength(255)]
    public string? Address2 { get; set; }
    [Required, Column("state"), MaxLength(255)]
    public string State { get; set; }
    [Required, Column("country"), MaxLength(255)]
    public string Country { get; set; }
    [Required, Column("postal_code"), MaxLength(255)]
    public string PostalCode { get; set; }
    [Required, Column("territory"), MaxLength(255)]
    public string Territory { get; set; }

    //kardinalitas
    [JsonIgnore]
    public ICollection<Employee>? Employees { get; set; }
}
