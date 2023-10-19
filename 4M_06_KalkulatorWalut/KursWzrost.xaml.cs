using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Text.Json;
namespace _4M_06_KalkulatorWalut;

class Waluta2
{

    public string kodWaluty { get; private set; } = "eur";
    public string nazwaWaluty { get; private set; }
    public string date { get; private set; } = "2023-10-19";
    public double skup { get; private set; }
    public double sprzedaz { get; private set; }



    public Waluta2(string code = "eur", string date = "2023-10-19")
    {
        if (code.Length > 0)
        {
            kodWaluty = code;
        }
        pobierzDane(code, date);
    }





    public void pobierzDane(string waluta = "EUR", string date = "2023-10-19")
    {
        string url = "http://api.nbp.pl/api/exchangerates/rates/c/" + waluta + "/"+ date +"/?format=json";
        string wynik;
        using (var webClient = new WebClient())
        {
            wynik = webClient.DownloadString(url);
        }
        using JsonDocument j1 = JsonDocument.Parse(wynik);
        JsonElement json = j1.RootElement;
        var rates = json.GetProperty("rates");
        var rate = rates[0];
        string bid = rate.GetProperty("bid").ToString();
        bid = bid.Replace('.', ',');
        skup = double.Parse(bid);
        string ask = rate.GetProperty("ask").ToString();
        ask = ask.Replace(".", ",");
        sprzedaz = double.Parse(ask);
    }


}
public partial class KursWzrost : ContentPage
{
    Waluta2 euro;
    Waluta2 usd;
    Waluta2 chf;
    Waluta2 euro2;
    Waluta2 usd2;
    Waluta2 chf2;

    public KursWzrost()
    {
        euro = new Waluta2("EUR", "2023-10-19");
        usd = new Waluta2("USD", "2023-10-19"); 
        chf = new Waluta2("CHF", "2023-10-19"); 

        euro2 = new Waluta2("EUR", "2023-10-18");
        usd2 = new Waluta2("USD", "2023-10-18");
        chf2 = new Waluta2("CHF", "2023-10-18");
        InitializeComponent();

        eurLbl.Text = euro.kodWaluty;
        kupnoEURLbl.Text = Math.Round(euro.skup, 3).ToString();
        sprzedazEURLbl.Text = Math.Round(euro.sprzedaz,3).ToString();

        usdLbl.Text = usd.kodWaluty;
        kupnoUSDLbl.Text = Math.Round(usd.skup,3).ToString();
        sprzedazUSDLbl.Text = Math.Round(usd.sprzedaz,3).ToString();

        chfLbl.Text = chf.kodWaluty;
        kupnoCHFLbl.Text = Math.Round(chf.skup,3).ToString();
        sprzedazCHFLbl.Text = Math.Round(chf.sprzedaz,3).ToString();








        if (euro.sprzedaz - euro2.sprzedaz > 0) wzrostkupnoEURImg.Source = "w2.png";
        else if (euro.sprzedaz - euro2.sprzedaz < 0) wzrostkupnoEURImg.Source = "w0.png";
        else wzrostkupnoEURImg.Source = "w1.png";


        if (euro.skup - euro2.skup > 0) wzrostsprzedazEURImg.Source = "w2.png";
        else if (euro.skup - euro2.skup < 0) wzrostsprzedazEURImg.Source = "w0.png";
        else wzrostsprzedazEURImg.Source = "w1.png";





        if (usd.sprzedaz - usd2.sprzedaz > 0) wzrostkupnoUSDImg.Source = "w2.png";
        else if (usd.sprzedaz - usd2.sprzedaz < 0) wzrostkupnoUSDImg.Source = "w0.png";
        else wzrostkupnoUSDImg.Source = "w1.png";


        if (usd.skup - usd2.skup > 0) wzrostsprzedazUSDImg.Source = "w2.png";
        else if (usd.skup - usd2.skup < 0) wzrostsprzedazUSDImg.Source = "w0.png";
        else wzrostsprzedazUSDImg.Source = "w1.png";





        if (chf.sprzedaz - chf2.sprzedaz > 0) wzrostkupnoCHFImg.Source = "w2.png";
        else if (chf.sprzedaz - chf2.sprzedaz < 0) wzrostkupnoCHFImg.Source = "w0.png";
        else wzrostkupnoCHFImg.Source = "w1.png";


        if (chf.skup - chf2.skup > 0) wzrostsprzedazCHFImg.Source = "w2.png";
        else if (chf.skup - chf2.skup < 0) wzrostsprzedazCHFImg.Source = "w0.png";
        else wzrostsprzedazCHFImg.Source = "w1.png";








    }




}