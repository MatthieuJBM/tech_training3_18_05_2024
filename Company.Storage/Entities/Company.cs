using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Storage.Entities;

[Table("Companies", Schema = "Company")]
public class Company
{
    public Company()
    {
    }

    public Company(string name, string phoneDirectional, string phoneNumber, string nip, string regon)
    {
        Name = name;
        PhoneDirectional = phoneDirectional;
        PhoneNumber = phoneNumber;
        NIP = nip;
        REGON = regon;
    }

    [Key] public Guid Id { get; set; }

    [MaxLength(256)] [Required] public string Name { get; set; }

    [MaxLength(8)] public string PhoneDirectional { get; set; }

    [MaxLength(32)] public string PhoneNumber { get; set; }

    [MaxLength(32)] public string NIP { get; set; } = null!;

    [MaxLength(16)] public string REGON { get; set; }
}