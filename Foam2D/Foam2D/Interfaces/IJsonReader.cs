using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2D.Interfaces
{
    interface IJsonReader
    {
        /// <summary>
        /// Check if the json data is null or not returning boolean
        /// </summary>
        public static bool IsNull { get; set; }

        /// <summary>
        /// Check if the json is loaded or not
        /// </summary>
        private static bool PathSetted { get; set; }

        /// <summary>
        /// Json Path Must be Provided First
        /// </summary>
        private static string? Json_Path;

    }
}
