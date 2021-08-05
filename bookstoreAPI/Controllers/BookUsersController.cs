using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using bookstoreAPI.models;
using Microsoft.Extensions.Configuration;

namespace bookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookUsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BookUsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select * from dbo.bookstoreDB";
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
        public JsonResult Post(BookUsers user)
        {
            string query = @"
                        insert into dbo.bookstoreDB values ('" + user.firstName + @" ','" + user.lastName + @" ','" + user.userName + @" ','" + user.email + @"','" + user.passwordi + @"','" + user.user_role + @"')
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
        public JsonResult Put(BookUsers user)
        {
            string query = @"
                        update dbo.Department set 
                        firstName = '" + user.firstName+ @"'
                        lastName = '" + user.lastName + @"'
                        userName = '" + user.userName + @"'
                        email = '" + user.email + @"'
                        password = '" + user.userName + @"'
                        userRole = '" + user.user_role + @"'
                        where usersID=" + user.usersID + @"
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
                        delete from dbo.bookstoreDB
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

