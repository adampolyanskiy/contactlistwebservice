using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using CsvHelper;
using System.Globalization;
using ContactListAPI.Models;

namespace ContactListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVController : Controller
    {
        private readonly PeopleDbContext _context;

        public CSVController(PeopleDbContext context)
        {
            _context = context;
        }


        [HttpPost, Consumes("multipart/form-data")]

        public async Task<ActionResult<People>> ImportRoute([FromForm (Name = "file")] IFormFile file)
        {

            if (file.Length == 0) return BadRequest();

            StreamReader streamReader = new StreamReader(file.OpenReadStream());

            dynamic records;

            using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture)) 
            {
                records = csv.GetRecords<dynamic>();
             
                foreach (var person in records)
                {
                    try
                    {
                        People dbPerson = new People()
                        {
                            PersonId = 0,
                            PersonFirstName = person.PersonFirstName,
                            PersonLastName = person.PersonLastName,
                            PersonMiddleName = person.PersonMiddleName,
                            PersonPhoneNumber = person.PersonPhoneNumber,
                            PersonAdress = person.PersonAdress
                        };
                        _context.People.Add(dbPerson);
                    }

                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }

                await _context.SaveChangesAsync();
                return Ok("Recieved successfuly.");
            }
        }

        [HttpGet, Produces("text/csv")]

        public IActionResult ExportRoute()
        {
            People[] people = _context.People.ToArray();
            var stream = new MemoryStream();
            using (var writeFile = new StreamWriter(stream, leaveOpen: true))
            {
                var csv = new CsvWriter(writeFile, CultureInfo.InvariantCulture);
                csv.WriteRecords(people);
            }
            stream.Position = 0;
            return File(stream, "text/csv", "contact_list.csv");
        }
    }
}
