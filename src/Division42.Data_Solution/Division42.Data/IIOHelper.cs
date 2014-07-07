using System;
using System.Threading.Tasks;

namespace Division42.Data
{
    /// <summary>
    /// Interface for platform-specific I/O operations.
    /// </summary>
    public interface IIOHelper
    {
        /// <summary>
        /// Creates an empty (0-byte) file.
        /// </summary>
        /// <param name="pathAndFileName">The path and file name to create.</param>
        /// <exception cref="ArgumentException"></exception>
        void CreateEmptyFile(String pathAndFileName);

        /// <summary>
        /// Verifies that a folder exists.
        /// </summary>
        /// <param name="pathAndFileName">The path to validate exists; can include file name.</param>
        /// <exception cref="ArgumentException"></exception>
        Task<Boolean> VerifyFolderExists(String pathAndFileName);

        /// <summary>
        /// Verifies that a file exists.
        /// </summary>
        /// <param name="pathAndFileName">The path and filename to validate exists.</param>
        /// <exception cref="ArgumentException"></exception>
        Task<Boolean> VerifyFileExists(String pathAndFileName);
    }
}
