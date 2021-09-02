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
using System.Text;

namespace Models
{
    public class NoteModel
    {
        [Key]
        public int NoteId { get; set; }
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RegisterModel RegisterModel { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool Pin { get; set; }
        public string RemindMe { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        [DefaultValue(false)]
        public bool Archieve { get; set; }
        [DefaultValue(false)]
        public bool Trash { get; set; }
    }
}
