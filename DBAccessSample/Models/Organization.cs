using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBAccessSample.Models
{
    /// <summary>
    /// 組織
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// 組織ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 組織名
        /// </summary>
        public string Name { get; set; }
    }
}
