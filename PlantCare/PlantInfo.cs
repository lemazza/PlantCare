using System.Security;
using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PlantCare
{
        [PrimaryKey(nameof(Id))]
    public class PlantInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PlantName { get; set; }

        public string WikiURL {  get; set; }
    }
}
