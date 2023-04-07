using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;

public class Office
{
    public int Code { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Address1 { get; set; }
    
    public string? Address2 { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
   
    public string PostalCode { get; set; }
  
    public string Territory { get; set; }

    ////kardinalitas
    //[JsonIgnore]
    //public ICollection<Employee>? Employees { get; set; }
}
