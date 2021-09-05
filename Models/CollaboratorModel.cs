namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CollaboratorModel
    {
        [Key]
        public int collaboratorId { get; set; }
        [ForeignKey("NoteModel")]
        public int NoteId { get; set; }
        public virtual NoteModel NoteModel { get; set; }
        [Required]
        public string collaboratorEmail { get; set; }
    }
}
