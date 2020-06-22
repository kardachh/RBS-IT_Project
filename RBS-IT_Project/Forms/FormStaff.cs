using System;
using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormStaff : Form
    {
        public FormStaff()
        {
            InitializeComponent();
            ShowStaff();
            ShowDepartments();
            if (FormAuthorization.users.type != "admin")
            {
                buttonAdd.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                buttonRegistration.Visible = false;
                textBoxLastName.Enabled = false;
                textBoxFirstName.Enabled = false;
                textBoxMiddleName.Enabled = false;
                textBoxPhone.Enabled = false;
                textBoxEmail.Enabled = false;
                textBoxPosition.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
                buttonRegistration.Visible = true;
                textBoxLastName.Enabled = true;
                textBoxFirstName.Enabled = true;
                textBoxMiddleName.Enabled = true;
                textBoxPhone.Enabled = true;
                textBoxEmail.Enabled = true;
                textBoxPosition.Enabled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxLastName.Text != "" && textBoxFirstName.Text != ""
                && textBoxMiddleName.Text != "" && textBoxPhone.Text != ""
                && textBoxEmail.Text != "" && textBoxPosition.Text != "")
            {
                StaffSet staffSet = new StaffSet();
                staffSet.LastName = textBoxLastName.Text;
                staffSet.FirstName = textBoxFirstName.Text;
                staffSet.MiddleName = textBoxMiddleName.Text;
                staffSet.Phone = textBoxPhone.Text;
                staffSet.Email = textBoxEmail.Text;
                staffSet.Position = textBoxPosition.Text;
                if (comboBoxDepartment.SelectedItem != null)
                    staffSet.Id_Department = Convert.ToInt32(comboBoxDepartment.SelectedItem.ToString().Split('.')[0]);
                Program.RBS_Project.StaffSet.Add(staffSet);
                Program.RBS_Project.SaveChanges();
                ShowStaff();
            }
            else MessageBox.Show("Заполнены не все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewStaff.SelectedItems.Count == 1)
            {
                if (textBoxLastName.Text != "" && textBoxFirstName.Text != ""
                && textBoxMiddleName.Text != "" && textBoxPhone.Text != ""
                && textBoxEmail.Text != "" && textBoxPosition.Text != "")
                {
                    StaffSet staffSet = listViewStaff.SelectedItems[0].Tag as StaffSet;
                    staffSet.LastName = textBoxLastName.Text;
                    staffSet.FirstName = textBoxFirstName.Text;
                    staffSet.MiddleName = textBoxMiddleName.Text;
                    staffSet.Phone = textBoxPhone.Text;
                    staffSet.Email = textBoxEmail.Text;
                    staffSet.Position = textBoxPosition.Text;
                    if (comboBoxDepartment.SelectedItem != null)
                        staffSet.Id_Department = Convert.ToInt32(comboBoxDepartment.SelectedItem.ToString().Split('.')[0]);
                    else staffSet.Id_Department = null;
                    Program.RBS_Project.SaveChanges();
                    ShowStaff();
                }
                else MessageBox.Show("Заполнены не все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewStaff.SelectedItems.Count == 1)
                {
                    StaffSet staff = listViewStaff.SelectedItems[0].Tag as StaffSet;
                    bool found = false;
                    Users user = new Users();
                    foreach (Users users in Program.RBS_Project.Users)
                    {
                        if (staff.Id == users.Id_Staff)
                        { found = true; user = users; }
                    }
                    if (found)
                    {
                        Program.RBS_Project.Users.Remove(user);
                    }
                    Program.RBS_Project.StaffSet.Remove(staff);
                    Program.RBS_Project.SaveChanges();
                    ShowStaff();
                }
                textBoxLastName.Text = "";
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                textBoxPosition.Text = "";
                comboBoxDepartment.SelectedItem = null;
            }
            catch { MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        void ShowStaff()
        {
            listViewStaff.Items.Clear();
            foreach (StaffSet staff in Program.RBS_Project.StaffSet)
            {
                DepartmentsSet departmentsSet = new DepartmentsSet();
                foreach (DepartmentsSet departments in Program.RBS_Project.DepartmentsSet)
                {
                    if (staff.Id_Department == departments.Id)
                        departmentsSet = departments; 
                }
                ListViewItem item = new ListViewItem(new string[]
                {
                    staff.Id.ToString(),
                    staff.LastName+" "+staff.FirstName+" "+staff.MiddleName,
                    staff.Phone,
                    staff.Email,
                    staff.Position,
                    departmentsSet.Name
                });
                item.Tag = staff;
                listViewStaff.Items.Add(item);
            }
            listViewStaff.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStaff.SelectedItems.Count == 1)
            {
                StaffSet staff = listViewStaff.SelectedItems[0].Tag as StaffSet;
                textBoxLastName.Text = staff.LastName;
                textBoxFirstName.Text = staff.FirstName;
                textBoxMiddleName.Text = staff.MiddleName;
                textBoxPhone.Text = staff.Phone;
                textBoxEmail.Text = staff.Email;
                textBoxPosition.Text = staff.Position;
                if (staff.Id_Department != null)
                    comboBoxDepartment.SelectedIndex = comboBoxDepartment.FindString(staff.Id_Department.ToString());
            }
            else
            {
                textBoxLastName.Text = "";
                textBoxFirstName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxPhone.Text = "";
                textBoxEmail.Text = "";
                textBoxPosition.Text = "";
                comboBoxDepartment.SelectedItem = null;
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (listViewStaff.SelectedItems.Count == 1)
            {
                StaffSet staff = listViewStaff.SelectedItems[0].Tag as StaffSet;
                bool found = false;
                Users user = new Users();
                foreach (Users users in Program.RBS_Project.Users)
                {
                    if (staff.Id == users.Id_Staff)
                    { found = true; user = users; }
                }
                if (found)
                {
                    Form formChangePassword = new FormChangePassword(user);
                    formChangePassword.Show();
                }
                else
                {
                    Form formRegistration = new FormRegistration(staff);
                    formRegistration.Show();
                }
            }
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
    }
}
