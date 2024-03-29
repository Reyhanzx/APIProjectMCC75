﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIProjectMCC75.Models;

[Table("tb_m_rey_payment")]
public class Payment
{
    [Key, Column("check_num")]
    public int CheckNum { get; set; }
    [Required, Column("customer_id")]
    public int CustomerId { get; set; }
    [Required, Column("payment_date")]
    public DateTime PaymentDate { get; set; }
    [Required, Column("amount")]
    public int Amount { get; set; }
    //relasi
    [JsonIgnore]
    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; }
}
