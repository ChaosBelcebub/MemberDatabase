﻿// <copyright file="AddMemberViewModel.cs" company="ChaosBelcebub">
//     Copyright (c) ChaosBelcebub. All rights reserved.
// </copyright>

namespace MemberDatabase.ViewModel
{
    using MemberDatabase.Model;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Class AddMemberViewModel.
    /// Used for AddMemberView.
    /// </summary>
    class AddMemberViewModel : BaseViewModel
    {
        // Private variables for displayed fields
        private string firstNameP;
        private string lastNameP;
        private DateTime? birthdayP;
        private DateTime? accessionP;
        private bool activeP = true;
        private string emailP;
        private ObservableCollection<DateItem> examList;

        private ICommand saveCommandP;
        private ICommand addExamDateP;
        private Database db;

        /// <summary>
        /// String firstName. Contains the first name of the new member.
        /// </summary>
        public string firstName
        {
            get
            {
                return firstNameP;
            }

            set
            {
                if (firstNameP != value)
                {
                   firstNameP = value;
                    RaisePropertyChanged("firstName");
                }
            }
        }

        /// <summary>
        /// String lastName. Contains the last name of the new member.
        /// </summary>
        public string lastName
        {
            get
            {
                return lastNameP;
            }

            set
            {
                if (lastNameP != value)
                {
                    lastNameP = value;
                    RaisePropertyChanged("lastName");
                }
            }
        }

        public DateTime? birthday
        {
            get
            {
                return birthdayP;
            }

            set
            {
                if (birthdayP != value)
                {
                    birthdayP = value;
                    RaisePropertyChanged("birthday");
                }
            }
        }

        public DateTime? accession
        {
            get
            {
                return accessionP;
            }

            set
            {
                if (accessionP != value)
                {
                    accessionP = value;
                    RaisePropertyChanged("accession");
                }
            }
        }

        public bool active
        {
            get
            {
                return activeP;
            }

            set
            {
                if (activeP != value)
                {
                    activeP = value;
                    RaisePropertyChanged("active");
                }
            }
        }

        public string email
        {
            get
            {
                return emailP;
            }

            set
            {
                if (emailP != value)
                {
                    emailP = value;
                    RaisePropertyChanged("email");
                }
            }
        }

        public ICommand saveCommand
        {
            get
            {
                if (this.saveCommandP == null)
                {
                    this.saveCommandP = new RelayCommand(param => this.saveMember());
                }
                return this.saveCommandP;
            }
        }

        public ICommand addExamDate
        {
            get
            {
                if (this.addExamDateP == null)
                {
                    this.addExamDateP = new RelayCommand(param => this.addExam());
                }
                return this.addExamDateP;
            }
        }

        public ObservableCollection<DateItem> exam
        {
            get
            {
                return examList;
            }

            set
            {
                if (value != examList)
                {
                    examList = value;
                    RaisePropertyChanged("exam");
                }
            }
        }

        private void saveMember()
        {
            Member member = new Member { firstName = firstNameP, lastName = lastNameP, birthday = birthdayP, accession = accessionP, active = activeP };
            db.add(member);
        }

        private void addExam()
        {
            if (examList[examList.Count - 1].date != null)
            {
                examList.Add(new DateItem());
                RaisePropertyChanged("exam");
            }
        }

        /// <summary>
        /// Initializes a new instance of the AddMemberViewModel class
        /// </summary>
        public AddMemberViewModel()
        {
            firstName = string.Empty;
            lastName = string.Empty;
            active = true;
            email = string.Empty;
            db = new Database();
            exam = new ObservableCollection<DateItem>();
            exam.Add(new DateItem());
        }
    }
}
