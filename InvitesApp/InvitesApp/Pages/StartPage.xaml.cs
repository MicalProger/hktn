using InvitesApp.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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
            UpdatePersonalizedInvites();
            Utils.Current.GetStory();
            UpdateBM();
        }

        void UpdatePersonalizedInvites()
        {
            var totalInvs = Utils.DB.Invite.ToList();
            totalInvs = totalInvs.OrderBy(i => (Utils.Current.Tags == null ? " " : Utils.Current.Tags).Split(' ').ToList().Contains(i.Focus)).ToList();
            InvitesLW.ItemsSource = totalInvs;
        }
        private void AddMeeting(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InventViewPage(new Invite() { User = Utils.Current }, true));
        }


        private void OnViewInvite(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new InventViewPage((sender as ListView).SelectedItem as Invite, false));
        }

        private void UpdateTag(object sender, RoutedEventArgs e)
        {
            var cTag = TagTB.Text.ToUpper();
            UpdateLWS();
            Utils.Current.TagsSt.Add(Utils.DB.Invite.Select(i => i.Focus.ToUpper()).ToList().OrderBy(i => i.LevenshteinDistance(cTag)).FirstOrDefault());
            Utils.SaveDB();
            Utils.Current.SaveSt();
            if (Utils.Current.TagsSt.Count(i => i.LevenshteinDistance(cTag) <= 3) == 3)
            {
                Utils.Current.Tags += Utils.DB.Invite.ToList().Select(i => i.Focus.ToUpper()).OrderBy(i => i.LevenshteinDistance(cTag)).FirstOrDefault() + " ";
                Utils.SaveDB();
            }
        }

        private void AddBookMark(object sender, RoutedEventArgs e)
        {
            if (InvitesLW.SelectedItem == null) return;
            var cur = InvitesLW.SelectedItem as Invite;
            Utils.Current.Bookmark.Add(new Bookmark() { Invite = cur });
            Utils.SaveDB();
            UpdateBM();

        }

        void UpdateBM()
        {
            BookmardLW.ItemsSource = null;
            BookmardLW.ItemsSource = Utils.Current.Bookmark.Select(i => i.Invite).ToList();
        }

        private void OnRemoveBM(object sender, RoutedEventArgs e)
        {
            if (BookmardLW.SelectedItem == null) return;

            Utils.Current.Bookmark.Remove(Utils.Current.Bookmark.FirstOrDefault(i => i.Invite == BookmardLW.SelectedItem as Invite));
            Utils.SaveDB();
            UpdateBM();
        }

        void UpdateLWS()
        {
            var currentLW = new ListView();
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    currentLW = InvitesLW;
                    break;
                case 1:
                    currentLW = BookmardLW;
                    break;
            }
            var searchTag = TagTB.Text.ToUpper();
            var date = DateDP.SelectedDate;
            var isTag = !string.IsNullOrWhiteSpace(searchTag);
            var isDate = DateDP.IsEnabled;
            var fullInvs = Utils.DB.Invite.ToList();
            var finalInvs = new List<Invite>();
            if (isTag)
                finalInvs = fullInvs.Where(i => i.Focus.ToUpper().LevenshteinDistance(searchTag) <= 4).ToList();
            else
                finalInvs = fullInvs;

            if (isDate)
                finalInvs = finalInvs.Where(i => i.DateTime == date).ToList();
            currentLW.ItemsSource = null;
            currentLW.ItemsSource = finalInvs;
        }

        private void UpdateDate(object sender, RoutedEventArgs e)
        {
            DateDP.IsEnabled = !DateDP.IsEnabled;
            UpdateLWS();
        }
        void UpdateDateVal(object s, SelectionChangedEventArgs e)
        {
            UpdateLWS();
        }
    }
}