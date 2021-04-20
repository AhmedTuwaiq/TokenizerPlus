using System;
namespace TokenizerPlus
{
    

    public class MultiLineComment : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasNext() && t.peek() == '/' && t.peek(2) == '*';
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "Multi Line Comments";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;

            while (t.hasNext() && (t.peek() != '*' || t.peek(2) != '/'))
            {
                token.value += t.next();
            }
            token.value += "*/";

            return token;
        }
    }

}