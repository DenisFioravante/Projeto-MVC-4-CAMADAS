using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidades;

namespace Sistema.View
{

    public partial class FrmCadUsuario : Form
    {
        private string opc = "";
        UsuarioEnt objTabela = new UsuarioEnt();


        public FrmCadUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        
        private void HabilitarCampos()
        {
            textNome.Enabled = true;
            textUsuario.Enabled = true;
            textSenha.Enabled = true;
            textCPF.Enabled = true;

        }

        private void DesabilitarCampos()
        {
            textNome.Enabled = false;
            textUsuario.Enabled = false;
            textSenha.Enabled = false;
            textCPF.Enabled = false;

        }

        private void LimparCampo()
        {
            textNome.Text = "";
            textUsuario.Text = "";
            textSenha.Text = "";
            textCPF.Text = "";
            textCodigo.Text = "";
        }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            InciarOpc();
            ListarGrid();
            DesabilitarCampos();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if(textCodigo.Text == "")
            {
                MessageBox.Show("Selecione um Registro na Tabela para Excluir!!!");
                return;
            }
            
            
                opc = "Excluir";
                InciarOpc();
                ListarGrid();
                DesabilitarCampos();
                LimparCampo();
            
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text == "")
            {
                MessageBox.Show("Selecione um Registro na Tabela para Excluir!!!");
                return;
            }

            opc = "Editar";
            InciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampo();
        }

        private void bnt_Novo_Click(object sender, EventArgs e)
        {
            
            opc = "Novo";
            InciarOpc();

            
        }

        private void InciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampo();
                    break;

                case "Salvar":
                    try
                    {
                        objTabela.Nome = textNome.Text;
                        objTabela.Usuario = textUsuario.Text;
                        objTabela.CPF = textCPF.Text;
                        objTabela.Senha = textSenha.Text;

                        int x = UsuarioModel.Inserir(objTabela);

                        if (x > 0)
                            MessageBox.Show(string.Format("Usuário {0} foi inserido ", textNome.Text));
                        else
                            MessageBox.Show("Não Inserido!!");

                        ListarGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mensagem: " + ex);
                        
                    }

                    break;

                case "Excluir":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(textCodigo.Text);
                       

                        int x = UsuarioModel.Excluir(objTabela);

                        if (x > 0)
                            MessageBox.Show(string.Format("Usuário {0} foi excluído ", textNome.Text));
                        else
                            MessageBox.Show("Não Excluído!!");

                        ListarGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mensagem: " + ex);

                    }

                    break;

                case "Editar":

                    try
                    {
                        objTabela.Id = Convert.ToInt32(textCodigo.Text);
                        objTabela.Nome = textNome.Text;
                        objTabela.Usuario = textUsuario.Text;
                        objTabela.CPF = textCPF.Text;
                        objTabela.Senha = textSenha.Text;

                        int x = UsuarioModel.Editar(objTabela);

                        if (x > 0)
                            MessageBox.Show(string.Format("Usuário {0} foi editado ", textNome.Text));
                        else
                            MessageBox.Show("Não Editado!!");

                        ListarGrid();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Mensagem: " + ex);

                    }


                    break;

                case "Buscar":

                    try
                    {
                        objTabela.Nome = textBuscar.Text;
                        List<UsuarioEnt> lista = new List<UsuarioEnt>();
                        lista = new UsuarioModel().Buscar(objTabela);
                        Grid.AutoGenerateColumns = false;//NÃO GERA COLUNAS DE FORMA AUTOMÁTICA, APENAS QUANDO TEM DADOS
                        Grid.DataSource = lista;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Erro ao Listar Dados: " + ex);
                    }

                    break;

                default: break;
            }
        }

   

        private void textSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCPF_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListarGrid()
        {

            try
            {
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModel().Lista();
                Grid.AutoGenerateColumns = false;//NÃO GERA COLUNAS DE FORMA AUTOMÁTICA, APENAS QUANDO TEM DADOS
                Grid.DataSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Listar Dados: " + ex);
            }         

        }
        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmCadUsuario_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //AO SELECIONAR OS ELEMENTOS DA GRID, ELE IRÁ APARECER NA CAIXA DE TEXTO
            textCodigo.Text = Grid.CurrentRow.Cells[0].Value.ToString();
            textNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            textUsuario.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            textCPF.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            textSenha.Text = Grid.CurrentRow.Cells[4].Value.ToString();
            HabilitarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmCadProdutos form = new frmCadProdutos();
            this.Hide();
            form.Show();

            

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBuscar.Text == "")
            {
                ListarGrid();
                return;

            }

            opc = "Buscar";
            InciarOpc();


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
