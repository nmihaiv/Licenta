using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogCarti.API.Model
{
    public class Carte
    {
        //Folosim cele doua adnotatii Key si DatabaseGeneratedOption.Identity
        //pentru proprietatea Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Declaram restul proprietatilor care vor face parte din obiectul Carte
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public string Pret { get; set; }
        public int Stoc { get; set; }
        public int StocMinim { get; set; }
    }
}
