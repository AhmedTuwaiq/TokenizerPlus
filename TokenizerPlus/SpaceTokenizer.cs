using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    public class SpaceTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer tokenizer)
        {
            return tokenizer.hasNext() && Char.IsWhiteSpace(tokenizer.peek());
        }

        public override Token tokenize(Tokenizer tokenizer)
        {
            var token = new Token();
            token.value = "";
            token.type = "space";
            token.position = tokenizer.currentPos;
            token.lineNumber = tokenizer.lineNumber;

            while (tokenizer.hasNext() && Char.IsWhiteSpace(tokenizer.peek()))
            {
                token.value += tokenizer.next();
            }

            return token;
        }
    }
}
