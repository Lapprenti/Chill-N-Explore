using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.ChillNExplore.Models
{
    public class Musee
    {
        private string Nom;
        private string LatLng;
        public Musee(string leNom, string position)
        {
            Nom = leNom;
            LatLng = position;
        }

        List<Musee> musees = new List<Musee>();

        public bool AjouterMusee(string nom, string pos)
        {
            bool result = false;
            try
            {
                musees.Add(new Musee(nom, pos));
                result = true;
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;

        }
        /// <summary>
        /// Retourne la liste des musées associée avec leur position respective
        /// </summary>
        /// <returns>List<Musee></returns>
        public List<Musee> LaListeDesMusees()
        {
            
            return musees.ToList();

        }
    }
}