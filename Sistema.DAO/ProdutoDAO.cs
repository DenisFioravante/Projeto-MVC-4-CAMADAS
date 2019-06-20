using MySql.Data.MySqlClient;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAO
{
    public class ProdutoDAO
    {
        public int Inserir(ProdutoEnt objTabela)
        {
            int qtd = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("INSERT INTO tb_produto (nome, descricao, valor) VALUES (?, ?, ?)", con);

                    

                    cn.Parameters.Add("@nome", MySqlDbType.VarChar, 40).Value = objTabela.Nome;
                    cn.Parameters.Add("@descricao", MySqlDbType.VarChar, 40).Value = objTabela.Descricao;
                    cn.Parameters.Add("@valor", MySqlDbType.Decimal).Value = objTabela.Valor;

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

        public List<ProdutoEnt> Buscar(ProdutoEnt objTabela)
        {
            List<ProdutoEnt> lista = new List<ProdutoEnt>();
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("SELECT *FROM tb_produto WHERE nome LIKE ?  ORDER BY nome DESC", con);


                    cn.Parameters.Add("@?", MySqlDbType.VarChar, 40).Value = objTabela.Nome + "%";

                    MySqlDataReader dr;


                    dr = cn.ExecuteReader();//executar o comando

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ProdutoEnt dado = new ProdutoEnt();
                            dado.Id = Convert.ToInt32(dr["id"]);
                            dado.Nome = Convert.ToString(dr["nome"]);
                            dado.Descricao = Convert.ToString(dr["descricao"]);
                            dado.Valor = Convert.ToDecimal(dr["valor"]);

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

        public int Editar(ProdutoEnt objTabela)
        {
            int qtd = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("UPDATE tb_produto SET nome = ?, descricao = ?,  valor = ? WHERE id = ?", con);



                    cn.Parameters.Add("@nome", MySqlDbType.VarChar, 40).Value = objTabela.Nome;
                    cn.Parameters.Add("@descricao", MySqlDbType.VarChar, 40).Value = objTabela.Descricao;
                    cn.Parameters.Add("@valor", MySqlDbType.Decimal).Value = objTabela.Valor;
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

        public int Excluir(ProdutoEnt objTabela)
        {
            int qtd = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("DELETE FROM tb_produto WHERE id = ?", con);


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

       
        public List<ProdutoEnt> Lista()
        {
            List<ProdutoEnt> lista = new List<ProdutoEnt>();
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1; port=3306; user id=root;password=278701;database=ProjetoMVC"))
                {
                    con.ConnectionString = Properties.Settings.Default.banco;



                    con.Open();
                    MySqlCommand cn = new MySqlCommand("SELECT *FROM tb_produto ORDER BY nome DESC", con);

                    

                    MySqlDataReader dr;


                    dr = cn.ExecuteReader();//executar o comando

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ProdutoEnt dado = new ProdutoEnt();
                            dado.Id = Convert.ToInt32(dr["id"]);
                            dado.Nome = Convert.ToString(dr["nome"]);
                            dado.Descricao = Convert.ToString(dr["descricao"]);
                            dado.Valor = Convert.ToDecimal(dr["valor"]);

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
    }
}
