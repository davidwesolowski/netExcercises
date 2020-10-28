using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace demo.Domain.Entities
{
    [DataContract]
    public class Product
    {
        
    public Product() {

    }

    public Product(int id, String n, String p, String category) {
        this.id = id;
        this.Name = n;
        this.Price = p;
        this.Category = category;
    }

    [Range(10, 100)]
    [Display(Name = "Moje ID")]
    [Required(ErrorMessage = "Wprowadź {0}")]
    public int id {get; set;}

    [StringLength(100)]
    [Required(ErrorMessage = "Brakuje nazwy")]
    [Display(Name = "Nazwa produktu")]
    [DataMember]
    public String Name {get; set;}

    [Required]
    [StringLength(10)]
    [DataMember]
    public String Price {get; set;}

    [Required]
    [DataMember]
    public String Category { get; set; }
    
    }
    
}