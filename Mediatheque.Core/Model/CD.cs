// Fichier: CD.cs
namespace Mediatheque.Core.Model
{
    public class CD : ObjetDePret
    {
        public string Groupe { get; set; }

        public CD(string titreDeLObjet, string groupe) : base(titreDeLObjet)
        {
            Groupe = groupe; // Ajout de l'initialisation de la propriété Groupe
        }
    }
}
