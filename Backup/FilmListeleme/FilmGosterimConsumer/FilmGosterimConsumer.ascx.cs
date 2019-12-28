using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace FilmListeleme.FilmGosterimConsumer
{
    [ToolboxItemAttribute(false)]
    public partial class FilmGosterimConsumer : WebPart
    {
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
                        SPList liste = web.Lists["Film"];
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
                        query.ViewFieldsOnly = true;
                        System.Data.DataTable table = liste.GetItems(query).GetDataTable();
                        gridFilm.DataSource = table;
                        gridFilm.DataBind();
                    }
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
