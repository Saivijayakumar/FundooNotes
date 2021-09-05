//-----------------------------------------------------------------------
// <copyright file="UserContext.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes.Repository.Context
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// UserContext class
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext" /> class
        /// </summary>
        /// <param name="options">sending Object</param>
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating  the  values in table
        /// </summary>
        public DbSet<RegisterModel> Users { get; set; }
        public DbSet<NoteModel> Note { get; set; }
        public DbSet<CollaboratorModel> Collaborator { get; set; }
    }
}
