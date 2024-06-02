using System.ComponentModel.DataAnnotations;

namespace Company.Storage.Dtos;

public class CompanyDto
{
    public CompanyDto(Guid id, string name, string phoneDirectional, string phoneNumber, string nip, string regon)
    {
        Id = id;
        Name = name;
        PhoneDirectional = phoneDirectional;
        PhoneNumber = phoneNumber;
        NIP = nip;
        REGON = regon;
    }

    public Guid Id { get; set; }
    
    [MaxLength(256)]
    [Required]
    public string Name { get; set; }
    
    [MaxLength(8)]
    public string PhoneDirectional { get; set; }
    
    [MaxLength(32)]
    public string PhoneNumber { get; set; }

    [MaxLength(32)]
    public string NIP { get; set; } = null!;

    [MaxLength(16)]
    public string REGON { get; set; }

}