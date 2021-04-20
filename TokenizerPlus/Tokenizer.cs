using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerPlus
{
    public class Tokenizer
    {
        public string input;
        public int currentPos;
        public int lineNumber;

        public Tokenizer(string input)
        {
            this.input = input;
            this.currentPos = -1;
            this.lineNumber = 1;
        }

        public Token tokenize(Tokenizable[] handlers)
        {
            foreach (var t in handlers)
            {
                if (t.tokenizable(this))
                {
                    return t.tokenize(this);
                }
            }

            return null;
        }

        public char peek(int numOfposition = 1)
        {
            if (this.hasNext())
            {
                return this.input[this.currentPos + numOfposition];
            }
            else
            {
                return '\0';
            }
        }

        public char next()
        {
            char currentChar = this.input[++this.currentPos];
            if (currentPos == '\n')
            {
                this.lineNumber++;
            }
            return currentChar;
        }

        public bool hasNext() { return (this.currentPos + 1) < this.input.Length; }
    }
}
