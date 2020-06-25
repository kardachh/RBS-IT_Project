using System;
using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormServices : Form
    {
        private FormMenu formMenu;
        public FormServices(FormMenu formMenu)
        {
            InitializeComponent();
            this.formMenu = formMenu;
            ShowServices();
            ShowDepartments();
            if (FormAuthorization.users.type != "admin")
            {
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                textBoxName.Enabled = false;
                textBoxPrice.Enabled = false;
                comboBoxDepartment.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                textBoxName.Enabled = true;
                textBoxPrice.Enabled = true;
                comboBoxDepartment.Enabled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxPrice.Text != "" && comboBoxDepartment.SelectedItem != null)
            {
                ServicesSet servicesSet = new ServicesSet();
                servicesSet.Name = textBoxName.Text;
                servicesSet.Price = Convert.ToInt32(textBoxPrice.Text);
                servicesSet.Id_Department = Convert.ToInt32(comboBoxDepartment.SelectedItem.ToString().Split('.')[0]);
                Program.RBS_Project.ServicesSet.Add(servicesSet);
                Program.RBS_Project.SaveChanges();
                ShowServices();
            }
            else MessageBox.Show("Заполнены не все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewServises.SelectedItems.Count == 1)
            {
                if (textBoxName.Text != "" && textBoxPrice.Text != "" && comboBoxDepartment.SelectedItem != null)
                {
                    ServicesSet servicesSet = listViewServises.SelectedItems[0].Tag as ServicesSet;
                    servicesSet.Name = textBoxName.Text;
                    servicesSet.Price = Convert.ToInt32(textBoxPrice.Text);
                    servicesSet.Id_Department = Convert.ToInt32(comboBoxDepartment.SelectedItem.ToString().Split('.')[0]);
                    Program.RBS_Project.SaveChanges();
                    ShowServices();
                }
                else MessageBox.Show("Заполнены не все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewServises.SelectedItems.Count == 1)
                {
                    ServicesSet services = listViewServises.SelectedItems[0].Tag as ServicesSet;
                    Program.RBS_Project.ServicesSet.Remove(services);
                    Program.RBS_Project.SaveChanges();
                    ShowServices();
                }
                textBoxName.Text = "";
                textBoxPrice.Text = "";
                comboBoxDepartment.SelectedItem = null;
            }
            catch { MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void listViewServises_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewServises.SelectedItems.Count == 1)
            {
                ServicesSet services = listViewServises.SelectedItems[0].Tag as ServicesSet;
                textBoxName.Text = services.Name;
                textBoxPrice.Text = services.Price.ToString();
                comboBoxDepartment.SelectedIndex = comboBoxDepartment.FindString(services.Id_Department.ToString());
            }
            else
            {
                textBoxName.Text = "";
                textBoxPrice.Text = "";
                comboBoxDepartment.SelectedItem = null;
            }
        }
        void ShowServices()
        {
            listViewServises.Items.Clear();
            foreach(ServicesSet services in Program.RBS_Project.ServicesSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    services.Id.ToString(),
                    services.Name,
                    services.DepartmentsSet.Name,
                    services.Price.ToString()+" руб."
                });
                item.Tag = services;
                listViewServises.Items.Add(item);
            }
            listViewServises.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        void ShowDepartments()
        {
            comboBoxDepartment.Items.Clear();
            foreach (DepartmentsSet departments in Program.RBS_Project.DepartmentsSet)
            {
                string[] item = { departments.Id.ToString() + ". ", departments.Name };
                comboBoxDepartment.Items.Add(string.Join(" ", item));
            }
        }

        private void FormServices_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMenu.Show();
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8) //цифры и backspace
            {
                e.Handled = true;
            }
        }
    }
}
