using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    public class BractsTokenizer : Tokenizable
    {
        private string bracts = "([{}])";
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasNext() && bracts.Contains(t.peek().ToString());
        }
        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.type = "Bracts";
            token.value = "";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;
            token.value += t.next();
            return token;
        }
    }

}
