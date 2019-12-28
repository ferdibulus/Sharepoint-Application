using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FilmListeleme.Movie
{
    [ToolboxItemAttribute(false)]
    public partial class Movie : WebPart
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=SP2; Initial Catalog=ProjeDB; User Id=sa; Password=123456Aa");

        public Movie()
         {
         }

         protected override void OnInit(EventArgs e)
         {
             base.OnInit(e);
             InitializeControl();
         }

         protected void Page_Load(object sender, EventArgs e)
         {
            FİllGridView();
         }

         protected void btn_save_Click(object sender, EventArgs e)
         {
             if (sqlCon.State == ConnectionState.Closed)
                 sqlCon.Open();

             if (hf_id.Value =="")
             {
                 SqlCommand sqlCmdS = new SqlCommand("INSERT INTO films ([title],[release]) VALUES (@title,@release)", sqlCon);
                 sqlCmdS.CommandType = CommandType.Text;
                 sqlCmdS.Parameters.AddWithValue("@id", (hf_id.Value == "" ? 0 : Convert.ToInt32(hf_id.Value)));
                 sqlCmdS.Parameters.AddWithValue("@title", txt_title.Text.Trim());
                 sqlCmdS.Parameters.AddWithValue("@release", txt_release.Text.Trim());
                 sqlCmdS.ExecuteNonQuery();
                 string id = hf_id.Value;
             }

             else
             {
                 SqlCommand sqlCmdU = new SqlCommand("UPDATE films SET [title]=@title,[release]=@release WHERE id=@id", sqlCon);
                 sqlCmdU.CommandType = CommandType.Text;
                 sqlCmdU.Parameters.AddWithValue("@id", (hf_id.Value == "" ? 0 : Convert.ToInt32(hf_id.Value)));
                 sqlCmdU.Parameters.AddWithValue("@title", txt_title.Text.Trim());
                 sqlCmdU.Parameters.AddWithValue("@release", txt_release.Text.Trim());
                 sqlCmdU.ExecuteNonQuery();
                 string id = hf_id.Value;
             }

            FİllGridView();
         }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

                       SqlCommand sqlCmdD = new SqlCommand("DELETE FROM films WHERE id=@id",sqlCon);
                        sqlCmdD.CommandType = CommandType.Text;
                        sqlCmdD.Parameters.AddWithValue("@id", (hf_id.Value == "" ? 0 : Convert.ToInt32(hf_id.Value)));
                        sqlCmdD.ExecuteNonQuery();
                        sqlCon.Close();
         


        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hf_id.Value = "";
            txt_title.Text = "";
            txt_release.Text = "";

            btn_save.Text = "Save";
            btn_delete.Enabled = false;
        }
       
        protected void lb_View_OnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM films WHERE id=@id", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.Text;
            sqlDa.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            txt_title.Text = dtbl.Rows[0]["title"].ToString();
            txt_release.Text = dtbl.Rows[0]["release"].ToString();

            hf_id.Value = id.ToString();
            sqlCon.Close();

            btn_save.Text = "Update";
            btn_delete.Enabled = true; 
        }

            

        void FİllGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlDataAdapter sqlDaG = new SqlDataAdapter("SELECT films.id,films.title,films.release FROM films ORDER BY films.title", sqlCon);
            sqlDaG.SelectCommand.CommandType = CommandType.Text;            
            DataTable dtbl = new DataTable();
            sqlDaG.Fill(dtbl);
            sqlCon.Close();
            gv_films.DataSource = dtbl;
            gv_films.DataBind();

        }
    }
    }
