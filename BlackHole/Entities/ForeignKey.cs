﻿namespace BlackHole.Entities
{
    /// <summary>
    /// Sets Foreign Key for this Column
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ForeignKey : Attribute
    {
        /// <summary>
        /// Name of the Foreign Table
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Name of the column
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// On Delete
        /// </summary>
        public string CascadeInfo { get; set; }

        /// <summary>
        /// Nullability boolean
        /// </summary>
        public bool Nullability { get; set; }

        /// <summary>
        /// This Overload of the Constructor Sets by Default the corresponding column
        /// on the Primary Table as Id. You Can choose the Primary Table and
        /// if the Foreign Key is Nullable
        /// </summary>
        /// <param name="table">Type of the parent Table</param>
        /// <param name="isNullable">Is this Column Nullable?</param>
        public ForeignKey(Type table, bool isNullable)
        {
            TableName = table.Name;
            Column = "Id";
            Nullability = isNullable;

            if (isNullable)
            {
                CascadeInfo = "on delete set null";
            }
            else
            {
                CascadeInfo = "on delete cascade";
            }
        }

        /// <summary>
        /// This Overload of the Constructor Sets by Default the corresponding column
        /// on the Primary Table as Id and makes the Foreign Key Column Nullable.
        /// You Can choose the Primary Table
        /// </summary>
        /// <param name="table">Type of the parent Table</param>
        public ForeignKey(Type table)
        {
            TableName = table.Name;
            Column = "Id";
            CascadeInfo = "on delete set null";
            Nullability = true;
        }
    }
}
