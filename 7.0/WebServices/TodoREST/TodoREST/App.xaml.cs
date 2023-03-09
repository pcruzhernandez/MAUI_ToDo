using TodoREST.Models;

namespace TodoREST;

public partial class App : Application
{
	public static UserInfo UserInfo;
	public App()
	{
		InitializeComponent();

 		MainPage = new AppShell();
	}
}
