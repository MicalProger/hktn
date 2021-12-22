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
using InvitesApp.Pages;
using System.Windows.Shapes;
using InvitesApp.IO;

namespace InvitesApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            DataContext = Utils.Current;
            InvitesLW.ItemsSource = Utils.DB.Invite.ToList();
        }

        private void AddMeeting(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InventViewPage(new Invite(), true));
        }


        private void OnViewInvite(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new InventViewPage((sender as ListView).SelectedItem as Invite, false));
        }

        private void UpdateTag(object sender, RoutedEventArgs e)
        {
            var cTag = TagTB.Text.ToUpper();
            InvitesLW.ItemsSource = Utils.DB.Invite.Where(i => i.Focus.ToUpper().Contains(cTag));
            Utils.Current.TagsSt.Add(cTag);
            //if(Utils.Current.TagsSt.Count(i => i == cTag) == 5 ) 
        }
    }
}

