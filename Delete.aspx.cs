using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace mod3_kel16_sbd_
{
    public partial class Delete : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=DESKTOP-GACF681\\SQLEXPRESS; Initial Catalog = Mod3_KEL16; Integrated Security = True";
            con.Open();
            if (!Page.IsPostBack)
            {
                DataShow();
            }
        }
        private void DataShow()
        {
            ds = new DataSet();
            cmd.CommandText = "SELECT * FROM mahasiswa WHERE is_delete = 1";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            gvmahasiswa.DataSource = ds;
            gvmahasiswa.DataBind();

            DataSet ds2 = new DataSet();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "SELECT * FROM dosen WHERE is_delete = 1";
            cmd2.Connection = con;
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(ds2);
            cmd2.ExecuteNonQuery();
            gvdosen.DataSource = ds2;
            gvdosen.DataBind();

            DataSet ds3 = new DataSet();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SELECT * FROM matakuliah WHERE is_delete = 1";
            cmd3.Connection = con;
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            sda3.Fill(ds3);
            cmd3.ExecuteNonQuery();
            gvmatakuliah.DataSource = ds3;
            gvmatakuliah.DataBind();

            con.Close();
        }
        protected void gvdosen_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvdosen, "Select$" + e.Row.RowIndex);
                e.Row.Cells[4].Attributes["style"] = "cursor:pointer";
            }
        }
        protected void gvdosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = gvdosen.SelectedRow.Cells[0].Text;
            cmd.CommandText = "UPDATE dosen SET is_delete = 0 WHERE nip = '" + idd + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }
        protected void gvmatakuliah_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvmatakuliah, "Select$" + e.Row.RowIndex);
                e.Row.Cells[3].Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvmatakuliah_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = gvmatakuliah.SelectedRow.Cells[0].Text;
            cmd.CommandText = "UPDATE matakuliah SET is_delete = 0 WHERE id_matakuliah = '" + idd + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }
        protected void gvmahasiswa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvmahasiswa, "Select$" + e.Row.RowIndex);
                e.Row.Cells[4].Attributes["style"] = "cursor:pointer";
            }
        }

        protected void gvmahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idd = gvmahasiswa.SelectedRow.Cells[0].Text;
            cmd.CommandText = "UPDATE mahasiswa SET is_delete = 0 WHERE nim = '" + idd + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }
    }
}