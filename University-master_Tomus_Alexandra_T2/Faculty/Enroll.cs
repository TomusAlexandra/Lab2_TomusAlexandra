using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Faculty
{
    public class Enroll
    {
        private int v1;
        private int v2;
        private int v3;

        public Enroll(int v1, int v2, int v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Enroll()
        {
        }

        public int ID { get; set; }
        public int IdStudent { get; set; }
        public int IdCourse { get; set; }


    }
}
