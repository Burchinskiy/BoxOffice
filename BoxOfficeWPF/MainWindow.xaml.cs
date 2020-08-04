using BoxOfficeASP.Models;
using Newtonsoft.Json;
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

namespace BoxOfficeWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnRegistrationOfPurchaseButtonClicked(object sender, RoutedEventArgs e)
        {
            var seance = (Seance)SeanceComboBox.SelectedItem;

            var purchase = new Purchase()
            {
                Seance = seance,
                SeanceId = seance.SeanceId,
                TicketQuantities = Convert.ToInt32(NumberOfTicketsTextBox.Text)
            };

            var json = JsonConvert.SerializeObject(purchase);

            MessageBox.Show(await RestClient.PostRequest(urlRequest, json));

            SeanceComboBox.Items.Clear();
            NumberOfTicketsTextBox.Clear();
        }

        private async void OnSeanceComboBoxDropDownOpened(object sender, EventArgs e)
        {
            SeanceComboBox.Items.Clear();

            var json = await RestClient.GetRequest(urlRequest);

            var seances = JsonConvert.DeserializeObject<List<Seance>>(json);

            foreach (Seance s in seances)
            {
                SeanceComboBox.Items.Add(s);
            }
        }

        private const string urlRequest = "https://localhost:44339/api/purchase";
    }
}