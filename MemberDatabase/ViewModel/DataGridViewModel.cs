﻿using MemberDatabase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemberDatabase.ViewModel
{
    class DataGridViewModel : BaseViewModel
    {
        public List<Member> members { get; set; }
        public string anniversary { get; set; }
        public string birthday { get; set; }
        
        private Database db;
        private Anniversary an;

        public DataGridViewModel()
        {
            db = new Database();
            loadDataBase();
        }

        public void loadDataBase()
        {
            members = db.content();
            an = new Anniversary(members);
            birthday = an.nextBirthday();
            anniversary = an.nextAnniversary();
        }


        private ICommand _loadCommand;

        public ICommand loadDatabase {
            get
            {
                if (_loadCommand == null)
                {
                    _loadCommand = new RelayCommand(param => this.loadDataBase());
                }
                return _loadCommand;
            }
        }
    }
}
