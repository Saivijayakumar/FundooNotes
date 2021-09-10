//-----------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// CollaboratorModel class used for table creation
    /// </summary>
    public class CollaboratorModel
    {
        /// <summary>
        /// Gets or sets a value indicating  the  collaborator id
        /// </summary>
        [Key]
        public int collaboratorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  note id
        /// </summary>
        [ForeignKey("NoteModel")]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  reference of note model
        /// </summary>
        public virtual NoteModel NoteModel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  collaborator Email
        /// </summary>
        [Required]
        public string collaboratorEmail { get; set; }
    }
}
