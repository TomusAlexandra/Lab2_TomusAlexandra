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
    public partial class FormEnroll : Form
    {
        public FormEnroll()
        {
            InitializeComponent();
        }


        private void EmptyControls()
        {
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            txt3.Text = string.Empty;
            
        }

        private Enroll RetrieveStudentInformation()
        {
            Enroll enroll = new Enroll();
            enroll.ID = Convert.ToInt32(txt1.Text);
            enroll.IdStudent = Convert.ToInt32(txt2.Text);
            enroll.IdCourse = Convert.ToInt32(txt3.Text);
            return enroll;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                Enroll enroll = RetrieveStudentInformation();

                MySQLDBManager db = new MySQLDBManager();
                db.EnrollStudent(enroll);
                EmptyControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
