namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LableModel
    {
        [Key]
        public int lableId { get; set; }
        [Required]
        public string lableName { get; set; }
        [ForeignKey("NoteModel")]
        public int? NoteId { get; set; }
        public virtual NoteModel NoteModel { get; set; }
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }

    }
}
