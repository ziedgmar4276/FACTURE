using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FACTURE.Models
{
    [Table("Facture")]
    public class Facture
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Facture { get; set; }
        public  int Montant_Facture { get; set; }
        [MaxLength(255)]
        public string type_paiement { get; set; }
      
    }
}
