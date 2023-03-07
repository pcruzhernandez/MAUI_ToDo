using TodoREST.Models;
using TodoREST.Services;

namespace TodoREST.Views
{
    [QueryProperty(nameof(TodoItem), "TodoItem")]
    public partial class TodoItemPage : ContentPage
    {
        ITodoService _todoService;
        TodoItem _todoItem;
        bool _isNewItem;

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _todoService.GetTasksTicketsAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(TodoItem), e.CurrentSelection.FirstOrDefault() as TodoItem }
            };
            await Shell.Current.GoToAsync(nameof(TodoItemPage), navigationParameter);
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
