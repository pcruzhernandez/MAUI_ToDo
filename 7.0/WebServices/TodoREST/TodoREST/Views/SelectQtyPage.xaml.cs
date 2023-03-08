using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{ 
    [QueryProperty(nameof(TodoTickets), "TodoTickets")]
    public partial class SelectQtyPage : ContentPage
    {
        
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

        public SelectQtyPage()
	    {
		    InitializeComponent();
            BindingContext = TodoTickets;
            //collectionView.ItemsSource = TodoTickets;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = TodoTickets;
            //collectionView.ItemsSource = _TodoTickets;
        }



    }
}