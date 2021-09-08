//-----------------------------------------------------------------------
// <copyright file="NoteModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Note model class used for table creation
    /// </summary>
    public class NoteModel
    {
        /// <summary>
        /// Gets or sets a value indicating  the  note id
        /// </summary>
        [Key]
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  user id
        /// </summary>
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  reference to user table
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  pin
        /// </summary>
        [DefaultValue(false)]
        public bool Pin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  remindme
        /// </summary>
        public string RemindMe { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  Archive
        /// </summary>
        [DefaultValue(false)]
        public bool Archieve { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  trash
        /// </summary>
        [DefaultValue(false)]
        public bool Trash { get; set; }
    }
}
