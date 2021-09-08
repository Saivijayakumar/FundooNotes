//-----------------------------------------------------------------------
// <copyright file="ResponseModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    public class NoteUpdateModel
    {
        /// <summary>
        /// Gets or sets a value indicating  the  note id
        /// </summary>
        public int noteId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  new data
        /// </summary>
        public string newData { get; set; }
    }
}
