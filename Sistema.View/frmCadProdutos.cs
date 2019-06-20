using Sistema.Entidades;
using Sistema.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.View
{
    public partial class frmCadProdutos : Form
    {
        private string opc = "";
        ProdutoEnt objTabela = new ProdutoEnt();



        private void HabilitarCampos()
        {
            textNome.Enabled = true;
            textDescricao.Enabled = true;
            textValor.Enabled = true;
            
        }

        private void DesabilitarCampos()
        {
            textNome.Enabled = false;
            textDescricao.Enabled = false;
            textValor.Enabled = false;
            

        }

        private void LimparCampo()
        {
            textNome.Text = "";
            textDescricao.Text = "";
            textValor.Text = "";
            textCodigo.Text = "";
        }


        public frmCadProdutos()
        {
            InitializeComponent();
        }

        private void frmCadProdutos_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }
        private void ListarGrid()
        {

            try
            {
                List<ProdutoEnt> lista = new List<ProdutoEnt>();
                lista = new ProdutoModel().Lista();
                Grid.AutoGenerateColumns = false;//NÃO GERA COLUNAS DE FORMA AUTOMÁTICA, APENAS QUANDO TEM DADOS
                Grid.DataSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Listar Dados: " + ex);
            }

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
                        objTabela.Descricao = textDescricao.Text;
                        objTabela.Valor = Convert.ToDecimal(textValor.Text);

                        int x = ProdutoModel.Inserir(objTabela);

                        if (x > 0)
                            MessageBox.Show(string.Format("Produto {0} foi inserido ", textNome.Text));
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


                        int x = ProdutoModel.Excluir(objTabela);

                        if (x > 0)
                            MessageBox.Show(string.Format("Produto {0} foi excluído ", textNome.Text));
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
                        objTabela.Descricao = textDescricao.Text;                        
                        objTabela.Valor = Convert.ToDecimal(textValor.Text);

                        int x = ProdutoModel.Editar(objTabela);

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
                        List<ProdutoEnt> lista = new List<ProdutoEnt>();
                        lista = new ProdutoModel().Buscar(objTabela);
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

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bnt_Novo_Click(object sender, EventArgs e)
        {
            opc = "Novo";
            InciarOpc();
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

            if (textCodigo.Text == "")
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

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //AO SELECIONAR OS ELEMENTOS DA GRID, ELE IRÁ APARECER NA CAIXA DE TEXTO
            textCodigo.Text = Grid.CurrentRow.Cells[0].Value.ToString();
            textNome.Text = Grid.CurrentRow.Cells[1].Value.ToString();
            textDescricao.Text = Grid.CurrentRow.Cells[2].Value.ToString();
            textValor.Text = Grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
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
    }
}
