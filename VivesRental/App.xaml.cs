using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using VivesRental.Navigation;
using VivesRental.Services;
using VivesRental.ViewModels;
using VivesRental.Views;

namespace VivesRental
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private IServiceProvider ServiceProvider { get; set; }
		protected override void OnStartup(StartupEventArgs e)
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			ServiceProvider = serviceCollection.BuildServiceProvider();

			var shell = ServiceProvider.GetRequiredService<Shell>();
			shell.Show();

			base.OnStartup(e);
		}

		private void ConfigureServices(IServiceCollection services)
		{
			//Register Navigation
			services.AddSingleton<INavigator, Navigator>();

			//Register Views
			services.AddTransient<Shell>();
			services.AddTransient<HomeView>();
			services.AddTransient<VerhuurInformatieView>();
			services.AddTransient<ArtikelbeheerView>(); 

			//Register ViewModels
			services.AddTransient<ShellViewModel>();
			services.AddTransient<HomeViewModel>();
			services.AddTransient<VerhuurInformatieViewModel>();
			services.AddTransient<ArtikelbeheerViewModel>();

			//Services
			services.AddTransient<IDummyService, DummyService>();
		}
	}
}
