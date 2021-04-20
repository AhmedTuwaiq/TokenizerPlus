using System;

namespace TokenizerPlus
{
    

    public class LogicalOperator : Tokenizable
    {

        int OpLen = 0;
        string[] operators = { "!", "&&", "||" };

        public bool isOperator(Tokenizer t)
        {
            string isThereMore = "";
            foreach (var op in operators)
            {
                isThereMore = "";
                int i = 1;
                while (i <= op.Length)
                    isThereMore += t.peek(i++);
                OpLen = op.Length;
                if (isThereMore == op) return true;

            }
            return false;
        }
        public override bool tokenizable(Tokenizer t)
        {
            return t.hasNext() && isOperator(t);
        }

        public override Token tokenize(Tokenizer t)
        {
            Token token = new Token();
            token.value = "";
            token.type = "logical operator";
            token.position = t.currentPos;
            token.lineNumber = t.lineNumber;

            // int i = 0;
            while (t.hasNext() && OpLen > 0)
            {
                token.value += t.next();
                OpLen--;
            }


            return token;
        }

    }

}