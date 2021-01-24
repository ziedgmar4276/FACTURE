using System;
using System.Collections.Generic;
using System.Text;

namespace FACTURE.ViewModels
{
    class Events
    {   // Fourniesseur event
        public static string FournisseurAdded = "AddFournisseur";
        public static string FournisseurUpdated = "UpdateFournisseur";
        // Facteur event
        public static string FactureAdded = "AddFacture";
        public static string FactureUpdated = "UpdateFacture";
        // ChaqueBan event
        public static string ChaqueBanAdded = "AddChaqueBan";
        public static string ChaqueBanUpdated = "UpdateChaqueBan";
    }
}
