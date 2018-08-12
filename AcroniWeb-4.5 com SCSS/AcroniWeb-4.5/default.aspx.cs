﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace AcroniWeb
{
    public partial class _default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
        SqlCommand comando_SQL;
        SqlDataReader tabela;
        String select;
        bool checku = false;
        bool checks = false;

        protected void btnIrCad_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastro.aspx");
        }


        protected void btnEntra_Click(object sender, EventArgs e)
        {
            
            if (checku == true & checks == true)
            {
                Session["logado"] = "1";
                Response.Redirect("area-restrita.aspx");

            }
            //else if (checku == false)
            //{
                
            //}
            //else if (checks == false)
            //{
                
            //}
            else if (checku == false & checks == false)
            {
                lblMsg.Text = "Usuário e Senha incorretos";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                txtPass.Attributes.Add("style", "border-color:red");
                txtUsu.Attributes.Add("style", "border-color:red");
            }



        }

        protected void txtUsu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                select = "SELECT * FROM tblCliente WHERE usuario='" + txtUsu.Text + "'";
                comando_SQL = new SqlCommand(select, conexao_SQL);
                tabela = comando_SQL.ExecuteReader();
                tabela.Read();
                if (tabela.HasRows)
                    checku = true;
                else
                {
                    checku = false;
                    lblMsg.Text = "Usuário incorreto";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    txtUsu.Attributes.Add("style", "border-color:red");
                }

                tabela.Close();
                select = "";
                conexao_SQL.Close();
            }
            catch
            {
                tabela.Close();
                conexao_SQL.Close();
            }
            SCPanel.Update();
        }

        protected void txtPass_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (conexao_SQL.State == ConnectionState.Closed)
                    conexao_SQL.Open();

                select = "SELECT * FROM tblCliente WHERE senha='" + txtPass.Text + "'";
                comando_SQL = new SqlCommand(select, conexao_SQL);
                tabela = comando_SQL.ExecuteReader();
                tabela.Read();
                if (tabela.HasRows)
                    checks = true;
                else
                {
                    checks = false;
                    lblMsg.Text = "Senha incorreta";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    txtPass.Attributes.Add("style", "border-color:red");
                }

                tabela.Close();
                select = "";
                conexao_SQL.Close();
            }
            catch
            {
                tabela.Close();
                conexao_SQL.Close();
            }
            SCPanel.Update();
        }
    }
}
     