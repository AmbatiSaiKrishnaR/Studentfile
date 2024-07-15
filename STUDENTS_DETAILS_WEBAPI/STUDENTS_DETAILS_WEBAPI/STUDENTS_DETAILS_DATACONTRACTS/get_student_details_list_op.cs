using STUDENTS_DETAILS_DATAOBJECTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace STUDENTS_DETAILS_DATACONTRACTS
{
    public class get_student_details_list_op
    {
        public List<tbl_students_details> ml_students { get; set; }
        public get_student_details_list_op()
        {
            ml_students = new List<tbl_students_details>();
        }
    }
}
