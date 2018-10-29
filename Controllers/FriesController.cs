using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FriesController : Controller
  {
    List<Fry> fries;
    public FriesController()
    {
      fries = new List<Fry>();
    }

    [HttpGet]
    public IEnumerable<Fry> Get()
    {
      return fries;
    }

    [HttpPost]
    public Fry Post([FromBody] Fry fry)
    {
      fries.Add(fry);
      return fry;
    }

  }

}