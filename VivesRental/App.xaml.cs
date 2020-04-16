using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using VivesRental.Navigation;
using VivesRental.Repository.Core;
using VivesRental.Services;
using VivesRental.Settings;
using VivesRental.ViewModels;
using VivesRental.Views;
using Microsoft.EntityFrameworkCore;
using VivesRental.Services.Contracts;

namespace VivesRental
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private IServiceProvider ServiceProvider { get; set; }

		private IConfiguration Configuration;
		protected override void OnStartup(StartupEventArgs e)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json",optional:false,reloadOnChange:true);

			Configuration = builder.Build();

			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			ServiceProvider = serviceCollection.BuildServiceProvider();

			var shell = ServiceProvider.GetRequiredService<Shell>();
			shell.Show();

			base.OnStartup(e);
		}

		private void ConfigureServices(IServiceCollection services)
		{
			//Register DbContext
			var appSettings = new AppSettings();
			Configuration.Bind(nameof(AppSettings), appSettings);
			
			services.AddDbContext<VivesRentalDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("VivesRentalDbContext")));
			
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
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<IOrderService, OrderService>();
			services.AddTransient<IArticleReservationService, ArticleReservationService>();
			services.AddTransient<IArticleService, ArticleService>();
			services.AddTransient<ICustomerService, CustomerService>();
			services.AddTransient<IOrderLineService, OrderLineService>();

			services.AddTransient<IVivesRentalDbContext, VivesRentalDbContext>();
		}
	}
}
