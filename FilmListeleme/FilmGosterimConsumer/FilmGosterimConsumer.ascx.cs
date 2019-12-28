using Microsoft.SharePoint;
using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft;
namespace FilmListeleme.FilmGosterimConsumer
{
    [ToolboxItemAttribute(false)]
    public partial class FilmGosterimConsumer : WebPart
    {
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=SP2; Initial Catalog=ProjeDB; Integrated Security=true;");

        protected void Page_Load(object sender, EventArgs e)
        {
            //  FillGridView();
        }

        public FilmGosterimConsumer()
        {
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        private IFilmProvider _provider;
        [ConnectionConsumer("User Input Consumer", "FilmAdiConsumer")]
        public void UserInputConsumer(IFilmProvider provider)
        {
            _provider = provider;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (_provider != null)
            {

                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {


                    using (SPWeb web = site.OpenWeb(site.RootWeb.ID))
                    {

                        /*     DataSet dataSet = null;

                             String connectionString = "server=;SP2 User ID=SP2/Administrator;Password=;database=db;Connection Timeout=60";
                             SqlConnection conn = new SqlConnection(connectionString);

                             String query = "SELECT * FROM dbo.films;";

                             conn.Open();
                             */


                        SPList liste = web.Lists["TEST"];
                        SPQuery query = new SPQuery();
                        query.Query = string.Format(@"
                     <Where>
                     <Contains>
                     <FieldRef Name='Title'/>
                     <Value Type='Text'>{0}</Value>
                     </Contains>
                     </Where>
                     <OrderBy>
                         <FieldRef Name='Title'/>
                         </OrderBy>", _provider.UserInput);


             
                        query.ViewFields = @"<FieldRef Name='ID'/>
                                                                          <FieldRef Name='Title'/>
                                                                          <FieldRef Name='Director'/>
                                                                          <FieldRef Name='Release'/>";
                        query.ViewFields = @"<FieldRef Name='IDBOOK'/>
                                                                          <FieldRef Name='Title'/>
                                                                          <FieldRef Name='Director'/>
                                                                          <FieldRef Name='Release'/>";

                        query.ViewFieldsOnly = true;
                        DataTable table = liste.GetItems(query).GetDataTable();
                        gridFilm.DataSource = table;
                        gridFilm.DataBind();



/*
            < Where >
                     < Contains >
                     < FieldRef Name = 'Title' />
 
                      < Value Type = 'Text' >{ 0}</ Value >
      
                           </ Contains >
      
                           </ Where >
      
                           < OrderBy >
      
                               < FieldRef Name = 'Title' />
       
                                </ OrderBy > "             

                    */

                        //labelSonuc.Text = _provider.UserInput;





                        /*void FillGridView()
                        {
                            if (sqlCon.State == ConnectionState.Closed)
                                sqlCon.Open();

                            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TestList.ID,TestList.title FROM TestList ORDER BY TestList.title", sqlCon);
                            sqlDa.SelectCommand.CommandType = CommandType.Text;
                            DataTable dtbl = new DataTable();
                            sqlDa.Fill(dtbl);
                            sqlCon.Close();
                            gridFilm.DataSource = dtbl;
                            gridFilm.DataBind();

                        }*/

                    }
                }
            }
        }

      /*  void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TestList.ID,TestList.title FROM TestList ORDER BY TestList.title", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.Text;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gridFilm.DataSource = dtbl;
            gridFilm.DataBind();


        }

        btn
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO film ([title],[release]) VALUES (@title,@release)", sqlCon);
            sqlCmd.CommanType = CommandType.Text;
            sqlCmd.Parametres.AddWithValue("@title", lis)

        }*/
        

            




} }


                
                    
    

    
          
       