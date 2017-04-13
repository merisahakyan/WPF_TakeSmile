using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPFSimpleRegistrationForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> buttonslist = new List<Button>();
        List<User> users = new List<User>();
        string name;
        NameWindow namew;
        Members members;


        public MainWindow()
        {
            InitializeComponent();
            buttonslist.Add(button1);
            buttonslist.Add(button2);
            buttonslist.Add(button3);
            buttonslist.Add(button4);
            buttonslist.Add(button5);
            buttonslist.Add(button6);
            buttonslist.Add(button7);
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            namew = new NameWindow();
            namew.Show();
            namew.okbutton.Click += new RoutedEventHandler(OkButton_click);

           
            (sender as Button).IsEnabled = false;


        }
        private void OkButton_click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Firstname = namew.firstname.Text;
            user.Lastname = namew.lastname.Text;
            users.Add(user);

            name = namew.firstname.Text;
            MessageBox.Show("Have a nice day " + name);

        }

        private void ResetIButtons_Click(object sender, RoutedEventArgs e)
        {
            foreach (var b in buttonslist)
                b.IsEnabled = true;
        }


        private void Members_Click(object sender, RoutedEventArgs e)
        {
            members = new Members();
            ListBox listbox = new ListBox();
            foreach (var m in users)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = $"{m.Firstname}  {m.Lastname}";
                listbox.Items.Add(lbi);
            }
            var grid = members.Content as Grid;
            grid.Children.Add(listbox);
            members.Show();
        }
    }
}
