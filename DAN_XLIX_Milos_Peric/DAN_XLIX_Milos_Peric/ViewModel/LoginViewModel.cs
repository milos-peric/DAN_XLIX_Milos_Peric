using DAN_XLIX_Milos_Peric.Command;
using DAN_XLIX_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIX_Milos_Peric.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView login;
        public LoginViewModel(LoginView viewLogin)
        {
            login = viewLogin;
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute, param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                List<string> strList = Utility.PasswordLoader.LoadPassword();
                string password = (obj as PasswordBox).Password;
                if (UserName.Equals(strList.ElementAt(0)) && password.Equals(strList.ElementAt(1)))
                {
                    OwnerView ownerView = new OwnerView();
                    login.Close();
                    ownerView.Show();
                    return;
                }
                //else if (UserName.Equals("aaa") && password.Equals("aaa"))
                //{
                //    ManagerView managerView = new ManagerView();
                //    login.Close();
                //    managerView.Show();
                //    return;
                //}
                else
                {
                    MessageBox.Show("Wrong usename or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
