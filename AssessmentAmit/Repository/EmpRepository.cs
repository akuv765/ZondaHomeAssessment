using AssessmentAmit.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AssessmentAmit.Repository
{
    public class EmpRepository
    {
        private SqlConnection con;

        // To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["Dbconnection"].ToString();
            con = new SqlConnection(constr);
        }

        // To Add Employee details
        public bool AddEmployee(Employee obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("AddEmpDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FirstName", obj.FirstName);
                com.Parameters.AddWithValue("@LastName", obj.LastName);
                com.Parameters.AddWithValue("@Department", obj.Department);
                com.Parameters.AddWithValue("@Basic", obj.Basic);

                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        // To view employee details with generic list
        public List<Employee> GetAllEmployees()
        {
            connection();
            List<Employee> EmpList = new List<Employee>();

            SqlCommand com = new SqlCommand("GetEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            // Bind Employee generic list using dataRow
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new Employee
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Department = Convert.ToString(dr["Department"]),
                        Basic = Convert.ToDecimal(dr["Basic"]),
                        HRA = Convert.ToDecimal(dr["HRA"]),
                        DA = Convert.ToDecimal(dr["DA"]),
                        TA = Convert.ToDecimal(dr["TA"])
                    }
                );
            }

            return EmpList;
        }

        // To Update Employee details
        public bool UpdateEmployee(Employee obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("UpdateEmpDetails", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", obj.Id);
                com.Parameters.AddWithValue("@FirstName", obj.FirstName);
                com.Parameters.AddWithValue("@LastName", obj.LastName);
                com.Parameters.AddWithValue("@Department", obj.Department);
                com.Parameters.AddWithValue("@Basic", Convert.ToDecimal(obj.Basic));

                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        // To delete Employee details
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}