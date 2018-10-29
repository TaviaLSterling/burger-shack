using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SodasController : Controller
  {
    SodasRepository _repo;

    public SodasController(SodasRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<Soda> Get()
    {
      return _repo.GetAll();
    }

    [HttpPost]
    public Soda Post([FromBody] Soda soda)
    {
      if (ModelState.IsValid)
      {
        soda = new Soda(soda.Name, soda.Description, soda.Price);
        return _repo.Create(soda);
      }
      throw new Exception("INVALID SODA");
    }

  }

}