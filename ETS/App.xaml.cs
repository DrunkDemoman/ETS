namespace ETS;

public partial class App : Application
{

	public static CompanyContactRepository CompanyContactRepo { get; private set; }

	public App(CompanyContactRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		CompanyContactRepo = repo;
	}
}
