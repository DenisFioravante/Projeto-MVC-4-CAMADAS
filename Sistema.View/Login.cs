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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }


        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {

                if(textUsuario.Text == "")
                {
                    MessageBox.Show(" Preencha o campo usuário! ");
                    textUsuario.Focus();
                    return;
                }
                else if (textSenha.Text == "")
                {
                    MessageBox.Show(" Preencha o campo senha! ");
                    textSenha.Focus();
                    return;
                }

                UsuarioEnt obj = new UsuarioEnt();
                obj.Usuario = textUsuario.Text;
                obj.Senha = textSenha.Text;


                obj = new UsuarioModel().Login(obj);

                if (obj.Usuario == null) {
                    lbl_mensagem.Text = " Usuario ou senha não encontrado ";
                    lbl_mensagem.ForeColor = Color.Red;
                    return;
                }

                FrmCadUsuario form = new FrmCadUsuario();
                this.Hide();
                form.Show();//MOSTRA O FORMULARIO DE CADASTRO DE USUÁRIO
                //this.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Logar "+ ex);
            }

            FrmCadUsuario frmCadUsuario = new FrmCadUsuario();
            frmCadUsuario.Show();
        }
    }
}
