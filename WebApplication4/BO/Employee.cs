using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Xml.Serialization;
using System.Data.SqlClient;
namespace BO
{
    [Serializable]
    [XmlRoot("Employee")]
    public class Employee
    {
        public static string connectionString = ConfigurationSettings.AppSettings["connectionstring"];
        [XmlElement("Id")]
        public int? Id { get; set; }
        [XmlElement("FName")]
        public string FName { get; set; }
        [XmlElement("MName")]
        public string MName { get; set; }
        [XmlElement("LName")]
        public string LName { get; set; }
        [XmlElement("Age")]
        public int? Age { get; set; }
        [XmlElement("Designation")]
        public string Designation { get; set; }
        [XmlElement("Salary")]
        public int Salary { get; set; }
        public bool Insert()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {               
                string strQuery = "Insert into Employee values(@FName,@MName,@LName,@Age,@Designation,@Salary)";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@FName", FName);
                cmd.Parameters.AddWithValue("@MName", MName);
                cmd.Parameters.AddWithValue("@LName", LName);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@Salary", Salary);
                connection.Open();               
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool Update()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                string strQuery = "Update Employee  set FName=@FName,MName=@MName,LName=@LName,@Age=Age,@Designation=Designation,@Salary=Salary where id=@id";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@FName", FName);
                cmd.Parameters.AddWithValue("@MName", MName);
                cmd.Parameters.AddWithValue("@LName", LName);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@Salary", Salary);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        public bool Delete()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {               
                string strQuery = "Delete from Employee where id=@id";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Connection = connection;
                connection.Open();
                cmd.ExecuteNonQuery();
                                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;

        }

        public Employee Get(int id)
        {
            Employee obj = new Employee();
              SqlConnection connection = new SqlConnection(connectionString);
            try
            {              
                string strQuery = "Select * from Employee where id=@id";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.Id = Convert.ToInt32(dr["Id"]);
                        obj.FName = Convert.ToString(dr["FName"]);
                        obj.LName = Convert.ToString(dr["LName"]);
                        obj.MName = Convert.ToString(dr["MName"]);
                        obj.Age = Convert.ToInt32(dr["Age"]);
                        obj.Designation = Convert.ToString(dr["Designation"]);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return obj;
        }

        public List<Employee> GetAll()
        {
            List<Employee> lstemployee = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                lstemployee = new List<Employee>();
                DataSet ds = new DataSet();             
                string strQuery = "Select * from Employee";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Employee obj = new Employee();
                        obj.Id = Convert.ToInt32(dr["Id"]);
                        obj.FName = Convert.ToString(dr["FName"]);
                        obj.LName = Convert.ToString(dr["LName"]);
                        obj.MName = Convert.ToString(dr["MName"]);
                        obj.Age = Convert.ToInt32(dr["Age"]);
                        obj.Designation = Convert.ToString(dr["Designation"]);
                        lstemployee.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return lstemployee;
        }
    }
}

