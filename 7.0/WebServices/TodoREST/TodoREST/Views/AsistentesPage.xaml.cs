using System.Globalization;
using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{ 
    [QueryProperty(nameof(TodoTickets), "TodoTickets")]
    public partial class AsistentesPage : ContentPage
    {
        int count;
        TodoTickets _todoTickets;
        
        public TodoTickets TodoTickets
        {
            get => _todoTickets;
            set
            {

                _todoTickets = value;
                OnPropertyChanged();

            }
        }

        

        public AsistentesPage()
	    {
		    InitializeComponent();
            count = 1;
            
            BindingContext = TodoTickets;
            //collectionView.ItemsSource = TodoTickets;

        }

        

    }
}