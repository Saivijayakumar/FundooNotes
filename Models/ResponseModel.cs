//-----------------------------------------------------------------------
// <copyright file="ResponseModel.cs" company="Bridgelabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FundooNotes
{
    /// <summary>
    /// ResponseModel class
    /// </summary>
    /// <typeparam name="T">It is a generic type</typeparam>
    public class ResponseModel<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether the status code. 
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Response message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the data here
        /// </summary>
        public T Data { get; set; }
    }
}
