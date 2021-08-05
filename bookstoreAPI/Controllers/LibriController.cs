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
    public class LibriController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LibriController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select * from libri";
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
        public JsonResult Post(Libri user)
        {
            string query = @"
                        insert into libri values ('"+user.libriImage +@"','" + user.titulli + @"','" + user.isbn + @"','" + user.nr_faqev + @"','" + user.price + @"','" + user.autoriID + @"')
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
        public JsonResult Put(Libri user)
        {
            string query = @"
                        update libri set 
                        libriID = '" + user.libriID + @"',
                        libriImage = '" + user.libriImage + @"',
                        titulli = '" + user.titulli + @"',
                        isbn = '" + user.isbn + @"',
                        nr_faqev = '" + user.nr_faqev + @"',
                        price = '" + user.price + @"',
                        autoriID = '" + user.autoriID + @"'
                        where isbn=" + user.isbn + @"
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
                        delete from libri
                        where isbn = " + id + @"
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
            return new JsonResult("Deleted Successfuly");
        }
    }
}
