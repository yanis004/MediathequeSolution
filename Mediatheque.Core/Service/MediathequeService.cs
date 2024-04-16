// Fichier: MediathequeService.cs
using System.Collections.Generic;
using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public class MediathequeService
    {
        private readonly List<ObjetDePret> _fondDeCommerce = new List<ObjetDePret>();
        private readonly INotationService _notationService;

        public MediathequeService(INotationService notationService)
        {
            _notationService = notationService;
        }

        public void AddObjet(ObjetDePret objet)
        {
            _fondDeCommerce.Add(objet);
        }

        // Nouvelle fonctionnalité : Présentation des CDs
        public List<string> PresentCDs()
        {
            var descriptions = new List<string>();

            foreach (var objet in _fondDeCommerce)
            {
                if (objet is CD cd)
                {
                    var note = _notationService.GetNoteAlbum(cd.TitreDeLObjet);
                    descriptions.Add($"Groupe: {cd.Groupe} - Album: {cd.TitreDeLObjet} - Note: {note}");
                }
            }

            if (descriptions.Count == 0)
            {
                descriptions.Add("Il n'y a pas de CD à afficher.");
            }

            return descriptions;
        }
    }
}
