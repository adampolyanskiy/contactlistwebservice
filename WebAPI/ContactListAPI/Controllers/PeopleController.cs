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
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDbContext _context;

        public PeopleController(PeopleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetPerson()
        {
            return await _context.People.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, People person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated successful");
        }

        [HttpPost]
        public async Task<ActionResult<People>> PostPerson(People person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return Ok("Added Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return Ok("Deleted successful");
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }


        /*       [HttpGet]
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
       }*/


        /*
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
                }*/


        /*  [HttpPut]
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
  */

    }
}
