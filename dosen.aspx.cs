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
    public partial class dosen : System.Web.UI.Page
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
            cmd.CommandText = "Select * from dosen Where is_delete = 0";
            cmd.Connection = con;
            sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            GridViewJoin.DataSource = ds;
            GridViewJoin.DataBind();
            con.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Insert Into dosen(nip, nama_dosen, domisili, id_matakuliah)values('" + txtnip.Text + "', '" + txtnama_dosen.Text.ToString() + "', '" + txtdomisili.Text.ToString() + "', '" + txtid_matakuliah.Text + "')";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Delete from dosen where nip='" + txtnip.Text + "'";
            cmd.Connection = con; cmd.ExecuteNonQuery(); DataShow();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            cmd.CommandText = "Update dosen set nama_dosen='" +
            txtnama_dosen.Text.ToString() + "', domisili='" + txtdomisili.Text.ToString() + "', id_matakuliah='" + txtid_matakuliah.Text + "' WHERE nip = '" + txtnip.Text + "'";
            cmd.Connection = con; cmd.ExecuteNonQuery();
            DataShow();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtnip.Text = null;
            txtnama_dosen.Text = null;
            txtdomisili.Text = null;
            txtid_matakuliah.Text = null;
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
            string nip = GridViewJoin.SelectedRow.Cells[0].Text;
            string nama_dosen = GridViewJoin.SelectedRow.Cells[1].Text;
            string domisili = GridViewJoin.SelectedRow.Cells[2].Text;
            string id_matakuliah = GridViewJoin.SelectedRow.Cells[3].Text;
            txtnip.Text = nip;
            txtnama_dosen.Text = nama_dosen;
            txtdomisili.Text = domisili;
            txtid_matakuliah.Text = id_matakuliah;
        }
    }
}