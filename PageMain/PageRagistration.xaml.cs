using iTeach.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace iTeach.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageRagistration.xaml
    /// </summary>
    public partial class PageRagistration : Page
    {
        public PageRagistration()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (OdbConnectHelper.entObj.User.Count(x => x.Login == TxbLogin.Text) > 0)
            {
                MessageBox.Show("Такой пользователь уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    User userObj = new User()
                    {
                        Login = TxbLogin.Text,
                        Password = PsbPassword.Password,
                    };

                    OdbConnectHelper.entObj.User.Add(userObj);
                    OdbConnectHelper.entObj.SaveChanges();

                    MessageBox.Show("Пользователь создан", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK,MessageBoxImage.Warning);
                    
                }
            }
        }

        private void PsbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TxbPassword.Text == PsbPassword.Password)
            {
                BtnCreate.IsEnabled = true;
                PsbPassword.Background = Brushes.LightGreen;
                PsbPassword.BorderBrush = Brushes.Green;
            }
            else
            {
                BtnCreate.IsEnabled = false;
                PsbPassword.Background = Brushes.LightCoral;
                PsbPassword.BorderBrush = Brushes.Red;
            }
        }
    }
}
