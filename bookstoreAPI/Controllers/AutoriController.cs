using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using bookstoreAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoriController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AutoriController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select * from dbo.autori";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookstoreCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }

            }
            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Autori user)
        {
            string query = @"
                        insert into dbo.autori values ('" + user.autoriID + @",'" + user.autori_name + @"')
                        ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookstoreCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }

            }
            return new JsonResult("Added Successfuly");
        }


        [HttpPut]
        public JsonResult Put(Autori user)
        {
            string query = @"
                        update dbo.autori set 
                        autoriID = '" + user.autoriID + @"'
                        autori_name = '" + user.autori_name + @"'
                        where usersID=" + user.autoriID + @"
                        ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BookstoreCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }

            }
            return new JsonResult("Updated Successfuly");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from dbo.autori
                        where usersID = " + id + @"
                        ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }

            }
            return new JsonResult("Deleted Successfuly");
        }
    }
}

