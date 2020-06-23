using System;
using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormDepartments : Form
    {
        public FormDepartments()
        {
            InitializeComponent();
            ShowManager();
            ShowDepartments();
            if (FormAuthorization.users.type != "admin")
            {
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                comboBoxManager.Enabled = false;
                textBoxName.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                comboBoxManager.Enabled = true;
                textBoxName.Enabled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                DepartmentsSet departmentsSet = new DepartmentsSet();
                departmentsSet.Name = textBoxName.Text;
                if (comboBoxManager.SelectedItem != null)
                    departmentsSet.Manager = comboBoxManager.SelectedItem.ToString();
                Program.RBS_Project.DepartmentsSet.Add(departmentsSet);
                Program.RBS_Project.SaveChanges();
                ShowDepartments();
            }
            else MessageBox.Show("Заполните название отдела!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDepartments.SelectedItems.Count == 1)
            {
                if (textBoxName.Text != "")
                {
                    DepartmentsSet departmentsSet = listViewDepartments.SelectedItems[0].Tag as DepartmentsSet;
                    departmentsSet.Name = textBoxName.Text;
                    if (comboBoxManager.SelectedItem != null)
                        departmentsSet.Manager = comboBoxManager.SelectedItem.ToString();
                    Program.RBS_Project.SaveChanges();
                    ShowDepartments();
                }
                else MessageBox.Show("Заполните название отдела!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDepartments.SelectedItems.Count == 1)
                {
                    DepartmentsSet departmentsSet = listViewDepartments.SelectedItems[0].Tag as DepartmentsSet;
                    Program.RBS_Project.DepartmentsSet.Remove(departmentsSet);
                    Program.RBS_Project.SaveChanges();
                }
                textBoxName.Text = "";
                comboBoxManager.SelectedItem = null;
                ShowDepartments();
            }
            catch { MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void listViewDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDepartments.SelectedItems.Count == 1)
            {
                DepartmentsSet departmentsSet = listViewDepartments.SelectedItems[0].Tag as DepartmentsSet;
                textBoxName.Text = departmentsSet.Name;
                if (departmentsSet.Manager != null)
                    comboBoxManager.SelectedIndex = comboBoxManager.FindString(departmentsSet.Id.ToString());
            }
            else
            {
                textBoxName.Text = "";
                comboBoxManager.SelectedItem = null;
            }
        }
        void ShowManager()
        {
            comboBoxManager.Items.Clear();
            foreach(StaffSet staff in Program.RBS_Project.StaffSet)
            {
                string[] item = { staff.Id.ToString()+". ", staff.LastName,
                staff.FirstName.Remove(1)+".",staff.MiddleName.Remove(1)+"."};
                comboBoxManager.Items.Add(string.Join(" ", item));
            }
        }
        void ShowDepartments()
        {
            listViewDepartments.Items.Clear();
            foreach (DepartmentsSet departments in Program.RBS_Project.DepartmentsSet)
            {
                Deductions(departments);
                ListViewItem item = new ListViewItem(new string[]
                {
                    departments.Id.ToString(),
                    departments.Name,
                    departments.Count.ToString(),
                    departments.Manager
                });
                item.Tag = departments;
                listViewDepartments.Items.Add(item);
            }
            listViewDepartments.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        void Deductions(DepartmentsSet department)
        {
            int count = 0;
            foreach (StaffSet staff in Program.RBS_Project.StaffSet)
            {
                if (staff.Id_Department == department.Id)
                    count++;
            }
            department.Count = count;
        }

        private void listViewDepartments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewDepartments.SelectedItems.Count == 1)
            {
                DepartmentsSet departmentsSet = listViewDepartments.SelectedItems[0].Tag as DepartmentsSet;
                Form formInfo = new FormInfo(departmentsSet);
                formInfo.Show();
            }
        }
    }
}
