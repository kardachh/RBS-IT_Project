using System;
using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormOrders : Form
    {
        private FormMenu formMenu;
        public FormOrders(FormMenu formMenu)
        {
            InitializeComponent();
            this.formMenu = formMenu;
            ShowClients();
            ShowService();
            ShowOrders();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxClient.SelectedItem != null && comboBoxService.SelectedItem != null
                    && comboBoxStatus.SelectedItem != null)
                {
                    OrdersSet ordersSet = new OrdersSet();
                    ordersSet.Id_Client = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    ordersSet.Id_Service = Convert.ToInt32(comboBoxService.SelectedItem.ToString().Split('.')[0]);
                    if (dateTimePickerDate.Value > dateTimePickerDeadline.Value)
                        throw new Exception("Дата начала не может быть позже даты окончания.");
                    ordersSet.Date = dateTimePickerDate.Value;
                    ordersSet.Deadline = dateTimePickerDeadline.Value;
                    ordersSet.Status = comboBoxStatus.SelectedItem.ToString();
                    Program.RBS_Project.OrdersSet.Add(ordersSet);
                    Program.RBS_Project.SaveChanges();
                    ShowOrders();
                }
                else MessageBox.Show("Заполнены не все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex){ MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 1)
            {
                if (comboBoxClient.SelectedItem != null && comboBoxService.SelectedItem != null
                    && comboBoxStatus.SelectedItem != null)
                {
                    OrdersSet ordersSet = listViewOrders.SelectedItems[0].Tag as OrdersSet;
                    ordersSet.Id_Client = Convert.ToInt32(comboBoxClient.SelectedItem.ToString().Split('.')[0]);
                    ordersSet.Id_Service = Convert.ToInt32(comboBoxService.SelectedItem.ToString().Split('.')[0]);
                    if (dateTimePickerDate.Value > dateTimePickerDeadline.Value)
                        throw new Exception("Дата начала не может быть позже даты окончания.");
                    ordersSet.Date = dateTimePickerDate.Value;
                    ordersSet.Deadline = dateTimePickerDeadline.Value;
                    ordersSet.Status = comboBoxStatus.SelectedItem.ToString();
                    Program.RBS_Project.SaveChanges();
                    ShowOrders();
                }
                else MessageBox.Show("Заполнены не все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewOrders.SelectedItems.Count == 1)
                {
                    OrdersSet orders = listViewOrders.SelectedItems[0].Tag as OrdersSet;
                    Program.RBS_Project.OrdersSet.Remove(orders);
                    Program.RBS_Project.SaveChanges();
                    ShowOrders();
                }
                comboBoxClient.SelectedItem = null;
                comboBoxService.SelectedItem = null;
                comboBoxStatus.SelectedItem = null;
                dateTimePickerDate.Value = DateTime.Now;
                dateTimePickerDeadline.Value = DateTime.Now;
            }
            catch { MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        void ShowClients()
        {
            comboBoxClient.Items.Clear();
            foreach(ClientsSet client in Program.RBS_Project.ClientsSet)
            {
                string[] item = {client.Id.ToString()+". ",client.Name};
                comboBoxClient.Items.Add(string.Join(" ", item));
            }
        }
        void ShowService()
        {
            comboBoxService.Items.Clear();
            foreach (ServicesSet services in Program.RBS_Project.ServicesSet)
            {
                string[] item = { services.Id.ToString() + ". ", services.Name };
                comboBoxService.Items.Add(string.Join(" ", item));
            }
        }
        void ShowOrders()
        {
            listViewOrders.Items.Clear();
            foreach (OrdersSet orders in Program.RBS_Project.OrdersSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    orders.Id.ToString(),
                    orders.ClientsSet.Name,
                    orders.ServicesSet.Name,
                    orders.ServicesSet.DepartmentsSet.Name,
                    orders.Date.ToString("dd/MM/yyyy"),
                    orders.Deadline.ToString("dd/MM/yyyy"),
                    orders.Status
                });
                item.Tag = orders;
                listViewOrders.Items.Add(item);
            }
            listViewOrders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 1)
            {
                OrdersSet orders = listViewOrders.SelectedItems[0].Tag as OrdersSet;
                comboBoxClient.SelectedIndex = comboBoxClient.FindString(orders.Id_Client.ToString());
                comboBoxService.SelectedIndex = comboBoxService.FindString(orders.Id_Service.ToString());
                comboBoxStatus.SelectedIndex = comboBoxStatus.FindString(orders.Status);
                dateTimePickerDate.Value = orders.Date;
                dateTimePickerDeadline.Value = orders.Deadline;
            }
            else
            {
                comboBoxClient.SelectedItem = null;
                comboBoxService.SelectedItem = null;
                comboBoxStatus.SelectedItem = null;
                dateTimePickerDate.Value = DateTime.Now;
                dateTimePickerDeadline.Value = DateTime.Now;
            }
        }

        private void FormOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMenu.Show();
        }
    }
}
