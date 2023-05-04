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

namespace WpfAppAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<User> list = new List<User>();
        User user = new User();

        public MainWindow()
        {
            InitializeComponent();

           
        }

        private void cmbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

      public class User
      {
            public int Id { get; set; }
            public string Name { get; set; }
            public Nullable<int> Age { get; set; }
            public Nullable<int> RoleId { get; set; }

            public string RoleName { get; set; }
        }

        public class Role
        {
            public int RoleId { get; set; }
            public string Name { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
            GetRoles();
        }

        private async Task GetRoles()
        {
            var rolesList = (await NetManager.Get<List<Role>>("api/roles/get")).Select(x => x.Name);
            cmbRole.ItemsSource = rolesList;
        }
        
        private async Task Refresh ()
        {
            var users = await NetManager.Get<List<User>>("api/users/get");
            listTemplate.ItemsSource = users;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(edName.Text == "" || edAge.Text == "" || cmbRole.SelectedItem== null)
            {
                MessageBox.Show("fill all fields!");
                return;
            }
            
            var role = (await NetManager.Get<Role>($"api/roles/{cmbRole.SelectedItem.ToString()}"));

            var user = new User()
            {
                Name = edName.Text,
                Age = int.Parse(edAge.Text),
                RoleId = role.RoleId
            };

            await NetManager.Post("api/user/post", user);

            await Refresh();
        }
    }
}
