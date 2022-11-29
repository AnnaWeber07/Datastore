using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PR_Lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private static List<Product> swatchProduct = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Description = "An ordinary watch",
                    Name = "Chronograph DS-8",
                    Quantity = 20
                },

                new Product
                {
                    Id = 2,
                    Description = "A luxury version",
                    Name = "Chronograph Perpetual",
                    Quantity = 2
                }
            };

        private static List<Product> rolexProduct = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Description = "An ordinary watch",
                    Name = "Oyster Perpetual",
                    Quantity = 20
                },

                new Product
                {
                    Id = 2,
                    Description = "A luxury version",
                    Name = "Gold Oyster Perpetual with diamonds",
                    Quantity = 2
                }
            };

        private static List<Company> CompanyList = new List<Company>()
        {
                new Company
                {
                     Id = 1, CompanyName = "Swatch", Address = "Switzerland, Geneve",
                     Director = "Nicholas Hayek Jr.", EmployeeNumber = 4300,
                     Revenue = 15.4, Type = "Watchmaking", shipmentRegulations = Incoterms.FCA,
                     productList = swatchProduct
                },
                new Company
                {
                     Id = 2, CompanyName = "Rolex", Address = "Switzerland, Geneve",
                     Director = "unknown", EmployeeNumber = 800,
                     Revenue = 100.4, Type = "Watchmaking", shipmentRegulations = Incoterms.FCA,
                     productList = rolexProduct
                }
        };
        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetCompanyList()
        {
            return Ok(CompanyList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Company>>> GetCompanyById(int id)
        {
            var company = CompanyList.Find(x => x.Id == id);

            if (company == null)
            {
                return BadRequest("Company not found");
            }
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<List<Company>>> AddCompany(Company company)
        {
            CompanyList.Add(company);

            return Ok(CompanyList);
        }


        [HttpPut]
        public async Task<ActionResult<List<Company>>> UpdateCompany(Company request)
        {
            var company = CompanyList.Find(x => x.Id == request.Id);

            if (company == null)
            {
                return BadRequest("Company not found");
            }

            company.CompanyName = request.CompanyName;
            company.Address = request.Address;
            company.EmployeeNumber = request.EmployeeNumber;


            return Ok(CompanyList);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Company>>> DeleteCompany(Company request)
        {
            var company = CompanyList.Find(x => x.Id == request.Id);

            if (company == null)
            {
                return BadRequest("Company not found");
            }

            CompanyList.Remove(company);
            return Ok(CompanyList);
        }

    }
}
