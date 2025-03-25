﻿using System;
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
    public partial class frmCLient : Form
    {
        public frmCLient()
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
            dt = new SqlDataAdapter("select * from tClient", con);
            dt.Fill(table);
            con.Close();

            return table;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNoms.Text = "";
            txtAdresse.Text = "";
            txtContact.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=localhost;database=vente_db;uid=sa;pwd=bbbbbb;");
            //con = new SqlConnection("server=localhost;database=vente_db; Integrated Security=true;");
            con.Open();
            cmd = new SqlCommand("insert into tClient (noms,adresse,contact) values (@noms,@adresse,@contact)", con);
            cmd.Parameters.AddWithValue("@noms", txtNoms.Text);
            cmd.Parameters.AddWithValue("@adresse", txtAdresse.Text);
            cmd.Parameters.AddWithValue("@contact", txtContact.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void txtAdresse_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=localhost;database=vente_db;uid=sa;pwd=bbbbbb;");
            //con = new SqlConnection("server=localhost;database=vente_db; Integrated Security=true;");
            con.Open();
            cmd = new SqlCommand("update tClient set noms=@noms,adresse=@adresse,contact=@contact where id=@id", con);
            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.Parameters.AddWithValue("@noms", txtNoms.Text);
            cmd.Parameters.AddWithValue("@adresse", txtAdresse.Text);
            cmd.Parameters.AddWithValue("@contact", txtContact.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=localhost;database=vente_db;uid=sa;pwd=bbbbbb;");
            //con = new SqlConnection("server=localhost;database=vente_db; Integrated Security=true;");
            con.Open();
            cmd = new SqlCommand("delete from tClient where id=@id", con);
            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void frmCLient_Load(object sender, EventArgs e)
        {
            listeClient.DataSource = loadData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listeClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNoms_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
