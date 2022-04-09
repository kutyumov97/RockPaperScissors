namespace RockPaperScissors
{
    internal class Table
    {
        public void CreateTable(string[] arg)
        {
            Console.Write("{0, -20}", "");
            foreach (var el in arg)
                Console.Write("{0, -20}", el);
            Console.WriteLine();

            for (int i = 0; i < arg.Length; i++)
            {
                Console.Write("{0, -20}", arg[i]);

                for (int j = 0; j < arg.Length; j++)
                {
                    Rules rules = new();
                    string res = rules.WhoWin(arg, i, j);

                    Console.Write("{0, -20}", res);
                }
                Console.WriteLine();
            }
        }
    }
}
