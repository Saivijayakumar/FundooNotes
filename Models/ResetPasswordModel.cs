namespace Models
{
    using System.ComponentModel.DataAnnotations;
    public class ResetPasswordModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
