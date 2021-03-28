using System;
using System.Timers;


namespace gestionClotureFicheDeFrais
{
    /// <summary>
    /// classe qui met à jour la base de donnée table fichefrais en fonction du jour
    /// </summary>
    public abstract class MiseAJour
    {
        private static System.Timers.Timer aTimer;
        /// <summary>
        /// Quand j'appelle setTimer que se passe-t-il? Une instance de Timer est instanciée et on décide du laps de temps en millisecondes
        /// </summary>
        public static void SetTimer()
        {
            // Créée un timer à trente secondes d'intervalle
            aTimer = new System.Timers.Timer(30000);

            aTimer.Elapsed += OnTimedEvent; // on appelle OnTimedEvent à chaque fois que Elasped est déclanché
            aTimer.AutoReset = true; // on réinitialise le timer le suivant va automatiquement être executé
            aTimer.Enabled = true; // il commence
        }
        /// <summary>
        /// permet de faire la mise à jour en fonction de la date du jour
        /// </summary>
        public static void faireLaMiseAJour()
        {

            // on ouvre la connexion
            var maConnexion = new ConnexionSql();
            // on vérifie la date pour s'assurer que la date d'aujourd'hui est bien entre le 1 et le 10 du mois
            if (GestionDates.entre(1, 10))
            {

                maConnexion.reqModifie("UPDATE fichefrais SET idetat = 'CL' WHERE fichefrais.mois = '" + GestionDates.getMoisPrecedent(DateTime.Today) + "';");

                maConnexion.close();

            }
            else if (DateTime.Today.Day >= 20)
            {
                Console.WriteLine("UPDATE fichefrais SET idetat = 'RB' WHERE fichefrais.mois = '" + GestionDates.getMoisPrecedent(DateTime.Today) + "';");
                maConnexion.reqModifie("UPDATE fichefrais SET idetat = 'RB' WHERE fichefrais.mois = '" + GestionDates.getMoisPrecedent(DateTime.Today) + "';");

                maConnexion.close();

            }
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            faireLaMiseAJour();
        }

        /// <summary>
        /// Permet de clore le timer et de libérer la mémoire
        /// </summary>
        public static void End()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }
    }
}
