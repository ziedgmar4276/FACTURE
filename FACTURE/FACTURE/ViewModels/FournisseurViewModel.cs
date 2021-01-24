using FACTURE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FACTURE.ViewModels
{
    public class FournisseurViewModel : BaseViewModel
    {
        public int Id_Fournisseur { get; set; }
        public FournisseurViewModel() { }
        public FournisseurViewModel(Fournisseur fournisseur)
        {
            Id_Fournisseur = fournisseur.Id_Fournisseur;
            _Nom_Fournisseur = fournisseur.Nom_Fournisseur;
        }
        private string _Nom_Fournisseur;
       

        public string Nom_Fournisseur
        {
            get { return _Nom_Fournisseur; }
            set
            {
                SetValue(ref _Nom_Fournisseur, value);
                OnPropertyChanged(nameof(Nom_Fournisseur));
            }
        }
    }
}
