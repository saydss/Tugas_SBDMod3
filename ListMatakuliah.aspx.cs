using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace mod3_kel16_sbd_
{
    public partial class ListMatakuliah : System.Web.UI.Page
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
        public void DataShow()
        {
            ds = new DataSet();
            cmd.CommandText = "Select * From matakuliah Where is_delete = 0";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();
            DataSet ds2 = new DataSet();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "SELECT * FROM view_jadwal_kuliah ";
            cmd2.Connection = con;
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(ds2);
            cmd2.ExecuteNonQuery();
            gvdosen.DataSource = ds2;
            gvdosen.DataBind();
            con.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Insert Into matakuliah(id_matakuliah, nama_matakuliah, id_ruangan)values('" + txtid_matakuliah.Text + "', '" + txtnama_matakuliah.Text.ToString()  + "', '" + txtid_ruangan.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Update matakuliah set nama_matakuliah='" +
            txtnama_matakuliah.Text.ToString() + "', id_ruangan='" + txtid_ruangan.Text + "' WHERE id_matakuliah = '" + txtid_matakuliah.Text + "'";
            cmd.Connection = con; cmd.ExecuteNonQuery(); 
            DataShow();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Delete from matakuliah where id_matakuliah='" + txtid_matakuliah.Text + "'";
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtid_matakuliah.Text = null;
            txtnama_matakuliah.Text = null;
            txtid_ruangan.Text = null;
 
        }
        protected void GridViewJoin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridViewJoin, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void GridViewJoin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_matakuliah = GridViewJoin.SelectedRow.Cells[0].Text;
            string nama_matakuliah = GridViewJoin.SelectedRow.Cells[1].Text;
            string id_ruangan = GridViewJoin.SelectedRow.Cells[2].Text;
            txtid_matakuliah.Text = id_matakuliah;
            txtnama_matakuliah.Text = nama_matakuliah;
            txtid_ruangan.Text = id_ruangan;
        }
    }
}
    