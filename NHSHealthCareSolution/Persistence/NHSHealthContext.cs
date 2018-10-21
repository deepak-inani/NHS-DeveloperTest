using System.Data.Entity;

namespace NHSHealthCareSolution.Persistence
{
    /// <summary>
    /// NHS Database connection.
    /// </summary>
    public class NHSHealthContext : DbContext
    {
        /// <summary>
        /// Constructuor : passing default connection string from web.config.
        /// </summary>
        public NHSHealthContext() : base("name=NHSHealthContext")
        {

        }

        /// <summary>
        /// Get Patients data.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

    }
}