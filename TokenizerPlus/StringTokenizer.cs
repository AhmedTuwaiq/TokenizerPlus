using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    public class StringTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer tokenizer)
        {
            if (tokenizer.currentPos == -1)
            {
                return tokenizer.hasNext() && tokenizer.peek() == '"';
            }
            else
            {
                return tokenizer.hasNext() && tokenizer.peek() == '"' && tokenizer.peek(-1) != '\\';
            }
        }

        public override Token tokenize(Tokenizer tokenizer)
        {
            var token = new Token();
            token.value = "";
            token.type = "string";
            token.position = tokenizer.currentPos + 1;
            token.lineNumber = tokenizer.lineNumber;

            while (tokenizer.hasNext())
            {
                char ch = tokenizer.next();
                token.value += ch;

                if (token.value.Length > 1 && ch == '"')
                    break;
            }

            if (token.value.Length < 2)
            {
                tokenizer.currentPos = token.position - 1;
                return null;
            }

            char ch1 = token.value[token.value.Length - 1], ch2 = token.value[token.value.Length - 2];

            if(ch1 == '"' && ch2 != '\\')
            {
                return token;
            }
            else
            {
                tokenizer.currentPos = token.position - 1;
                return null;
            }
        }
    }
}
