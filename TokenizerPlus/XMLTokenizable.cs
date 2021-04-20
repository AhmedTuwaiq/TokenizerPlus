using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
  

    public class XMLTokenizable : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return (t.hasNext() && t.peek() == '<');
        }
        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "open tag xml";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;

            token.value += t.next();
            while (t.hasNext() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '>' || t.peek() == '/'))
            {
                if (t.peek() == '/')
                {
                    if (token.value == "<")
                    {
                        token.type = "close tag xml";
                    }
                    else
                    {
                        return null;
                    }

                }
                token.value += t.next();

                if (t.peek() == '>')
                {
                    token.value += t.next();
                    break;
                }
            }
            return token;
        }
    }
}
