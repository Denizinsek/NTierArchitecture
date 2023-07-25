using EntityLayer;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DALEmployee
    {
        public static List<EntityEmployee> EmployeeList()
        {
            List<EntityEmployee> values = new List<EntityEmployee>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATİON", Connection.connection);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EntityEmployee ent = new EntityEmployee();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Name = dr["NAME"].ToString();
                ent.Surname = dr["SURNAME"].ToString();
                ent.City = dr["CİTY"].ToString();
                ent.Job1 = dr["JOB"].ToString();
                ent.Salary = int.Parse(dr["Salary"].ToString());
                values.Add(ent);
            }
            dr.Close();
            return values;
        }

        public static int EmployeeAdd(EntityEmployee e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO INFORMATİON(NAME,SURNAME,CİTY,JOB,SALARY) VALUES(@P1,@P2,@P3,@P4,@P5)", Connection.connection);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Parameters.AddWithValue("@P1", e.Name);
            cmd.Parameters.AddWithValue("@P2", e.Surname);
            cmd.Parameters.AddWithValue("@P3", e.City);
            cmd.Parameters.AddWithValue("@P4", e.Job1);
            cmd.Parameters.AddWithValue("@P5", e.Salary);
            return cmd.ExecuteNonQuery();
        }

        public static bool EmployeeDeleteById(int employeeId)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM INFORMATİON WHERE ID=@P1", Connection.connection);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            cmd.Parameters.AddWithValue("@P1", employeeId);
            return cmd.ExecuteNonQuery() > 0;
        }
        public static bool EmployeeUpdate(EntityEmployee e)
        {
            {

                SqlCommand cmd = new SqlCommand("UPDATE INFORMATİON SET NAME=@P1, SURNAME=@P2, CİTY=@P3, JOB=@P4, SALARY=@P5 WHERE ID=@P6", Connection.connection);
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                cmd.Parameters.AddWithValue("@P1", e.Name);
                cmd.Parameters.AddWithValue("@P2", e.Surname);
                cmd.Parameters.AddWithValue("@P3", e.City);
                cmd.Parameters.AddWithValue("@P4", e.Job1);
                cmd.Parameters.AddWithValue("@P5", e.Salary);
                cmd.Parameters.AddWithValue("@P6", e.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
