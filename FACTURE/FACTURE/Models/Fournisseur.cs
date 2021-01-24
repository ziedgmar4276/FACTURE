using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FACTURE.Models
{
    [Table("Fournisseur")]
    public class Fournisseur
    {
        [PrimaryKey,AutoIncrement]
        public int Id_Fournisseur { get; set; }
        [MaxLength(255)]
        public string Nom_Fournisseur { get; set; }


    }
}
