using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneCompany.Model.Entities;

public class City
{
    public int Id { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required] [MinLength(0)] public decimal TariffDay { get; set; }
    [Required] [MinLength(0)] public decimal TariffNight { get; set; }
    public ICollection<Conversation> Conversations { get; set; }
}