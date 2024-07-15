using STUDENTS_DETAILS_DATAOBJECTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace STUDENTS_DETAILS_DATACONTRACTS
{
    public class put_student_detail_ip
    {
       
        [DataMember]
        public tbl_students_details m_student { get; set; }
        public put_student_detail_ip()
        {
            m_student = new tbl_students_details();
        }

    }
}
