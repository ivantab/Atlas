using System;
using System.Collections.Generic;

#nullable disable

namespace Users.Services.Query.Dtos
{
    public partial class UserDto
    {
        public int IdUser { get; set; }
        public string LoginName { get; set; }
        public byte[] Password { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhotoId { get; set; }
        public bool? Status { get; set; }
        public int Kind { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public DateTime Birth { get; set; }
    }
}
