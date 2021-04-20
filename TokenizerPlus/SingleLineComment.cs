using System;
namespace TokenizerPlus
{
    

    public class SingleLineComment : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasNext() && t.peek() == '/' && t.peek(2) == '/';
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "One Line Comments";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;

            while (t.hasNext() && t.peek() != '\n')
            {
                token.value += t.next();
            }

            return token;
        }
    }

}