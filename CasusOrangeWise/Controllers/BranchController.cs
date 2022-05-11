using CasusOrangeWise.Data;
using CasusOrangeWise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasusOrangeWise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ShoppingContext _context;

        public BranchController(ShoppingContext context)
        {
            _context = context;
        }

        //Create/Edit
        //Er wordt een check gedaan op de database of de vestiging al bestaat
        //Bestaat de vestiging wordt deze melding teruggegeven
        //Bestaat de vestiging nog niet dan wordt er een object aangemaakt
        //Bestaat de Id van de vestiging al dan worden de gegevens aangepast

        [HttpPost]
        public JsonResult CreateEdit(Branch branch)
        {
            var existing = _context.Branches.Where(b => b.Adress == branch.Adress && b.Name == branch.Name);

            if (branch.Id == 0)
            {
                if (existing.Any())
                {
                    return new JsonResult("Vestiging bestaat al");
                }
                _context.Branches.Add(branch);
            }
            else
            {
                var branchDb = _context.Branches.Find(branch.Id);

                if (branchDb == null)
                    return new JsonResult(NotFound());

                branchDb = branch;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(branch));
        }

        //Get
        //Met parameter Id
        //Wordt de Id niet gevonden dan krijg je een NotFound terug
        //Wordt de Id wel gevonden dan krijg je het resultaat terug
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _context.Branches.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        //Met parameter Id
        //Wordt de Id niet gevonden dan krijg je een NotFound terug
        //Wordt de Id wel gevonden dan wordt het record verwijderd, wijzigingen opgeslagen en een NoContent krijg je terug
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _context.Branches.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Branches.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());

        }
    }
}
