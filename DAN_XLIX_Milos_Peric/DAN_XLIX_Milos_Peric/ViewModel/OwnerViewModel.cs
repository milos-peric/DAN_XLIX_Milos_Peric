﻿using DAN_XLIX_Milos_Peric.Command;
using DAN_XLIX_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX_Milos_Peric.ViewModel
{
    class OwnerViewModel : ViewModelBase
    {
        OwnerView owner;
        public OwnerViewModel(OwnerView viewOwner)
        {
            owner = viewOwner;
        }

        private ICommand addEmployeeCommand;
        public ICommand AddEmployeeCommand
        {
            get
            {
                if (addEmployeeCommand == null)
                {
                    addEmployeeCommand = new RelayCommand(param => AddNewEmployeeExecute());
                }
                return addEmployeeCommand;
            }
        }

        private void AddNewEmployeeExecute()
        {
            try
            {
                AddEmployeeView addEmployee = new AddEmployeeView();
                addEmployee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand addManagerCommand;
        public ICommand AddManagerCommand
        {
            get
            {
                if (addManagerCommand == null)
                {
                    addManagerCommand = new RelayCommand(param => AddNewManagerExecute());
                }
                return addManagerCommand;
            }
        }

        private void AddNewManagerExecute()
        {
            try
            {
                AddManagerView addManager = new AddManagerView();
                addManager.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutCommand == null)
                {
                    logoutCommand = new RelayCommand(param => Logout());
                    return logoutCommand;
                }
                return logoutCommand;
            }
        }

        public void Logout()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        LoginView loginView = new LoginView();
                        Thread.Sleep(1000);
                        owner.Close();
                        loginView.Show();
                        return;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
