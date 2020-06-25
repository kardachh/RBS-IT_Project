using RBS_IT_Project.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RBS_IT_Project
{
    public partial class FormMenu : Form
    {
        private FormAuthorization authorization;
        public FormMenu(FormAuthorization authorization)
        {
            InitializeComponent();
            this.authorization = authorization;
            labelHello.Text = "Добро пожаловать, " + FormAuthorization.users.name;
        }
        private void buttonOpenClients_Click(object sender, EventArgs e)
        {
            Form formClients = new FormClients(this);
            formClients.Show();
            Hide();
        }

        private void buttonOpenStaff_Click(object sender, EventArgs e)
        {
            Form formStaff = new FormStaff(this);
            formStaff.Show();
            Hide();
        }

        private void buttonOpenServiсes_Click(object sender, EventArgs e)
        {
            Form formServices = new FormServices(this);
            formServices.Show();
            Hide();
        }

        private void buttonOpenOrders_Click(object sender, EventArgs e)
        {
            Form formOrders = new FormOrders(this);
            formOrders.Show();
            Hide();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            authorization.Show();
        }

        private void buttonOpenDepartments_Click(object sender, EventArgs e)
        {
            Form formDepartments = new FormDepartments(this);
            formDepartments.Show();
            Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonExit_MouseMove(object sender, MouseEventArgs e)
        {
            buttonExit.BackColor = Color.Red;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.DarkRed;
        }
    }

}
