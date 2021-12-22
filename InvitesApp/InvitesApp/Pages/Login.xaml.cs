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

namespace InvitesApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            if(Utils.DB.User.Any(i => i.Name == NameTB.Text))
            {
                Utils.Current = Utils.DB.User.FirstOrDefault(i => i.Name == NameTB.Text);
                NavigationService.Navigate(new StartPage());
            }
        }
    }
}
