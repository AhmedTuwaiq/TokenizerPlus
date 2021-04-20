using System;

namespace TokenizerPlus
{
    

    public class RelationalOperator : Tokenizable
    {

        int OpLen = 0;
        const int maxLen = 2;
        string[] operators = { ">", "<", "<=", "==", ">=" };

        public bool isOperator(Tokenizer t)
        {
            string isThereMore = "";
            string collector = "";
            int i = 0;
                while (i < maxLen)
                {
                    collector += t.peak(i+1);
                    foreach (var op in operators)
                    {
                        if( collector == op )
                        {
                            isThereMore = collector;
                        }
                    }
                    i++;
                }
            foreach (var op in operators)
            {
                OpLen = op.Length;
                if (isThereMore == op) return true;
            }
            return false;
        }

        public override bool tokenizable(Tokenizer t)
        {
            return t.hasMore() && isOperator(t);
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "Relational operator";
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;

            while (t.hasMore() && OpLen > 0)
            {
                token.value += t.next();
                OpLen--;
            }

            return token;
        }
    }

}