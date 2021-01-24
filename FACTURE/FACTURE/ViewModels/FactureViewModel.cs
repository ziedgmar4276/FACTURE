using System;
using System.Collections.Generic;
using System.Text;
using FACTURE.Models;
namespace FACTURE.ViewModels
{
   public  class FactureViewModel :BaseViewModel
    {
        public int Id_Facture { get; set; }
        public FactureViewModel() { }
        public FactureViewModel (Facture facture)
        {
            Id_Facture = facture.Id_Facture;
            _Montant_Facture = facture.Montant_Facture;
            _type_paiement = facture.type_paiement;
        }
        private int _Montant_Facture;
        public int  Montant_Facture
        {
            get { return Montant_Facture; }
            set
            {
                SetValue(ref _Montant_Facture, value);
                OnPropertyChanged(nameof(Montant_Facture));
            }
        }
        private string _type_paiement;
        public  string type_paiement
        {
            get { return type_paiement; }
            set
            {
                SetValue(ref _type_paiement, value);
                OnPropertyChanged(nameof(type_paiement));
            }
        }
    }
}
