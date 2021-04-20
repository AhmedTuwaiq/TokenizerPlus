using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
  
    public class IntOrfloatTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasNext() && Char.IsDigit(t.peek());
        }
        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            int count = 0;

            token.value = "";
            token.type = "Integer";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;

            while (t.hasNext() && (char.IsDigit(t.peek()) || t.peek() == '.' || t.peek() == 'f'))
            {

                if (t.peek() == '.' || t.peek() == 'f')
                {
                    token.type = "float";
                    count++;
                    if (count == 3)
                    {
                        return null;
                    }
                }

                if (t.peek() == 'f')
                {
                    if (t.peek(2) != ' ')
                    {
                        return null;
                    }
                }

                token.value += t.next();

            }
            Char lastchar = token.value[token.value.Length - 1];
            if (lastchar != 'f' && token.type == "float")
            {
                token.value += 'f';
            }

            return token;
        }
    }
}
