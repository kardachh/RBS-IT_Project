using System;
using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormServices : Form
    {
        public FormServices()
        {
            InitializeComponent();
            ShowServices();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxPrice.Text != "")
            {
                ServicesSet servicesSet = new ServicesSet();
                servicesSet.Name = textBoxName.Text;
                servicesSet.Price = Convert.ToInt32(textBoxPrice.Text);
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
                if (textBoxName.Text != "" && textBoxPrice.Text != "")
                {
                    ServicesSet servicesSet = listViewServises.SelectedItems[0].Tag as ServicesSet;
                    servicesSet.Name = textBoxName.Text;
                    servicesSet.Price = Convert.ToInt32(textBoxPrice.Text);
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
            }
            else
            {
                textBoxName.Text = "";
                textBoxPrice.Text = "";
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
                    services.Price.ToString()+" руб."
                });
                item.Tag = services;
                listViewServises.Items.Add(item);
            }
            listViewServises.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
