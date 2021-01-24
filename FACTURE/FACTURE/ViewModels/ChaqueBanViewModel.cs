using System;
using System.Collections.Generic;
using System.Text;
using FACTURE.Models;
namespace FACTURE.ViewModels
{
    public class ChaqueBanViewModel :BaseViewModel
    {
        public int Id_Ban { get; set; }

        public ChaqueBanViewModel() { }

        public ChaqueBanViewModel(ChaqueBan chaqueBan)
        {
            Id_Ban = chaqueBan.Id_Ban;
            _Nom_Ban = chaqueBan.Nom_Ban;
            _Date_Ban = chaqueBan.Date_Ban;

        }
        private string _Nom_Ban;
        public string Nom_Ban
        {
            get { return _Nom_Ban; }
            set
            {
                SetValue(ref _Nom_Ban, value);
                OnPropertyChanged(nameof(Nom_Ban));
            }
        }
        private DateTime _Date_Ban;
        public DateTime Date_Ban
        {
            get { return _Date_Ban; }
            set
            {
                SetValue(ref _Date_Ban, value);
                OnPropertyChanged(nameof(Date_Ban));
            }
        }
    }
}
