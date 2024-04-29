using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneCompany.Models;
/// <summary>
/// Модель описания Телефонного разговора
/// </summary>
public class Conversation
{
    public int Id { get; set; }
    public int AbonentId { get; set; }
    public int CityId { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfMinutes { get; set; }
    [MaxLength(4)]public string TimeOfDay { get; set; }

    [NotMapped] public decimal Price { get; set; }
    public virtual Abonent Abonent { get; set; }
    public virtual City City { get; set; }
}