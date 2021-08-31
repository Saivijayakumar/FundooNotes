//-----------------------------------------------------------------------
// <copyright file="RegisterModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// RegisterModel class
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets a value indicating  the  UserId
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  FirstName
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  LastName
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
