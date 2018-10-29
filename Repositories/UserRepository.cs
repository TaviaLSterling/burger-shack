using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using burgershack.Models;
using Dapper;
using static burgershack.Models.User;

namespace burgershack.Repositories {
    public class UserRepository
    {
            IDbConnection _db;
            // SaltRevision SALT = SaltRevision.Revision2X;
        //Register C
        public User Register(UserRegistration creds)
        {
            //generate user id
            //Hash the password

        string hash = BCrypt.Net.BCrypt.HashPassword(creds.Password, SaltRevision.Revision2X);
        string id = Guid.NewGuid().ToString();
        _db.ExecuteScalar("");
       int success =  _db.Execute(@"
        INSERT INTO users (id, username, email, hash)
        VALUES (@id, @username, @email, @hash);
        ", new {
            id,
            username = creds.Username,
            email = creds.Email,
            hash
             });
             if(success != 1) {return null;}
             {
                 return new UserData()
                 {
                     Username = creds.Username,
                     Email = creds.Email,
                     Hash = null,
                     Id = id
                 };
             }
        }
        //Login R
        public User Login(UserLogin creds)
        {
            // var hash = BCrypt.Net.BCrypt.HashPassword(creds.Password, SALT);
            User user = _db.Query<User>(@"
            SELECT * FROM users WHERE email = @Email
            ", creds).FirstOrDefault();
            if(user == null) {return null;}
            bool validPass = BCrypt.Net.BCrypt.Verify(creds.Password, user.Hash);
            if (!validPass) {return null;}
            user.Hash = null;
            return user;
        }

        internal User GetUserById(string id)
        {
           _db.Query<User>(@"
           SELECT * from users WHERE id = @id
           ", new { id }).FirstOrDefault();
           if(User != null)
           {
               user.Hash = null;
           }
        }

        //Update U
        //Change Password U
        //Delete D



        public UserRepository(IDbConnection db)
        {
           _db = db; 
        }
    }











}