namespace RockPaperScissors
{
class Program
{   
    public static void Main(string[] arg)
    {
        Console.Clear();       
        var repeat = arg.Distinct();
        byte n = 0;
        foreach (string el in repeat) n++;

        if (arg.Length == 0) Console.WriteLine("Error. No arguments entered.\nPlease enter an odd number of arguments, at least 3."); 
        else if (arg.Length != n) Console.WriteLine("Error. The entered parameters are repeated.\nPlease enter an odd number of arguments, at least 3.");
        else if (arg.Length < 3) Console.WriteLine("Error. Less than 3 arguments have been entered.\nPlease enter an odd number of arguments, at least 3.");
        else if ((arg.Length % 2) == 0) Console.WriteLine("Error. An odd number of arguments have been entered.\nPlease enter an odd number of arguments, at least 3.");
        else
        {                         
            Rules Rules = new ();
            int comp = new Random().Next(1, arg.Length + 1);

            RandomKey_HMAC hmac256 = new();        
            string bKey = hmac256.Key();       
            string sha256 = hmac256.HMACHASH(arg[comp - 1], bKey);

            Table help = new ();

            do                                                                                                             
            {
                Console.Clear();                
                byte i = 1;
                Console.WriteLine("HMAC: " + sha256 + "\nAvailable moves:");
                foreach (string el in arg)
                {
                    Console.WriteLine(i + " - " + el);
                    i++;
                }
                Console.WriteLine("0 - Exit\n? - Help\nPlease enter 1 character corresponding to your move:");

                string player_choise = Console.ReadLine()!;                                              

                if (player_choise.Length == 0) continue;                                                                  
                else if (player_choise.Length > 1) continue;
                
                else if (player_choise == "0")
                {                   
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    return;
                }
                else if (player_choise == "?")
                {
                    Console.Clear();
                    help.CreateTable(arg);
                    return;
                }
                else if (Char.IsNumber(player_choise[0]))
                {   
                    int player = Convert.ToInt32(player_choise);
                    string res = Rules.WhoWin(arg, player, comp);

                    if (player > 0 && player <= arg.Length)                                                               
                        {
                        Console.Clear();
                        Console.WriteLine("HMAC: " + sha256 + "\nYour move: " + arg[player - 1] + "\nComputer move: " + arg[comp - 1] + "\n" + res + "\nKey: " + bKey);
                        return;
                    }
                    else continue;
                }
                else continue;               
            } while (true);
        }
    }
}
}