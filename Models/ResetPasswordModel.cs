//-----------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ResetPasswordModel class
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Gets or sets a value indicating  the  Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  NewPassword
        /// </summary>
        [Required]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating  the  ConfirmNewPassword
        /// </summary>
        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
