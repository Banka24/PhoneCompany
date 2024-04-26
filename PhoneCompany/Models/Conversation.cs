using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Models;

public class Conversation
{
    public int Id { get; set; }
    public int AbonentId { get; set; }
    public int CityId { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfMinutes { get; set; }
    public int TimeOfDayId { get; set; }

    [NotMapped] public decimal Price { get; set; }
    public virtual TimeOfDay TimeOfDay { get; set; }
    public virtual Abonent Abonent { get; set; }
    public virtual City City { get; set; }
}