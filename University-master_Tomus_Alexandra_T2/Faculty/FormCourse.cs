using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faculty
{
    public partial class FormCourse : Form
    {
        public FormCourse()
        {
            InitializeComponent();
        }

  

        private void gridStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCourse.SelectedRows.Count > 0)
            {
                Course course = gridCourse.SelectedRows[0].DataBoundItem as Course;
                if (course != null)
                {
                    txt1.Text = course.Name;
                    txtCourseID.Text = course.ID.ToString();
                    txt2.Text = course.Teacher;
                    txt3.Text = course.Year.ToString();
                }
            }

        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = RetrieveCourseInformation();

                IDBManager db = new MySQLDBManager();
                db.AddCourse(course);
                EmptyControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void EmptyControls()
        {
            txtCourseID.Text = string.Empty;
            label1.Text = string.Empty;
            label2.Text = string.Empty;
            label3.Text = string.Empty;
            gridCourse.SelectedRows[0].Selected = false;
        }


 

        private Course RetrieveCourseInformation()
        {
            Course course = new Course();
            course.ID = Convert.ToInt32(txtCourseID.Text);
            course.Name = txt1.Text;
            course.Teacher = txt2.Text;
            course.Year = Convert.ToInt32(txt3.Text);
            return course;
        }

      

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                IDBManager dbManager = new MySQLDBManager();

                gridCourse.DataSource = dbManager.RetrieveCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = RetrieveCourseInformation();

                IDBManager db = new MySQLDBManager();
                db.DeleteCourse(course);
                EmptyControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = RetrieveCourseInformation();

                IDBManager db = new MySQLDBManager();
                db.UpdateCourse(course);
                EmptyControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
