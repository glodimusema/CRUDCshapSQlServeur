using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUDCshapSQlServeur
{
    public partial class frmCategorieProduit : Form
    {
        public frmCategorieProduit()
        {
            InitializeComponent();
        }

        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataAdapter dt = null;
        SqlDataReader dr = null;


        public DataTable loadData()
        {
            con = new SqlConnection("server=localhost;database=vente_db;uid=sa;pwd=bbbbbb;");
            if (!con.State.ToString().ToLower().Equals("open")) con.Open();
            DataTable table = new DataTable();
            dt = new SqlDataAdapter("select * from tCategorieProduit", con);
            dt.Fill(table);
            con.Close();

            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtDesignation.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=localhost;database=vente_db;uid=sa;pwd=bbbbbb");
            con.Open();
            cmd = new SqlCommand("insert into tCategorieProduit (nom_categorie) values (@nom_categorie)", con);
            cmd.Parameters.AddWithValue("@nom_categorie", txtDesignation.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=localhost;database=vente_db;uid=sa;pwd=bbbbbb");
            con.Open();
            cmd = new SqlCommand("update tCategorieProduit set nom_categorie=@nom_categorie where id=@txtId", con);
            cmd.Parameters.AddWithValue("@nom_categorie", txtDesignation.Text);
            cmd.Parameters.AddWithValue("@txtId", txtId.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void listeClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=localhost;database=vente_db;uid=sa;pwd=bbbbbb");
            con.Open();
            cmd = new SqlCommand("delete from tCategorieProduit where id=@id", con);
            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void frmCategorieProduit_Load(object sender, EventArgs e)
        {
            listeCategorie.DataSource = loadData();
        }
    }
}
