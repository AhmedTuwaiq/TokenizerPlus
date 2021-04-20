using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    

    public class HashTokenizable : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return (t.hasNext() && t.peek() == '#');
        }
        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "Hash";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;

            token.value += t.next();
            while (t.hasNext() && (Char.IsLetterOrDigit(t.peek())))
            {
                token.value += t.next();
            }

            return token;
        }
    }
}
