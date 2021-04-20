using System;
namespace TokenizerPlus
{
    

    public class SingleLineComment : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasMore() && t.peak() == '/' && t.peak(2) == '/';
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "One Line Comments";
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;

            while (t.hasMore() && t.peak() != '\n')
            {
                token.value += t.next();
            }

            return token;
        }
    }

}