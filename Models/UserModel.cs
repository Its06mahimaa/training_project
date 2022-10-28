using Google.Apis.Admin.Directory.directory_v1.Data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace trainingproject.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
   
        public string Mobile { get; set; } 

        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; } 

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Hobbies { get; set; } 

        [Required]
        public IFormFile Profile_pic { get; set; }
        [JsonIgnore]
        public int RoleId { get; set; }


    }
    public class UserD
    {
     
        public string Login { get; set; }

        public string Password { get; set; }

    }
  
}

