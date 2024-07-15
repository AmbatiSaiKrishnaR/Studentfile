
using STUDENTS_DETAILS_DATACONTRACTS;
using STUDENTS_DETAILS_DATAOBJECTS;
using STUDENTS_DETAILS_BL;

using Microsoft.AspNetCore.Mvc;

using System.Data;

namespace STUDENTS_DETAILS_WEBAPI.Controllers

{
    
    [Route("[controller]")]
    [ApiController]

    public class DashboardController : ControllerBase
    {

        private readonly IConfiguration Configuration;

        public DashboardController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
     
        [HttpGet]
        [Route("get_StudentsList")]
        public JsonResult get_Students_List()
        {
            String connectionString = Configuration["DBConnection"];

            get_student_details_list_ip ip = new get_student_details_list_ip();
            get_student_details_list_op op = new get_student_details_list_op();

            students_details_bl bl = new students_details_bl();

            bl.get_Students_List(ref ip, ref op, connectionString);

            return new JsonResult(op);
        }


        [HttpGet]
        [Route("get_Students_Detail")]
        public JsonResult get_Students_Detail(String Id)
        {
            String connectionString = Configuration["DBConnection"];

            get_student_detail_ip ip = new get_student_detail_ip();
            ip.m_ID = Convert.ToInt64(Id);
            get_student_detail_op op = new get_student_detail_op();

            students_details_bl bl = new students_details_bl();

            bl.get_Students_Detail(ref ip, ref op, connectionString);

            return new JsonResult(op);
        }

        [HttpPost]
        [Route("put_add_students")]
        public JsonResult put_Students_Detail(put_student_detail_ip ip)
        {
            String connectionString = Configuration["DBConnection"];
            put_student_detail_op op = new put_student_detail_op();

            students_details_bl bl = new students_details_bl();

            bl.put_Students_Detail(ref ip, ref op, connectionString);
            return new JsonResult(op);
        }
    }
}