using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{

  public class SodasRepository
  {
    private IDbConnection _db;

    public SodasRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL BURGERS
    public IEnumerable<Soda> GetAll()
    {
      return _db.Query<Soda>("SELECT * FROM sodas;");
    }

    //GET BURGER BY ID
    public Soda GetById(int id)
    {
      return _db.Query<Soda>("SELECT * FROM sodas WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE BURGER
    public Soda Create(Soda soda)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO sodas (name, description, price)
        VALUES (@Name, @Description, @Price);
        SELECT LAST_INSERT_ID();", soda
      );
      soda.Id = id;
      return soda;
    }

    //UPDATE smoothie
    public Soda Update(Soda soda)
    {
      _db.Execute(@"
      UPDATE sodas SET (name, description, price) 
      VALUES (@Name, @Description, @Price)
      WHERE id = @Id
      ", soda);
      return soda;
    }

    //DELETE smoothie
    public Soda Delete(Soda soda)
    {
      _db.Execute("DELETE FROM smoothies WHERE id = @Id", soda);
      return soda;
    }

    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM smoothies WHERE id = @id", new { id });
    }


  }

}