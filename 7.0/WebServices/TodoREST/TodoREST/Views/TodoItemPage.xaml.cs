using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{
    [QueryProperty(nameof(TodoItem), "TodoItem")]
    public partial class TodoItemPage : ContentPage
    {
        ITodoService _todoService;
        TodoItem _todoItem;
        TodoTickets _todoTickets;
        bool _isNewItem;
        bool _isNewTicket;

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _todoService.GetTasksTicketsAsync(TodoItem);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(TodoTickets), e.CurrentSelection.FirstOrDefault() as TodoTickets }
            };
            await Shell.Current.GoToAsync(nameof(SelectQtyPage), navigationParameter);
        }

        public TodoItem TodoItem
        {
            get => _todoItem;
            set
            {
                _isNewItem = IsNewItem(value);
                _todoItem = value;
                OnPropertyChanged();
            }
        }

        public TodoTickets TodoTickets
        {
            get => _todoTickets;
            set
            {
                _isNewTicket = IsNewTicket(value);
                _todoTickets = value;
                OnPropertyChanged();
            }
        }

        public TodoItemPage(ITodoService service)
        {
            InitializeComponent();
            _todoService = service;
            BindingContext = this;
        }


        bool IsNewItem(TodoItem todoItem)
        {
            if (string.IsNullOrWhiteSpace(todoItem.PName) && string.IsNullOrWhiteSpace(todoItem.PID))
                return true;
            return false;
        }

        bool IsNewTicket(TodoTickets todoTickets)
        {
            if (string.IsNullOrWhiteSpace(todoTickets.PName) && string.IsNullOrWhiteSpace(todoTickets.PID))
                return true;
            return false;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await _todoService.SaveTaskAsync(TodoItem, _isNewItem);
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await _todoService.DeleteTaskAsync(TodoItem);
            await Shell.Current.GoToAsync("..");
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
