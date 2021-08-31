//-----------------------------------------------------------------------
// <copyright file="LoginModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// LoginModel class
    /// </summary>
    public class LoginModel
    {
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