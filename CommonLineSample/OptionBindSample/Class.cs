using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionBindSample
{
    public class Class
    {
        /// <summary>
        /// 
        /// </summary>
        public string ClassNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Students> Students { get; set; }
    }

    public class Students
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Age { get; set; }
    }

}
