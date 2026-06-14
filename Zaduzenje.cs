using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotekaMVC.Models
{
    public class Zaduzenje
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Knjiga je obavezna.")]
        public int KnjigaId { get; set; }
        public Knjiga Knjiga { get; set; }

        [Required(ErrorMessage = "Član je obavezan.")]
        public int ClanId { get; set; }
        public Clan Clan { get; set; }

        public DateTime DatumZaduzenja { get; set; }

        public DateTime? DatumVracanja { get; set; }
        public bool Vraceno { get; set; }
    }
}