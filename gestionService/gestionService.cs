using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using gestionClotureFicheDeFrais;

namespace gestionService
{
    public partial class gestionService : ServiceBase
    {
        Timer aTimer;
        public gestionService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Créée un timer à trente secondes d'intervalle
            aTimer = new System.Timers.Timer(30000);

            aTimer.Elapsed += OnTimedEvent; // on appelle OnTimedEvent à chaque fois que Elasped est déclanché
            aTimer.AutoReset = true; // on réinitialise le timer le suivant va automatiquement être executé
            aTimer.Enabled = true; // il commence
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            MiseAJour.faireLaMiseAJour();
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }
    }
}
