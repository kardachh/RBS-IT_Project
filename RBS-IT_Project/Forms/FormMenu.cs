using RBS_IT_Project.Forms;
using System;
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
            Form formClients = new FormClients();
            formClients.Show();
        }

        private void buttonOpenStaff_Click(object sender, EventArgs e)
        {
            Form formStaff = new FormStaff();
            formStaff.Show();
        }

        private void buttonOpenServiсes_Click(object sender, EventArgs e)
        {
            Form formServices = new FormServices();
            formServices.Show();
        }

        private void buttonOpenOrders_Click(object sender, EventArgs e)
        {
            Form formOrders = new FormOrders();
            formOrders.Show();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            authorization.Show();
        }

        private void buttonOpenDepartments_Click(object sender, EventArgs e)
        {
            Form formDepartments = new FormDepartments();
            formDepartments.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
