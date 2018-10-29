using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace burgershack.Models
{
    public class User
    {
        public class UserLogin // HELPER MODEL
        {
            [EmailAddress]
            [Required]
            public string Email { get; set; }
            [Required]
            [MinLength(6)]
            public string Password { get; set; }
        }
        public class UserRegistration // HELPER MODEL
        {
            [Required]
            public string Username { get; set; }

            [EmailAddress]
            [Required]
            public string Email { get; set; }
            [Required]
            [MinLength(6)]
            public string Password { get; set; }
        }


        public class UserData // HELPER MODEL
        {
            [EmailAddress]
            [Required]
            public string Email { get; set; }
            [Required]
            [MinLength(6)]
            public string Password { get; set; }
            internal string Hash { get; set; }
            public string Id { get; set; }
            public bool Active { get; set; } = true;
            public string Username { get; set; }

        }
        public ClaimsPrincipal _principal { get; set; }
        internal void SetClaims()
        {
            var claims = new List<Claim>()
         {
             new Claim(ClaimTypes.Email, Email),
             new Claim(ClaimTypes.Name, Id)

         };
         var userIdentity = new ClaimsIdentity(claims, "Login");
         _principal = new ClaimsPrincipal(userIdentity);
        }
    }
}