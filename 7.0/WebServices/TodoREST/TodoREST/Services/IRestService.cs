using TodoREST.Models;

namespace TodoREST.Services
{
    public interface IRestService
    {
        Task<List<TodoItem>> RefreshDataAsync();

        Task<List<TodoTickets>> RefreshDataTicketsAsync(string PID);
        Task SaveTodoItemAsync(TodoItem item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);
    }
}
