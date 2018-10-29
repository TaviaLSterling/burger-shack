using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories 
{
    public class BurgersRepository
    {
        // private string tableName = "burgers";
        private IDbConnection _db;
        public BurgersRepository(IDbConnection db)
        {
            _db = db;
        }
// CRUD via SQL
//Get all burgers
public IEnumerable<Burger> GetAll()
{
return _db.Query<Burger>("SELECT * FROM burgers;");
}

//Get burger by ID
public Burger GetById(int id)
{
    return _db.Query<Burger>("SELECT * FROM burgers WHERE id = @id;", new { id }).FirstOrDefault();
}

//Create burger
public Burger Create(Burger burger)
{
    int id = _db.ExecuteScalar<int>(@"
    INSERT INTO burgers (name, description, price)
    VALUES (@Name, @Description, @Price);
    SELECT LAST_INSERT_ID();", burger
    );
    burger.Id = id;
    return burger;
}
//Update burger
  public Burger Update(Burger burger)
        {
            //DO NOT FORGET TO SPECIFY WHICH BURGER
            _db.Execute(@"UPDATE burgers 
            SET name = @Name, description = @Description, price = @Price
            WHERE id = @Id;", burger);
            return burger;
        }
// public Burger Update(Burger burger)
// {
//     _db.Execute("UPDATE burgers SET (name, description, price) VALUES (@Name, @Description, @Price) WHERE id = @Id", burger);
//     return burger;
// }

//Delete burger
public Burger Delete(Burger burger)
{
    _db.Execute("DELETE FROM burgers WHERE id = @Id", burger);
    return burger;
}
public IEnumerable<Burger> GetBurgersByUserId(string Id)
{
    _db.Query<Burger>(@"
    SELECT * FROM userburgers
    INNER JOIN burgers ON burgers.id = userburgers.burgerId
    WHERE userId = @id
    
    ", new {Id});
}
    }
}