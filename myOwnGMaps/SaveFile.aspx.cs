using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; //pliki
using System.Text; // kodowanie

public partial class doPliku : System.Web.UI.Page
{
    private string PATH = HttpContext.Current.Server.MapPath("pliki/text.txt");
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Access-Control-Allow-Origin", "*");

        string nazwa = Request["nazwa"];
        string kolor = Request["kolor"];
        string punkty = Request["punkty_wycieczki"];
        if (nazwa != null)
        {
            Response.Write("Powodzenie");
            SaveFile(nazwa, kolor, punkty);
        }
        else
        {
            Response.Write("brak danych");
        } 

    }
    private void SaveFile(string nazwa, string kolor, string punkty)
    {
        DateTime time = DateTime.Now;
        string format = "yyyy-MM-dd hh:mm:ss";
        StreamWriter writer = new StreamWriter(PATH, true, Encoding.UTF8);
        writer.WriteLine("[\""+nazwa +"\",\"" + kolor + "\",\"" + time.ToString(format) + "\"," + punkty+"],");
        writer.Close();
    }

}