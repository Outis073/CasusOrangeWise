using CasusOrangeWise.Data;
using CasusOrangeWise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CasusOrangeWise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingSundayController : ControllerBase
    {
        private readonly ShoppingContext _context;

        public ShoppingSundayController(ShoppingContext context)
        {
            _context = context;
        }

        //Create/Edit

        [HttpPost]
        public JsonResult CreateEdit(ShoppingSunday sunday)
        {          
           
           var existing = _context.shoppingSundays.Where(s => s.Branch == sunday.Branch && s.BeginTime.Date == sunday.BeginTime.Date);
            

            if(sunday.Id == 0)
            {
                
                if(existing.Any())
                {
                    return new JsonResult("Kan geen meerdere koopzondagen op één dag hebben");
                }

                    _context.shoppingSundays.Add(sunday);
                
            }
            else
            {
                var sundayDb = _context.shoppingSundays.Find(sunday.Id);

                if (sundayDb == null)
                    return new JsonResult(NotFound());

                sundayDb = sunday;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(sunday));
        }

        //Get
        //Met parameter Id
        //Wordt de Id niet gevonden dan krijg je een NotFound terug
        //Wordt de Id wel gevonden dan krijg je het resultaat terug
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _context.shoppingSundays.Find(id);

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
            var result = _context.shoppingSundays.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.shoppingSundays.Remove(result);
            _context.SaveChanges();
            
            return new JsonResult(NoContent());

        }

    }
}
