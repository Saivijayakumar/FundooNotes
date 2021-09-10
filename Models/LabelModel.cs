//-----------------------------------------------------------------------
// <copyright file="LabelModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// LabelModel class used for table creation
    /// </summary>
    public class LabelModel
    {
        /// <summary>
        /// Gets or sets a value indicating  the  label id
        /// </summary>
        [Key]
        public int LabelId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  label name
        /// </summary>
        [Required]
        public string LabelName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  note id
        /// </summary>
        [ForeignKey("NoteModel")]
        public int? NoteId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  reference to note table
        /// </summary>
        public virtual NoteModel NoteModel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  user id
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  reference to register
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }
    }
}
