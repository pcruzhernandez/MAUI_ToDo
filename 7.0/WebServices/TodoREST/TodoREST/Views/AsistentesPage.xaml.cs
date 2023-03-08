using System.Collections.ObjectModel;
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

        public class Fruit
        {
            public string FruitName { get; set; }
        }


        //ObservableCollection fruits = new ObservableCollection();
        //public ObservableCollection Fruits { get { return fruits; } }
        public AsistentesPage()
	    {
		    InitializeComponent();
            count = 1;
            
            BindingContext = TodoTickets;
            //fruits.Add(new Fruit() { FruitName = "Apple" });
            //fruits.Add(new Fruit() { FruitName = "Orange" });
            //fruits.Add(new Fruit() { FruitName = "Banana" });
            //fruits.Add(new Fruit() { FruitName = "Grape" });
            //fruits.Add(new Fruit() { FruitName = "Mango" });
            //FruitListView.ItemsSource = fruits;
            //collectionView.ItemsSource = TodoTickets;

        }

        

    }
}