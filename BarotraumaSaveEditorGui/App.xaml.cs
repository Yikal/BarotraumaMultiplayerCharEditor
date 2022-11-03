using BarotraumaSaveEditorGui;
using BarotraumaSaveEditorGui.Pages.Start;
using BarotraumaSaveEditorGui.Services.BarotraumaContentService;
using BarotraumaSaveEditorGui.Services.PageService;
using BarotraumaSaveEditorGui.Views.Characters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace BarotraumaSaveEditorGui
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public ServiceProvider ServiceProvider { get; }

		public App()
		{
			ServiceCollection services = new ServiceCollection();
			ConfigureServices(services);
			ServiceProvider = services.BuildServiceProvider();
			ServiceProvider.GetService<IPageService>().Show(ServiceProvider.GetService<StartViewModel>());
		}

		private void ConfigureServices(ServiceCollection services)
		{
			services.AddSingleton<MainWindow>();
			services.AddSingleton<IPageService, PageService>();
			services.AddSingleton<StartViewModel>();
			services.AddSingleton<IBarotraumaContentService, BarotraumaContentService>();
		}
    }
}
