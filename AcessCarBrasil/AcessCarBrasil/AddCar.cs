using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AcessCarBrasil
{
    public partial class frmaddcar : Form
    {
        public frmaddcar()
        {
            InitializeComponent();

            txtModelo.Enabled = false;
            txtMarca.Enabled = false;
            txtCodigo.Enabled = false;
            txtCor.Enabled = false;
            txtAno.Enabled = false;
            txtPesquisar.Enabled = false;

        }

        SqlConnection sqlCon = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Carros;Data Source=DESKTOP-GB9PCR9";
        private string strSql = string.Empty;

        private void frmaddcar_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtModelo.Enabled = true;
            txtMarca.Enabled = true;
            txtCodigo.Enabled = true;
            txtCor.Enabled = true;
            txtAno.Enabled = true;
            txtPesquisar.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            strSql = "insert into Carro (Codigo, Marca, Modelo , Ano , Cor) VALUES(@Codigo, @Marca, @Modelo, @Ano, @Cor)";

            sqlCon = new SqlConnection(strCon);

            SqlCommand c = new SqlCommand(strSql, sqlCon);

            c.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = txtCodigo.Text;
            c.Parameters.Add("@Marca", SqlDbType.VarChar).Value = txtMarca.Text;
            c.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = txtModelo.Text;
            c.Parameters.Add("@Ano", SqlDbType.VarChar).Value = txtAno.Text;
            c.Parameters.Add("@Cor", SqlDbType.VarChar).Value = txtCor.Text;

            try
            {
                sqlCon.Open();

                c.ExecuteNonQuery();

                MessageBox.Show("VEICULO EFETUADO COM SUCESSO!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            txtPesquisar.Enabled = true;

            txtCodigo.Clear();

            txtMarca.Clear();

            txtModelo.Clear();

            txtAno.Clear();

            txtCor.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            strSql = "select from Carro where Modelo=@pesquisa";

            sqlCon = new SqlConnection(strCon);

            SqlCommand c = new SqlCommand(strSql, sqlCon);

            c.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = txtPesquisar.Text;

            try
            {
                if (txtPesquisar.Text == string.Empty)
                {
                    MessageBox.Show("VOCÊ NÃO DIGITOU UM MODELO.");
                }
                sqlCon.Open();

                SqlDataReader dr = c.ExecuteReader();
                if (dr.HasRows == false)
                {
                    throw new Exception("ESTE MODELO NÃO ESTÁ CADASTRADO");

                }
                dr.Read();

                txtCodigo.Text = Convert.ToString(dr["Codigo"]);
                txtModelo.Text = Convert.ToString(dr[ "Modelo"]);
                txtMarca.Text = Convert.ToString(dr["Marca"]);
                txtAno.Text = Convert.ToString(dr["Ano"]);
                txtCor.Text = Convert.ToString(dr["Cor"]);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            txtPesquisar.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            strSql = "update Carro set Codigo=@Codigo, Marca=@Marca, Modelo=@Modelo,Ano=@Ano, Cor=@Cor";

            sqlCon = new SqlConnection(strCon);

            SqlCommand c = new SqlCommand(strSql, sqlCon);

            c.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = txtCodigo.Text;
            c.Parameters.Add("@Marca", SqlDbType.VarChar).Value = txtMarca.Text;
            c.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = txtModelo.Text;
            c.Parameters.Add("@Ano", SqlDbType.VarChar).Value = txtAno.Text;
            c.Parameters.Add("@Cor", SqlDbType.VarChar).Value = txtCor.Text;

            try
            {
                sqlCon.Open();
                c.ExecuteNonQuery();

                MessageBox.Show("CADASTRO ALTERADO COM SUCESSO.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                sqlCon.Close();
            }

            txtCodigo.Clear();

            txtMarca.Clear();

            txtModelo.Clear();

            txtAno.Clear();

            txtCor.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            strSql = "delete from Carro where Modelo=@Modelo";

            sqlCon = new SqlConnection(strCon);

            SqlCommand c = new SqlCommand(strSql, sqlCon);

            c.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = txtModelo.Text;

            try
            {
                sqlCon.Open();
                c.ExecuteNonQuery();
                MessageBox.Show("EXCLUSÃO DE VEICULO FEITA COM SUCESSO.");

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            txtCodigo.Clear();

            txtMarca.Clear();

            txtModelo.Clear();

            txtAno.Clear();

            txtCor.Clear();
        }
    }
}
