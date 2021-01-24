using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace FACTURE.Models
{
    [Table("ChaqueBan")]
    public class ChaqueBan
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Ban { get; set; }
        [MaxLength(255)]
        public string Nom_Ban { get; set; }
        [MaxLength(255)]
        public DateTime Date_Ban { get; set; }
    }
}
