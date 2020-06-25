using System;
using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormClients : Form
    {
        FormMenu formMenu;
        public FormClients(FormMenu formMenu)
        {
            InitializeComponent();
            this.formMenu = formMenu;
            ShowClients();
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxPhone.Text != "" && textBoxEmail.Text != "")
            {
                ClientsSet clientsSet = new ClientsSet();
                clientsSet.Name = textBoxName.Text;
                clientsSet.Phone = textBoxPhone.Text;
                clientsSet.Email = textBoxEmail.Text;
                Program.RBS_Project.ClientsSet.Add(clientsSet);
                Program.RBS_Project.SaveChanges();
                ShowClients();
            }
            else MessageBox.Show("Заполнены не все поля!","Ошибка!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        void ShowClients()
        {
            listViewClients.Items.Clear();
            foreach (ClientsSet clients in Program.RBS_Project.ClientsSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    clients.Id.ToString(),
                    clients.Name,
                    clients.Phone,
                    clients.Email
                });
                item.Tag = clients;
                listViewClients.Items.Add(item);
            }
            listViewClients.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewClients.SelectedItems.Count == 1)
            {
                ClientsSet clients = listViewClients.SelectedItems[0].Tag as ClientsSet;
                textBoxName.Text = clients.Name;
                textBoxPhone.Text = clients.Phone;
                textBoxEmail.Text = clients.Email;
            }
            else
            {
                textBoxName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewClients.SelectedItems.Count == 1)
            {
                if (textBoxName.Text != "" && textBoxPhone.Text != "" && textBoxEmail.Text != "")
                {
                    ClientsSet clientsSet = listViewClients.SelectedItems[0].Tag as ClientsSet;
                    clientsSet.Name = textBoxName.Text;
                    clientsSet.Phone = textBoxPhone.Text;
                    clientsSet.Email = textBoxEmail.Text;
                    Program.RBS_Project.SaveChanges();
                    ShowClients();
                }
                else MessageBox.Show("Заполнены не все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClients.SelectedItems.Count == 1)
                {
                    ClientsSet clientsSet = listViewClients.SelectedItems[0].Tag as ClientsSet;
                    Program.RBS_Project.ClientsSet.Remove(clientsSet);
                    Program.RBS_Project.SaveChanges();
                    ShowClients();
                }
                textBoxName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMenu.Show();
        }
    }
}
