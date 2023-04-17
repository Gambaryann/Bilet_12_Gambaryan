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

namespace Bilet_12_Gambaryan
{
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();
        DataTable dt;


        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool loginInData = false;
            bool kvalRegistrPass = false;
            bool kvalSimvolPass = false;

            string login = textBox1.Text;
            string password = textBox2.Text;

            char[] registr = "QWERTYUIOPASDFGHJKLZXCVBNM".ToArray();
            char[] simvol = "@,!".ToArray();

            
            dt = db.ExecuteSql($"select * from users where login = '{login}'");


            if (dt.Rows.Count > 0)
            {
                loginInData = true;
            }

            foreach (char c in password)
            {
                foreach (char r in registr)
                {
                    if (c == r)
                    {
                        kvalRegistrPass = true;
                        break;
                    }
                }

                foreach (char s in simvol)
                {
                    if (c == s)
                    {
                        kvalSimvolPass = true;
                        break;
                    }
                }
            }

            if (password.Length == 5 && kvalRegistrPass && kvalSimvolPass && !loginInData)
            {
                db.ExecuteNonQuery($"insert into users values('{login}', '{password}')");
                

                MessageBox.Show("Вы успешно зарегистрировались!", "Успешно");
            }

            else
            {
                MessageBox.Show("Пароль должен содержать буквы верхнего регистра и специальные символы, " +
                                "либо пользователь с таким логином уже существует", "Ошибка");
            }


        }
    }
}
