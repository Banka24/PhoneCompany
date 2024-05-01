using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneCompany.Models;

/// <summary>
/// Модель описания Абонент
/// </summary>
public class Abonent
{
    public int Id { get; set; }
    [Required][MaxLength(20)] public string PhoneNumber { get; set; }
    [Required][MaxLength(10)] public string Inn { get; set; }
    [Required][MaxLength(255)] public string Address { get; set; }
    public ICollection<Conversation> Conversations { get; set; }
}