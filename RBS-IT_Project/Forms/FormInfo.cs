using System.Windows.Forms;

namespace RBS_IT_Project.Forms
{
    public partial class FormInfo : Form
    {
        DepartmentsSet departments = new DepartmentsSet();
        public FormInfo(DepartmentsSet departments)
        {
            InitializeComponent();
            this.departments = departments;
            Text = "Информация об отделе: " + departments.Name;
            ShowInfo();
        }
        void ShowInfo()
        {
            listViewInfo.Items.Clear();
            foreach (StaffSet staff in Program.RBS_Project.StaffSet)
            {
                if (departments.Id == staff.Id_Department)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                    staff.Id.ToString(),
                    staff.LastName+" "+staff.FirstName+" "+staff.MiddleName,
                    staff.Phone,
                    staff.Email,
                    staff.Position,
                    });
                    item.Tag = staff;
                    listViewInfo.Items.Add(item);
                }
                listViewInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }
}
