namespace BibliotekaMVC.Models
{
    public class Knjiga
    {
            public int Id { get; set; }

            public string Naslov { get; set; }

            public string Autor { get; set; }

            public bool Dostupna { get; set; } = true;
        }
    }

