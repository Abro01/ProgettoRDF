using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProgettoRDF
{
    public partial class Registrazione : Form
    {
        myDBconnection con = new myDBconnection();
        MySqlDataAdapter da;
        DataTable dt = new DataTable();

        public Registrazione()
        {
            InitializeComponent();
            con.Connect();
        }

        private void btRegistrazione_Click(object sender, EventArgs e)
        {
            //Controllo che  tutti i campi siano compilati
            if ((String.IsNullOrEmpty(textEmail.Text)) || (String.IsNullOrEmpty(textPassword.Text)) || (String.IsNullOrEmpty(textNome.Text)) || (String.IsNullOrEmpty(textCognome.Text)) || (String.IsNullOrEmpty(textUser.Text)))
            {
                MessageBox.Show("E' necessario compilare tutti i campi");
            }
            else
            {
                string emailIN = textEmail.Text;
                string passwordIN = textPassword.Text;
                string nomeIn = textNome.Text;
                string cognomeIn = textCognome.Text;
                string userIn = textUser.Text;

                try
                {
                    con.cn.Open();
                    string query = $"INSERT INTO `utenti` (`ID`, `Email`, `Nome`, `Cognome`, `Username`, `Password`) VALUES ('', '" + textEmail.Text + "', '" + textNome.Text + "', '" + textCognome.Text + "', '" + textUser.Text + "', MD5('" + textPassword.Text + "'));";
                    MySqlCommand command = new MySqlCommand(query, con.cn);
                    command.ExecuteNonQuery();
                    MessageBox.Show(query);
                    Login loginReg = new Login();
                    loginReg.Show();
                    this.Hide();
                }
                catch
                {

                }
                finally
                {

                    con.cn.Close();
                }
            }
            

            
           
        }
    }
}
