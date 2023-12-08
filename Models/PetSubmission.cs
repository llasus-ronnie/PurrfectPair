using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurrfectPair.Models
{
    // database model only
    [Table("PetSubmitAdoptionTable")]
    public class PetSubmission
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int pet_submission_id { get; set; } //id
        public string pet_name { get; set; } //name
        public int pet_age { get; set; } //age 
        public string pet_gender { get; set; } //gender
        public string pet_breed { get; set; } //breed
        public string pet_photos { get; set; } //photos
        public string pet_type { get; set; } // cat or dog   
        public bool pet_is_adopting { get; set; } // adopting or adaption
        public int UserID { get; set; }

    }
    // from form only
    public class PetSubmissionForm
    {
        public int pet_submission_id { get; set; } //id
        public string pet_name { get; set; } //name
        public int pet_age { get; set; } //age 
        public string pet_gender { get; set; } //gender
        public string pet_type { get; set; } // cat or dog   
        public string pet_breed { get; set; } //breed
        public IFormFile petPhoto { get; set; }

    }

    public class PetSubmissionModel
    {
        public int pet_submission_id { get; set; } //id
        public string pet_name { get; set; } //name
        public int pet_age { get; set; } //age 
        public string pet_gender { get; set; } //gender
        public string pet_type { get; set; } // cat or dog   
        public string pet_breed { get; set; } //breed
        public string pet_photos { get; set; } //photos
        public string pet_adopting { get; set; }
        public string pet_adoption { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

    }
}
