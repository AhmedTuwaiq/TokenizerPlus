using System;

namespace TokenizerPlus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start of processing");
            Tokenizer t = new Tokenizer("#vjdnkd 20 20.12f hhh aaaf 19 if  _jdc_nkjd  20f @Abdulrahman <to> hhh  </to> jjj ");
            Tokenizable[] handers = new Tokenizable[] {
                new StringTokenizer(),
                new SpaceTokenizer(),
                new IdTokenizer(),
                new IntOrfloatTokenizer(),
                new XMLTokenizable(),
                new UserTokenizable(),
                new HashTokenizable()
            };
            Token token = t.tokenize(handers);

            while (token != null)
            {
                Console.WriteLine(token);
                token = t.tokenize(handers);
            }

            Console.WriteLine("End of processing");
        }
    }
}
