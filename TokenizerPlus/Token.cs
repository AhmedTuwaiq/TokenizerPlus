using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    public class Token
    {
        public string type { get; set; }
        public string value { get; set; }
        public int position { get; set; }
        public int lineNumber { get; set; }

        public override string ToString()
        {
            return $"type: {this.type}, value: {this.value}, position: {this.position}, line number: {this.lineNumber}";
        }
    }
}
