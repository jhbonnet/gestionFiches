using System;
using System.Collections.Generic;
using System.Text;

namespace gestionClotureFicheDeFrais
{
    /// <summary>
    /// Permet la gestion des dates pour les tests du mois et du jour
    /// </summary>
    public abstract class GestionDates
    {
        /// <summary>
        /// Retourne le mois précédent en fonction de la date passée en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string getMoisPrecedent(DateTime date)
        {

            var moisPrecedent = date.Month - 1;
            var annee = date.Year;
            if (moisPrecedent == 0)
            {
                moisPrecedent = 12;
                annee -= 1;
            }

            return annee.ToString("0000") + moisPrecedent.ToString("00");

        }
        /// <summary>
        /// Retourne le mois précédent en fonction de la date du jour
        /// </summary>
        /// <returns></returns>
        public static string getMoisPrecedent()
        {
            return getMoisPrecedent(DateTime.Today);
        }

        /// <summary>
        ///  Retourne le mois suivant en fonction de la date passée en paramètre
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string getMoisSuivant(DateTime date)
        {

            var moisPrecedent = date.Month + 1;
            var annee = date.Year;
            if (moisPrecedent == 13)
            {
                moisPrecedent = 1;
                annee += 1;
            }

            return annee.ToString("0000") + moisPrecedent.ToString("00");

        }
        /// <summary>
        /// Retourne le mois suivant en fonction de la date du jour
        /// </summary>
        /// <returns></returns>
        public static string getMoisSuivant()
        {
            return getMoisSuivant(DateTime.Today);
        }

        /// <summary>
        /// reçoit en paramètre deux numéros de jours dans le mois, et retourne vrai si la date passée en paramètre se situe entre ces deux jours
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool entre(int jour1, int jour2, DateTime date)
        {
            int jour = date.Day;
            return jour1 <= jour && jour <= jour2;
        }

        /// <summary>
        /// reçoit en paramètre deux numéros de jours dans le mois, et retourne vrai si la date actuelle se situe entre ces deux jours
        /// </summary>
        /// <param name="jour1"></param>
        /// <param name="jour2"></param>
        /// <returns></returns>
        public static bool entre(int jour1, int jour2)
        {
            return entre(jour1, jour2, DateTime.Today);
        }





    }
}
