using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Guysdata.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Guysdata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserinfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public UserinfoController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        //เพิ่มข้อมูลจากDatabaseสำหรับ api/userinfo
        [HttpPost]
        public JsonResult Post(Userinfo userinfo)
        {
            //query สำหรับสร้างหรือเก็บข้อมูลจากDatabaseสำหรับ api/userinfo
            //emu479p1 :guysplatformapi/userinfo/post
            string query = @"
                    insert into dbo.UserInfo(ID, Firstname, Lastname, Birthdate, Tel, Email) values
                    ('" + userinfo.ID + @"',
                     '" + userinfo.Firstname + @"',
                     '" + userinfo.Lastname + @"',
                     '" + userinfo.Birthdate + @"',
                     '" + userinfo.Tel + @"',
                     '" + userinfo.Email + @"')
                       ";
            DataTable table = new DataTable();
            //เชื่อมต่อกับฐานข้อมูล
            //emu479p1 :guysplatformapi/userinfo/post
            string sqlDataSource = "Server=tcp:guysdevops.database.windows.net,1433;Initial Catalog=GuysDevOps;Persist Security Info=False;User ID=guysdevops;Password=guys.1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
    }
}
