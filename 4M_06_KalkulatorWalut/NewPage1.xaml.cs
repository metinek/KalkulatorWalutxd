using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Text.Json;
namespace _4M_06_KalkulatorWalut;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
	private void pckIndexChanged(object sender, EventArgs e)
	{
		Waluta waluta = new Waluta();
		int indeks = pckWaluta.SelectedIndex;
		lblWybranaWaluta.Text = waluta.kodWalut[indeks];	

	}
}