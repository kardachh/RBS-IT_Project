using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormRegistration : Form
    {
        Users user = new Users();
        public FormRegistration(StaffSet staff)
        {
            InitializeComponent();
            user.Id_Staff = staff.Id;
        }

        private void buttonRegister_Click(object sender, System.EventArgs e)
        {
            if (textBoxLogin.Text != "" && textBoxPassword.Text!="" && textBoxRepeat.Text != "")
            {
                if (textBoxPassword.Text == textBoxRepeat.Text)
                {
                    user.Login = textBoxLogin.Text;
                    user.Password = textBoxPassword.Text;
                    user.Type = "staff";
                    Program.RBS_Project.Users.Add(user);
                    Program.RBS_Project.SaveChanges();
                    MessageBox.Show("Пользователь зарегестрирован.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
