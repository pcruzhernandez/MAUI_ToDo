using System.Globalization;
using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{ 
    [QueryProperty(nameof(TodoTickets), "TodoTickets")]
    public partial class SelectQtyPage : ContentPage
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

        

        public SelectQtyPage()
	    {
		    InitializeComponent();
            count = 1;
            
            BindingContext = TodoTickets;
            //collectionView.ItemsSource = TodoTickets;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = TodoTickets;
            this.PriceLabel.Text = Convert.ToString(TodoTickets.PPrice.ToString());
            //collectionView.ItemsSource = _TodoTickets;
        }

        private void Substract_Tapped(object sender, EventArgs e)
        {
            if (count <= 0) return;
            this.CountLabel.Text = Convert.ToString(--count);
            double cantidad = Double.Parse(this.CountLabel.Text) * Double.Parse(TodoTickets.PPrice.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
            this.PriceLabel.Text = Convert.ToString(cantidad);
        }
        private void Add_Tapped(object sender, EventArgs e)
        {
            this.CountLabel.Text = Convert.ToString(++count);
            double cantidad = Double.Parse(this.CountLabel.Text) * Double.Parse(TodoTickets.PPrice.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
            this.PriceLabel.Text = Convert.ToString(cantidad);
        }

        void Asistentes_Taped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"{nameof(AsistentesPage)}?Qty={PriceLabel.Text}");
        }

    }
}