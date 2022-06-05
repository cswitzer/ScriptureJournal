using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        [Key]
        public int BookID { get; set; }

        [Required, StringLength(50)]
        public string Book { get; set; }

        [Required, StringLength(20)]
        public string Chapter { get; set; }

        [Required, StringLength(20)]
        public string Verse { get; set; }

        public string Impression { get; set; }

        [DataType(DataType.Date), Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    }
}
