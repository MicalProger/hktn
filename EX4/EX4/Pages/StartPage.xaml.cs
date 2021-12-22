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
using EX4.Pages;
using System.Windows.Shapes;

namespace EX4.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            Invite i = new Invite() { Name = "Test name", DateTime = DateTime.Now, Location = "Here", Focus="focsuing" };
            InvitesLW.ItemsSource = new List<Invite>() { i };
        }

        private void AddMeeting(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InventViewPage(new Invite(), true));
        }


        private void OnViewInvite(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new InventViewPage((sender as ListView).SelectedItem as Invite, false));
        }
    }
}

