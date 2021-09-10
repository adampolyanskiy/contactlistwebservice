using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using ContactListAPI.Models;

namespace ContactListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PeopleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select PersonId, PersonFirstName, PersonMiddleName, PersonLastName, PersonPhoneNumber, PersonAdress  from dbo.People";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactListAppCon");
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

            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(People person)
        {

            string query = @"
                    insert into dbo.People 
                    (PersonFirstName,PersonMiddleName,PersonLastName,PersonPhoneNumber, PersonAdress)
                    values 
                    (
                    '" + person.PersonFirstName + @"'
                    ,'" + person.PersonMiddleName + @"'
                    ,'" + person.PersonLastName + @"'
                    ,'" + person.PersonPhoneNumber + @"'
                    ,'" + person.PersonAdress + @"'
                    )
                    ";



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactListAppCon");
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


        [HttpPut]
        public JsonResult Put(People person)
        {
            string query = @"
                    update dbo.People set 
                    PersonFirstName = '" + person.PersonFirstName + @"'
                    ,PersonMiddleName = '" + person.PersonMiddleName + @"'
                    ,PersonLastName = '" + person.PersonLastName + @"'
                    ,PersonPhoneNumber = '" + person.PersonPhoneNumber + @"'
                    ,PersonAdress = '" + person.PersonAdress + @"'
                    where PersonId = " + person.PersonId + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactListAppCon");
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

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.People
                    where PersonId = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactListAppCon");
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

            return new JsonResult("Deleted Successfully");
        }


    }
}
