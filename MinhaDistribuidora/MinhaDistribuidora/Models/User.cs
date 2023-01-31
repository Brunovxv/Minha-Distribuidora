﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDistribuidora.Models
{
    [Table("users")]
    public class User
    {
        internal DateTime RefreshTokenExpiryTime;

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTipe { get; set; }


    }
}
