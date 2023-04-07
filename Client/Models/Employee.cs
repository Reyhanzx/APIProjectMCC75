using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models;


public class Employee
{
    public string Id { get; set; }
    public int OfficeCode { get; set; }
    public string? ReportsTo { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string JobTitle { get; set; }

    
}
