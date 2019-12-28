using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Data.SqlClient;

namespace FilmListeleme.FilmSecimiProvider
{
    [ToolboxItemAttribute(false)]
    public partial class FilmSecimiProvider : WebPart, IFilmProvider
    {
      SqlConnection sqlCon = new SqlConnection(@"Data Source=SP2; Initial Catalog=ProjeDB; Integrated Security=true;");

        public FilmSecimiProvider()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        [ConnectionProvider("Girilen Film adını diğer web partlar ile paylaşır", "FilmAdiProvider")]
        public IFilmProvider UserInputProvider()
        {
          return this;
        }

        private string _userInput = string.Empty;
        [Personalizable()]
        public string UserInput
        {
            get {
                return _userInput;
            }
            set {
                _userInput = value;
            }
        }

        protected void btnTamamla_Click(object sender, EventArgs e)
        {
            UserInput = tBoxInput.Text;
            tBoxInput.Text = "";

          /*   UserInput = tBox1.Text;
            tBoxInput.Text = "";

            UserInput = tBox2.Text;
            tBoxInput.Text = ""; */

         /*   if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("INSERT INTO film ([title],[release]) VALUES (@title,@release)", sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@title", lis) */ 
        }

       
    }
}
