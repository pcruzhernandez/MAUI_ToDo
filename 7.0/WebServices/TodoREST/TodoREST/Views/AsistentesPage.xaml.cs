using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Globalization;
using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{ 
    [QueryProperty(nameof(Qty), "Qty")]
    [QueryProperty(nameof(Ticket), "Ticket")]

    
    public partial class AsistentesPage : ContentPage
    {
        public class Fruit
        {
            public string Asistente { get; set; }
            public string Nombre { get; set; }

            public string Email { get; set; }
            public string Email2 { get; set; }
            public string Movil { get; set; }

        }

        ObservableCollection<Fruit> fruits = new ObservableCollection<Fruit>();
        public ObservableCollection<Fruit> Fruits { get { return fruits; } }


        public string Qty
        {
            get => _qty;
            set
            {

                _qty = value;
                OnPropertyChanged();

            }
        }

        
        int count;
        string _ticket;
        string _qty;
        
        public string Ticket
        {
            get => _ticket;
            set
            {

                _ticket = value;
                OnPropertyChanged();

            }
        }


        //ObservableCollection fruits = new ObservableCollection();
        //public ObservableCollection Fruits { get { return fruits; } }
        public AsistentesPage()
	    {
		    InitializeComponent();
            count = 1;

            //Pid.Text = _ticket;
                   
           

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //Pid.Text = _ticket;
            //collectionView.ItemsSource = _TodoTickets;
            for (int i = 0; i <  Convert.ToInt32(_qty); i++)
            {
                int asistente = i + 1;
                fruits.Add(new Fruit() { Asistente = "DATOS ASISTENTE " + asistente.ToString(),Nombre="",Email="",Email2="",Movil=""});
            }
            collectionView.ItemsSource = fruits;

            //collectionView.ItemsSource = TodoTickets;
        }



    }
}