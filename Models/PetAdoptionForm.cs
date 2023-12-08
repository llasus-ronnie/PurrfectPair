using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurrfectPair.Models
{
    [Table("PetAdoptionFormTable")]
    public class PetAdoptionForm
    {
        [Key]
        public int pet_adoption_id { get; set; }
        public int UserID { get; set; }
        public int pet_submission_id { get; set; } //id
        public string pet_adoption_status { get; set; }
    }
}
