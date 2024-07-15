using MySql.Data.MySqlClient;
using STUDENTS_DETAILS_DATACONTRACTS;
using STUDENTS_DETAILS_DATAOBJECTS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace STUDENTS_DETAILS_BL
{
    public class students_details_bl
    {

        public int get_Students_List(ref get_student_details_list_ip ip, ref get_student_details_list_op op, string connectionString)
        {
            string query = "SELECT * FROM tbl_student_details";
     
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tbl_students_details detials = new tbl_students_details();
                    detials.Id = reader.GetInt64("Id");
                    detials.FirstName = reader.GetString("FirstName");
                    detials.LastName = reader.GetString("LastName");
                    detials.DateOfBirth = DateTime.Parse(reader.GetString("DateOfBirth"));
                    detials.FatherName = reader.GetString("FatherName");
                    detials.MotherName = reader.GetString("MotherName");
                    detials.BloodGroup = reader.GetString("BloodGroup");
                    detials.Email = reader.GetString("Email");
                    detials.Address = reader.GetString("Address");
                    detials.PhoneNumber = reader.GetString("PhoneNumber");
                    detials.RollNo = reader.GetString("RollNo");
                    detials.Gender = reader.GetString("Gender");
                    detials.AdmissionDate = DateTime.Parse(reader.GetString("AdmissionDate"));
                    op.ml_students.Add(detials);
                }
            }
            connection.Close(); 
            return 0;
           

        }

        public int get_Students_Detail(ref get_student_detail_ip ip, ref get_student_detail_op op, string connectionString)
        {
            string query = "SELECT * FROM tbl_student_details WHERE ID = " + ip.m_ID;


            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tbl_students_details detials = new tbl_students_details();
                    op.m_student.Id = reader.GetInt64("Id");
                    op.m_student.FirstName = reader.GetString("FirstName");
                    op.m_student.LastName = reader.GetString("LastName");
                    op.m_student.DateOfBirth = DateTime.Parse(reader.GetString("DateOfBirth"));
                    op.m_student.FatherName = reader.GetString("FatherName");
                    op.m_student.MotherName = reader.GetString("MotherName");
                    op.m_student.BloodGroup = reader.GetString("BloodGroup");
                    op.m_student.Email = reader.GetString("Email");
                    op.m_student.Address = reader.GetString("Address");
                    op.m_student.PhoneNumber = reader.GetString("PhoneNumber");
                    op.m_student.RollNo = reader.GetString("RollNo");
                    op.m_student.Gender = reader.GetString("Gender");
                    op.m_student.AdmissionDate = DateTime.Parse(reader.GetString("AdmissionDate"));
                    
                }
            }
            connection.Close();
            return 0;


        }

        public int put_Students_Detail(ref put_student_detail_ip ip, ref put_student_detail_op op, string connectionString)
        {
            string query = "INSERT INTO tbl_student_details (Id, FirstName, LastName, DateOfBirth, FatherName, MotherName, BloodGroup, Email, Address, PhoneNumber, RollNo, Gender, AdmissionDate) " +
               "VALUES (@Id, @FirstName, @LastName, @DateOfBirth, @FatherName, @MotherName, @BloodGroup, @Email, @Address, @PhoneNumber, @RollNo, @Gender, @AdmissionDate)";

 
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", ip.m_student.Id);
                        command.Parameters.AddWithValue("@FirstName", ip.m_student.FirstName);
                        command.Parameters.AddWithValue("@LastName", ip.m_student.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", ip.m_student.DateOfBirth);
                        command.Parameters.AddWithValue("@FatherName", ip.m_student.FatherName);
                        command.Parameters.AddWithValue("@MotherName", ip.m_student.MotherName);
                        command.Parameters.AddWithValue("@BloodGroup", ip.m_student.BloodGroup);
                        command.Parameters.AddWithValue("@Email", ip.m_student.Email);
                        command.Parameters.AddWithValue("@Address", ip.m_student.Address);
                        command.Parameters.AddWithValue("@PhoneNumber", ip.m_student.PhoneNumber);
                        command.Parameters.AddWithValue("@RollNo", ip.m_student.RollNo);
                        command.Parameters.AddWithValue("@Gender", ip.m_student.Gender);
                        command.Parameters.AddWithValue("@AdmissionDate", ip.m_student.AdmissionDate);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return -1;
                    }
                }
            }

            op.m_student = ip.m_student;
            return 0;
        }


    }
}
