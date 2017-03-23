using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faculty;

namespace UnitTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void AddStudent()
        {

            MySQLDBManager op = new MySQLDBManager();
            Student student = new Student(21, "Alexandra", new System.DateTime(1995, 10, 27), "Cluj");
            bool rez = op.AddTest(student);
            Assert.IsTrue(rez);

        }

        [TestMethod]
        public void DeleteStudent()
        {

            MySQLDBManager op = new MySQLDBManager();
            Student student = new Student(21, "Alexandra", new System.DateTime(1995, 10, 27), "Cluj");
            bool rez = op.DeleteTest(student);
            Assert.IsTrue(rez);

        }

        [TestMethod]
        public void UpdateStudent()
        {

            MySQLDBManager op = new MySQLDBManager();
            Student student = new Student(20, "Ale", new System.DateTime(1995, 10, 27), "Cluj");
            bool rez = op.UpdateTest(student);
            Assert.IsTrue(rez);

        }

    }
}
