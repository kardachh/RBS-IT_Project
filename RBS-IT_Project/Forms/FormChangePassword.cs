using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormChangePassword : Form
    {
        Users user = new Users();
        public FormChangePassword(Users user)
        {
            InitializeComponent();
            this.user = user;
            textBoxLogin.Text = user.Login;
        }

        private void buttonChange_Click(object sender, System.EventArgs e)
        {
            if ((textBoxLogin.Text == user.Login) && (textBoxOldPassword.Text == user.Password))
            {
                if(textBoxNewPassword.Text == textBoxRepeat.Text)
                {
                    user.Password = textBoxNewPassword.Text;
                    Program.RBS_Project.SaveChanges();
                    MessageBox.Show("Пароль успешно сменен.", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
