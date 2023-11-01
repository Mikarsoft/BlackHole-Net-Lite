using BlackHole.CoreSupport;
using BlackHole.Entities;

namespace BlackHole.Core
{
    /// <summary>
    /// A class that can create Inner Joins that can be
    /// stored as Views and then called at any point from the
    /// Data Provider
    /// </summary>
    public class BHViewInitializer
    {
        /// <summary>
        /// Starts an Inner Join Between two Entities which can 
        /// extend with additional joins.
        /// </summary>
        /// <typeparam name="T">BlackHoleEntity</typeparam>
        /// <typeparam name="TOther">Second BlackHoleEntity</typeparam>
        /// <returns>PrejoinData</returns>
        public PreJoinsData<T, TOther> Join<T, TOther>()
            where T : BlackHoleEntity where TOther : BlackHoleEntity
        {
            return new PreJoinsData<T, TOther>();
        }
    }
}
