using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    class IdTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return (t.hasNext() && (Char.IsLetter(t.peek()) || t.peek() == '_'));
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "id";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;

            while (t.hasNext() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '_'))
            {
                token.value += t.next();
            }

            return token;
        }
    }
}
