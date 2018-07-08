using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using static ChillNExplore.MainPage;

namespace ChillNExplore
{
    class ProfilsDataAccess
    {
        Profil LeProfilAsk;
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Profil> Profils { get; set; }
        int leId=0;

        public ProfilsDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
          //  database.DeleteAll<Profil>();
            database.CreateTable<Profil>();
            this.Profils =
              new ObservableCollection<Profil>(database.Table<Profil>());
            // If the table is empty, initialize the collection
           if (!database.Table<Profil>().Any())
         {
           //  AddNewProfil("");
          }
        }
        public void AddNewProfil(string LePseudo)
        {
            if (!database.Table<Profil>().Any())
                {
                leId = 1;
                }
            else
            {
                foreach (var profilInstance in this.Profils)
                {
                    leId = leId + 1;
                }
                }

            this.Profils.Add(new Profil
            {
                Id = 1,
                Pseudo = LePseudo,
                Level = 1,
                Exp = 0,
                Lang = "French"
            });
        }

        public Profil GetProfil()
        {
            int NbProfil = 0;
            foreach (var profilInstance in this.Profils)
            {
                NbProfil = NbProfil + 1;
                if (NbProfil == 1) //pour l'instant on va prendre le profil principal
                {
                    LeProfilAsk = profilInstance;
                }
            }
            return LeProfilAsk;
        }
   
        public void UpdateProfil(Profil leProfilaUpdate, int IdDuProfil)
        {
            foreach (var profilInstance in this.Profils)
            {
                if (profilInstance.Id == IdDuProfil)
                {
                    database.Update(leProfilaUpdate);
                }

            }


        }
        public void SaveAllProfils()
        {
            lock (collisionLock)
            {
                foreach (var profilInstance in this.Profils)
                {
                   // if (profilInstance.Id != 0)
                    //{
                      //  database.Update(profilInstance);
                    //}
                    //else
                    //{
                        database.Insert(profilInstance);
                    //}
                }
            }
        }


    }
}
