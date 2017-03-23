using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Faculty
{
    public class MySQLDBManager : IDBManager
    {
        private string connString;

        public MySQLDBManager()
        {
            // connString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connString = "Server=127.0.1;Port=3306;Database=db;Uid=root;Pwd=1234;";
        }

        public IList<Student> RetrieveStudents()
        {
            IList<Student> studentList = new List<Student>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM student";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.ID = reader.GetInt32("ID");
                        student.Name = reader.GetString("Name");
                        student.BirthDate = reader.GetDateTime("BirthDate");
                        student.Address = reader.GetString("Address");
                        studentList.Add(student);
                    }
                }
            }

            return studentList;
        }

        public void AddStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO student(id, name, birthdate, address) VALUES(@id, @name, @birthdate, @address)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", student.ID);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@birthdate", student.BirthDate);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE student SET name = @name WHERE ID = @ID";
                cmd.Parameters.AddWithValue("name", student.Name);
                cmd.Parameters.AddWithValue("ID", student.ID);
                cmd.Connection = conn;


                cmd.ExecuteNonQuery();



            }
        }

        public void DeleteStudent(Student student)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM student WHERE ID = @ID";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@ID", student.ID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
        }


        //course

        public IList<Course> RetrieveCourses()
        {
            IList<Course> courseList = new List<Course>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM course";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Course course = new Course();
                        course.ID = reader.GetInt32("ID");
                        course.Name = reader.GetString("Name");
                        course.Teacher = reader.GetString("Teacher");
                        course.Year = reader.GetInt32("Year");
                        courseList.Add(course);
                    }
                }
            }

            return courseList;
        }

        public void AddCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO course(id, name, teacher, year) VALUES(@id, @name, @teacher, @year)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", course.ID);
                cmd.Parameters.AddWithValue("@name", course.Name);
                cmd.Parameters.AddWithValue("@teacher", course.Teacher);
                cmd.Parameters.AddWithValue("@year", course.Teacher);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(Course course)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE student SET name = @name WHERE ID = @ID";
                cmd.Parameters.AddWithValue("name", course.Name);
                cmd.Parameters.AddWithValue("ID", course.ID);
                cmd.Connection = conn;


                cmd.ExecuteNonQuery();



            }
        }

        public void DeleteCourse(Course course)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM course WHERE ID = @ID";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@ID", course.ID);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
        }

        public void EnrollStudent( Enroll enroll)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO enroll(id, id_student, id_curs) VALUES(@ID, @IdStudent, @IdCourse)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@ID", enroll.ID);
                cmd.Parameters.AddWithValue("@IdStudent", enroll.IdStudent);
                cmd.Parameters.AddWithValue("@IdCourse", enroll.IdCourse);
                cmd.ExecuteNonQuery();
            }
        }



        //test
        public  bool AddTest(Student s)
        {

            try
            {
                AddStudent(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool UpdateTest(Student s)
        {

            try
            {
                UpdateStudent(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool DeleteTest(Student s)
        {

            try
            {
                DeleteStudent(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

      
    }
}
