using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace FilmListeleme.FilmSecimiProvider
{
    [ToolboxItemAttribute(false)]
    public partial class FilmSecimiProvider : WebPart, IFilmProvider
    {
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
            get
            {
                return _userInput;
            }
            set
            {
                _userInput = value;
            }
        }

        protected void btnTamamla_Click(object sender, EventArgs e)
        {
            UserInput = tBoxInput.Text;
            tBoxInput.Text = "";
        }
    }
}
