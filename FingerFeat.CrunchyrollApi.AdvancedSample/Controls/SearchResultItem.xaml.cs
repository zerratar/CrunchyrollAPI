using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FingerFeat.CrunchyrollApi.AdvancedSample.Controls
{
	using FingerFeat.CrunchyrollApi.Classes.Models;

	/// <summary>
	/// Interaction logic for SearchResultItem.xaml
	/// </summary>
	public partial class SearchResultItem : UserControl
	{
		private Series m_serie;		

		public SearchResultItem(Series serie)
		{
			InitializeComponent();

			m_serie = serie;

			SetUpUI();
		}

		private void SetUpUI()
		{
			this._image.Source = new BitmapImage(new Uri(m_serie.PortraitImage.MediumUrl));
			this.lbl_title.Content = m_serie.Name;
			this.lbl_description.Text = m_serie.Description;
		}
	}
}
