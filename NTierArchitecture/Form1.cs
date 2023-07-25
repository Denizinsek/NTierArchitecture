using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NTierArchitecture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            List<EntityEmployee> empList = LogicEmployee.LLEmployeeList();
            dataGridView1.DataSource = empList;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EntityEmployee ent = new EntityEmployee();
            ent.Name = TxtName.Text;
            ent.Surname = TxtSurname.Text;
            ent.City = TxtCity.Text;
            ent.Job1 = TxtJob.Text;
            ent.Salary = int.Parse(TxtSalary.Text);
            LogicEmployee.LLEmployeeAdd(ent);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            EntityEmployee ent = new EntityEmployee();
            ent.Id = Convert.ToInt32(TxtID.Text);
            LogicEmployee.LLEmployeeDelete(ent.Id);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            EntityEmployee ent = new EntityEmployee();
            ent.Id = Convert.ToInt32(TxtID.Text);
            ent.Name = TxtName.Text;
            ent.Surname = TxtSurname.Text;
            ent.City = TxtCity.Text;
            ent.Job1 = TxtJob.Text;
            ent.Salary = int.Parse(TxtSalary.Text);
            LogicEmployee.LLEmployeeUpdate(ent);
        }
    }
}
