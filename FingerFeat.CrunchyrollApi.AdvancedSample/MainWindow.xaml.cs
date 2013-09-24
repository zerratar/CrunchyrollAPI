using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FingerFeat.CrunchyrollApi.AdvancedSample
{
	using FingerFeat.CrunchyrollApi.Classes;
	using FingerFeat.CrunchyrollApi.Classes.Models;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ClientInformation m_clientInformation;

		private ApplicationState m_appState;

		private CrunchyrollClient m_client;

		private bool m_isLoggedIn;

		private List<Series> m_series;

		public MainWindow()
		{
			InitializeComponent();
			m_clientInformation = new ClientInformation();
			m_appState = new ApplicationState();
			m_client = new CrunchyrollClient(m_appState, m_clientInformation);
			m_series = new List<Series>();

			grid_loginPanel.Visibility = Visibility.Visible;
			grid_userPanel.Visibility = Visibility.Collapsed;
		}

		private async void btn_login_Click(object sender, RoutedEventArgs e)
		{
			lbl_loginStatus.Content = "Logging in...";
			grid_loginPanel.IsEnabled = false;
			if (await m_client.Login(input_user.Text, input_pass.Password))
			{
				lbl_loginStatus.Content = "Logged in.";
				// lbl_loginStatus.Content = "You are logged in.";				
				m_client.StartSession();
				m_isLoggedIn = true;
				m_series.Clear();
				
				lbl_loginStatus.Content = "Preparing animelist...";
				m_series = await m_client.GetSeriesList("anime", null, 0, 0);

				grid_loginPanel.Visibility = Visibility.Collapsed;
				grid_userPanel.Visibility = Visibility.Visible;
				lbl_loginStatus.Content = "You are not logged in.";
			}
			else
			{
				lbl_loginStatus.Content = "Unable to login, invalid username or password.";
				m_isLoggedIn = false;
			}
			grid_loginPanel.IsEnabled = true;
		}

		private void btn_logout_Click(object sender, RoutedEventArgs e)
		{
			if (m_isLoggedIn)
			{
				m_client.Logout();

				grid_loginPanel.Visibility = Visibility.Visible;
				grid_userPanel.Visibility = Visibility.Collapsed;
			}
			m_isLoggedIn = false;
		}

		private async void btn_search_Click(object sender, RoutedEventArgs e)
		{
			if (m_isLoggedIn && m_series != null && m_series.Any())
			{
				var searchResult = m_series.Where(n => n.Name.ToLower().Contains(input_search.Text.ToLower()));

				m_searchResult.ItemSource = searchResult.ToArray();

				// MessageBox.Show(searchResult.Count().ToString());
			}
		}
	}
}
