using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRM.Core.Models
{
    public class SerilogSettings
    {
        public string FilePath { get; set; }
        public string Table { get; set; }
        public string ConnectionStrings { get; set; }
        public string FullFilePath => $"{AppContext.BaseDirectory}{FilePath}";
    }
}
