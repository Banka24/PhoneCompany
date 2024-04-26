using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneCompany.Models;

public class TimeOfDay
{
    public int Id { get; set; }
    [Required][MaxLength(4)] public string Title { get; set; }
    public ICollection<Conversation> Conversations { get; set; }
}