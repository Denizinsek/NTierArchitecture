using DataAccessLayer;
using EntityLayer;
using System.Collections.Generic;

namespace LogicLayer
{
    public class LogicEmployee
    {
        public static List<EntityEmployee> LLEmployeeList()
        {
            return DALEmployee.EmployeeList();
        }

        public static int LLEmployeeAdd(EntityEmployee e)
        {
            if (e.Name != "" && e.Surname != "" && e.Salary >= 3500 && e.Name.Length >= 3)
            {
                return DALEmployee.EmployeeAdd(e);
            }
            else
            {
                return -1;
            }
        }

        public static bool LLEmployeeDelete(int e)
        {
            if (e >= 1)
            {
                return DALEmployee.EmployeeDeleteById(e);
            }
            else
            {
                return false;
            }
        }

        public static bool LLEmployeeUpdate(EntityEmployee e)
        {
            if (e.Name.Length >= 3 && e.Name != "" && e.Salary >= 3000)
            {
                return DALEmployee.EmployeeUpdate(e);

            }
            else
            {
                return false;
            }
        }
    }
}
