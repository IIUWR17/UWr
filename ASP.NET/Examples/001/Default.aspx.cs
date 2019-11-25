using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !this.IsPostBack )
            DropDownList1.DataBind();
    }

    protected override void OnPreInit(EventArgs e)
    {
        // DropDownList1.DataBind();
    }

    /// <summary>
    /// DataBound wywo�uje si� PO zwi�zaniu ca�ego formantu do danych
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataBound( object sender, EventArgs e )
    {
        GridViewHelper.InjectConfirm( GridView1 );
    }

    /// <summary>
    /// RowDatabound wywo�uje si� przy wi�zaniu kolejnych wierszy do �r�d�a danych
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Osoba o = e.Row.DataItem as Osoba;
            if (o.ID_MIEJSCOWOSC > 5)
                e.Row.Cells[2].BackColor = System.Drawing.Color.Red;
        }
    }

    /// <summary>
    /// RowCommand wywo�uje si� wtedy, kiedy formant zagnie�d�ony w wierszu ma zdefiniowan� komend� (CommandName)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "DownloadXml" :

                int osobaId = Convert.ToInt32(e.CommandArgument);
                Osoba o = Model.Instance.Osoby[osobaId];

                Response.Clear();
                Response.AppendHeader("Content-Type", "text/xml");
                Response.AppendHeader("Content-Disposition", "attachment; filename=kartoteka.xml");

                Response.Write(o.Xml);

                Response.Flush();
                Response.End();

                break;

        }
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        // do metody biznesowej trzeba w e przekaza� to, czego spodziewa si� sygnatura metody Update

        // najpierw musz� dosta� ID

        // metoda 1. 
        int ID = (int)e.InputParameters["ID"];

        // metoda 2.
        int ID2 = (int)GridView1.DataKeys[GridView1.EditIndex].Value;

        // czytanie nowych warto�ci 
        string Nazwisko = ( (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl( "NazwiskoEdit" ) ).Text;
        string Imie = ( (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl( "ImieEdit" ) ).Text;
        int ID_MSC_UR = Convert.ToInt32( ( (DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl( "MiejscowoscEdit" ) ).SelectedValue );

        // wpisanie nowych warto�ci do obiektu
        Osoba Osoba = Model.Instance.Osoby[ID];
        Osoba.Imie = Imie;
        Osoba.Nazwisko = Nazwisko;
        Osoba.ID_MIEJSCOWOSC = ID_MSC_UR;

        // wpisanie parametr�w do metody biznesowej
        e.InputParameters.Clear();
        e.InputParameters.Add( "Osoba", Osoba );
    }
    protected void ObjectDataSource1_Deleting( object sender, ObjectDataSourceMethodEventArgs e )
    {
        // do metody biznesowej trzeba w e przekaza� to, czego spodziewa si� sygnatura metody Update
        // jw, do uzupe�nienia
    }
    protected void ObjectDataSource1_Updated( object sender, ObjectDataSourceStatusEventArgs e )
    {
        GridView1.DataBind();
    }
}
