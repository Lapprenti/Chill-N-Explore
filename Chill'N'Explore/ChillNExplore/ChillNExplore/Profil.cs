using System.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChillNExplore
{
    [Table("Profils")]
    public class Profil : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _pseudo;
        [NotNull]
        public string Pseudo
        {
            get
            {
                return _pseudo;
            }
            set
            {
                this._pseudo = value;
                OnPropertyChanged(nameof(Pseudo));
            }
        }


        private int _level;
        [NotNull]
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                this._level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        private int _exp;
        [NotNull]
        public int Exp
        {
            get
            {
                return _exp;
            }
            set
            {
                this._exp = value;
                OnPropertyChanged(nameof(Exp));
            }
        }

        private string _lang;
        public string Lang
        {
            get
            {
                return _lang;
            }
            set
            {
                this._lang = value;
                OnPropertyChanged(nameof(Lang));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}