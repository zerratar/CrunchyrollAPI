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
	/// <summary>
	/// Interaction logic for SearchResult.xaml
	/// </summary>
	public partial class SearchResult : UserControl
	{
		private List<SearchResultItem> m_searchResultItems;

		private Classes.Models.Series[] m_series;

		public Classes.Models.Series[] ItemSource
		{
			get
			{
				return m_series;
			}
			set
			{
				m_series = value;
				UpdateList();
			}
		}

		private void UpdateList()
		{
			m_searchResultItems = new List<SearchResultItem>();
			panel_itemlist.Children.Clear();
			int index = 0;
			foreach (var s in ItemSource)
			{
				var item = new SearchResultItem(s);
				item.Name = "item" + (index++);
				panel_itemlist.Children.Add(item);
				m_searchResultItems.Add(item);
			}
		}

		public SearchResult()
		{
			InitializeComponent();
		}
	}
}
