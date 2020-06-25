using System;
using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        public static User users = new User();

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" && textBoxPassword.Text == "")
            {
                MessageBox.Show("Введите данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool key = false;
                foreach (Users user in Program.RBS_Project.Users)
                {
                    if (textBoxLogin.Text == user.Login && textBoxPassword.Text == user.Password)
                    {
                        key = true;
                        users.login = user.Login;
                        users.password = user.Password;
                        users.type = user.Type;
                        if (user.Id_Staff != null)
                        {
                            users.name = user.StaffSet.LastName + " " + user.StaffSet.FirstName.Remove(1) + "." + user.StaffSet.MiddleName.Remove(1) + ".";
                        }
                        else users.name = "admin";
                    }
                }
                if (!key)
                {
                    MessageBox.Show("Проверьте данные", "Пользователь не найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    FormMenu menu = new FormMenu(this);
                    menu.Show();
                    Hide();
                    textBoxPassword.Text = "";
                }
            }
        }
        private void FormAuthorization_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonEnter.PerformClick();
        }
        public struct User
        {
            public string name;
            public string login;
            public string password;
            public string type;
        }

        private void FormAuthorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
