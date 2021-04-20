using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    public class HexTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasNext() && t.peek() == '#';
        }
        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.type = "Hex";
            token.value = "";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;
            string hexallow = "abcdef123456789";
            if (t.peek() == '#')
            {
                token.value += t.next();
                while ((t.hasNext() && hexallow.Contains(t.peek().ToString())) && token.value.Length < 7)
                {
                    token.value += t.next();
                }
            }
            if (token.value.Length < 7)
            {
                for (int i = 0; token.value.Length != 7; i++)
                {
                    token.value += '0';
                }
            }
            return token;
        }
    }
}
