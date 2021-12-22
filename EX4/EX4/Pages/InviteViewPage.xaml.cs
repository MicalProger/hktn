using System;
using System.Linq;
using System.Collections.Generic;
using EX4;
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

namespace EX4.Pages
{
    /// <summary>
    /// Логика взаимодействия для InventViewPage.xaml
    /// </summary>
    public partial class InventViewPage : Page
    {
        bool state;
        Invite curr;
        public InventViewPage(Invite inv, bool isNew)
        {
            InitializeComponent();
            state = isNew;
            DataContext = inv;
            curr = inv;
            var items = MainSp.Children;
            foreach(var o in items)
            {
                var n = o as TextBox;
                if (n == null) continue;
                n.IsEnabled = isNew;
            }
        }
    }
}
