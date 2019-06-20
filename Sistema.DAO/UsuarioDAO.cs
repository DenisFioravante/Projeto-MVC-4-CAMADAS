using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.DAO;
using Sistema.Entidades;
using MySql.Data.MySqlClient;

namespace Sistema.DAO
{
    public class UsuarioDAO
    {
       
       
       public int Inserir (UsuarioEnt objTabela)
        {
            int qtd = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;
                   
                    

                    con.Open();
                    MySqlCommand cn = new MySqlCommand("INSERT INTO tb_usuario (nome, usuario, cpf, senha) VALUES (?, ?, ?, ?)",con);
                    
                    //cn.CommandType = CommandType.Text;
                    //cn.CommandText = "INSERT INTO tb_usuario (nome, usuario, cpf, senha) VALUES (?, ?, ?, ?)";

                    cn.Parameters.Add("@nome", MySqlDbType.VarChar, 40).Value = objTabela.Nome;
                    cn.Parameters.Add("@usuario", MySqlDbType.VarChar, 40).Value = objTabela.Usuario;
                    cn.Parameters.Add("@cpf", MySqlDbType.VarChar, 15).Value = objTabela.CPF;
                    cn.Parameters.Add("@senha", MySqlDbType.VarChar, 15).Value = objTabela.Senha;

                    //cn.Connection = con;
                    qtd = cn.ExecuteNonQuery();//executar o comando

                    con.Close();

                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex);
            }

            return qtd;
        }

        public List<UsuarioEnt> Buscar(UsuarioEnt objTabela)
        {
            List<UsuarioEnt> lista = new List<UsuarioEnt>();
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("SELECT *FROM tb_usuario WHERE nome LIKE ?  ORDER BY nome DESC", con);


                    cn.Parameters.Add("@?", MySqlDbType.VarChar, 40).Value = objTabela.Nome + "%";

                    MySqlDataReader dr;


                    dr = cn.ExecuteReader();//executar o comando

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UsuarioEnt dado = new UsuarioEnt();
                            dado.Id = Convert.ToInt32(dr["id"]);
                            dado.Nome = Convert.ToString(dr["nome"]);
                            dado.Usuario = Convert.ToString(dr["usuario"]);
                            dado.CPF = Convert.ToString(dr["cpf"]);
                            dado.Senha = Convert.ToString(dr["senha"]);

                            lista.Add(dado);
                        }
                    }

                    con.Close();


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex);
            }

            return lista;
        }

        public int Editar(UsuarioEnt objTabela)
        {
            int qtd = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("UPDATE tb_usuario SET nome = ?, usuario = ?, cpf = ?, senha = ? WHERE id = ?", con);

                    

                    cn.Parameters.Add("@nome", MySqlDbType.VarChar, 40).Value = objTabela.Nome;
                    cn.Parameters.Add("@usuario", MySqlDbType.VarChar, 40).Value = objTabela.Usuario;
                    cn.Parameters.Add("@cpf", MySqlDbType.VarChar, 15).Value = objTabela.CPF;
                    cn.Parameters.Add("@senha", MySqlDbType.VarChar, 15).Value = objTabela.Senha;
                    cn.Parameters.Add("@?", MySqlDbType.Int32).Value = objTabela.Id;

                    //cn.Connection = con;
                    qtd = cn.ExecuteNonQuery();//executar o comando

                    con.Close();


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex);
            }

            return qtd;
        }

        public int Excluir(UsuarioEnt objTabela)
        {
            int qtd = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("DELETE FROM tb_usuario WHERE id = ?", con);

                    
                    cn.Parameters.Add("@?", MySqlDbType.Int16).Value = objTabela.Id;
                   

                    //cn.Connection = con;
                     qtd = cn.ExecuteNonQuery();//executar o comando

                    con.Close();


                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex);
            }

            return qtd;

        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
            {
                con.ConnectionString = Properties.Settings.Default.banco;



                con.Open();

                MySqlCommand cn = new MySqlCommand("SELECT * FROM tb_usuario WHERE usuario = usuario AND senha = senha", con);

                cn.Parameters.Add("@usuario",MySqlDbType.VarChar, 40).Value = obj.Nome;
                cn.Parameters.Add("@senha", MySqlDbType.VarChar, 15).Value = obj.Senha;


                MySqlDataReader dr;


                dr = cn.ExecuteReader();//executar o comando

               
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                       
                    }
                }
                else
                {
                    obj.Usuario = null;
                    obj.Senha = null;
                    con.Close();
                }
                con.Close();

                return obj;
                

            }
        }
            public List<UsuarioEnt> Lista()
        {
            List<UsuarioEnt> lista = new List<UsuarioEnt>();
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("SELECT *FROM tb_usuario ORDER BY nome DESC", con);

                    //cn.CommandType = CommandType.Text;
                    //cn.CommandText = "INSERT INTO tb_usuario (nome, usuario, cpf, senha) VALUES (?, ?, ?, ?)";
                    //cn.Connection = con;
                    

                    MySqlDataReader dr;
                    

                    dr = cn.ExecuteReader();//executar o comando

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UsuarioEnt dado = new UsuarioEnt();
                            dado.Id = Convert.ToInt32(dr["id"]);
                            dado.Nome = Convert.ToString(dr["nome"]);
                            dado.Usuario = Convert.ToString(dr["usuario"]);
                            dado.CPF = Convert.ToString(dr["cpf"]);
                            dado.Senha = Convert.ToString(dr["senha"]);

                            lista.Add(dado);
                        }
                    }

                    con.Close();
                    

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex);
            }

            return lista;

        }

        /*public int Mostrar()
        {
            try
            {
                ora.Open();
                comando = new OracleCommand("pcd_selecionaUsuario", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros",OracleType.Cursor).Direction=ParameterDirection.Output;

                OracleDataAdapter adapter = new OracleDataAdapter;
                adapter.SelectCommand = comando;
                DataTable table = new DataTable();
                adapter.Fill(table);

                ora.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Seleção: " + ex.Message);

            }
        }*/
    }
}
