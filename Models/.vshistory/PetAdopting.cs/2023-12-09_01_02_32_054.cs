using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurrfectPair.Models
{
    [Table("PetAdoptingFormTable")]

    public class PetAdopting
    {
        [Key]
        public int pet_adopting_id { get; set; } //id
        public int pet_submission_id { get; set; } //id
        public int UserID { get; set; } // ung aampon ng pet
        public string? status { get; set; }
    }

    public class PetAdoptingModel
    {
        [Key]
        public int pet_adopting_id { get; set; } //id
        public int pet_submission_id { get; set; } //id
        public User UserAdopter { get; set; } // ung aampon ng pet
        public PetSubmissionForm Pet { get; set; }
        public string? status { get; set; }

    }
}
