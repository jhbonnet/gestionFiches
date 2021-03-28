using System;
using MySql.Data.MySqlClient;

namespace gestionClotureFicheDeFrais
{
    /// <summary>
    /// Classe technique de connexion à la base de données MySql
    /// Si on veut changer de SGBDR il suffira de modifier cette classe tout le reste du code restera majoritairement inchangée 
    /// </summary>
    public class ConnexionSql
    {
        // propriétés
        private bool finCurseur = true; // fin du curseur atteinte
        private MySqlConnection connection; // chaine de connexion
        private MySqlCommand command; // envoi de la requête à la base de données
        private MySqlDataReader reader; // gestion du curseur
        private static string stringConnexion = "server=localhost;user id=root;database=gsb_frais"; // la chaine de connexion à la base de données

        /// <summary>
        /// le constructeur permet de créer et ouvre la connexion
        /// </summary>
        /// <param name="chaineConnection"></param>
        public ConnexionSql(string chaineConnection)
        {
            this.connection = new MySqlConnection(chaineConnection);
            this.connection.Open();
        }

        /// <summary>
        /// crée la connexion SQL avec la chaine de connexion de défault
        /// </summary>
        public ConnexionSql() : this(stringConnexion) // appelle le constructeur avec en paramètre la propriété static stringConnexion
        {
        }
        /// <summary>
        /// execution d'une requete select
        /// </summary>
        /// <param name="chaineRequete"></param>
        public void reqSelect(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connection);
            this.reader = this.command.ExecuteReader();
            this.finCurseur = false;
            this.suivant();
        }

        /// <summary>
        /// execution d'une requete update insert ou delete
        /// </summary>
        /// <param name="chaineRequete"></param>
        public void reqModifie(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connection);
            this.command.ExecuteNonQuery();
            this.finCurseur = true;
        }

        /// <summary>
        /// récupération d'un champ
        /// </summary>
        /// <param name="nomChamp"></param>
        /// <returns></returns>
        public Object champ(string nomChamp)
        {
            return this.reader[nomChamp];
        }

        /// <summary>
        /// passage à la ligne suivante du curseur
        /// </summary>
        public void suivant()
        {
            if (!this.finCurseur)
            {
                // si le reader ne renvoie rien alors finCurseur sera basculé à true
                this.finCurseur = !this.reader.Read();
            }
        }

        /// <summary>
        /// test de la fin du curseur
        /// </summary>
        /// <returns></returns>
        public Boolean fin()
        {
            return this.finCurseur;
        }

        /// <summary>
        /// fermeture de la connexion
        /// </summary>
        public void close()
        {
            this.connection.Close();
        }
    }

}
