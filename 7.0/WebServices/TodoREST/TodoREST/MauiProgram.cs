using TodoREST.Services;
using TodoREST.ViewModels;
using TodoREST.Views;

namespace TodoREST;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-Regular.ttf", "Montse");
                fonts.AddFont(filename: "materialdesignicons-webfont.ttf", alias: "MaterialDesignIcons");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MontseSemibold");
                fonts.AddFont("Montserrat-Bold.ttf", "Montsebold");
            });

		builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
		builder.Services.AddSingleton<IRestService, RestService>();
		builder.Services.AddSingleton<ITodoService, TodoService>();

		builder.Services.AddSingleton<TodoListPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddTransient<TodoItemPage>();
        builder.Services.AddTransient<SelectQtyPage>();
        builder.Services.AddTransient<AsistentesPage>();

        return builder.Build();
	}
}
