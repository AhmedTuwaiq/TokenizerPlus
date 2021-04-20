using System;
namespace TokenizerPlus
{
    

    public class MultiLineComment : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasMore() && t.peak() == '/' && t.peak(2) == '*';
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "Multi Line Comments";
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;

            while (t.hasMore() && (t.peak() != '*' || t.peak(2) != '/'))
            {
                token.value += t.next();
            }
            token.value += "*/";

            return token;
        }
    }

}