using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crmLead.Models;

public class Lead
{
    public int id {get; set;}
    [Column(TypeName = "varchar")]
    [MaxLength(30)]
    public string? nombre {get; set;}

    [Column(TypeName = "varchar")]
    [MaxLength(30)]
    public string? apellidop{get; set;}
    
    [Column(TypeName = "varchar")]
    [MaxLength(30)]
    public string? apellidom {get; set;}
    
    public DateTime fechaborn {get; set;}
    
    [Column(TypeName = "varchar")]
    [MaxLength(30)]
    public string? estadoborn {get; set;}
    
    [Column(TypeName = "varchar")]
    [MaxLength(30)]
    public string? rfc {get; set;}
    
    [Column(TypeName = "varchar")]
    [MaxLength(30)]
    public string? curp {get; set;}
 
}