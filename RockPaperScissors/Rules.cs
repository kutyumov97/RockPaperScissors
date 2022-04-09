namespace RockPaperScissors
{
    internal class Rules
    {
        public string WhoWin(string[] arg, int player, int comp)
        {
            string result;
            int half = (arg.Length - 1) / 2;

            if (player == comp)          
                result = "It's a draw.";            
            else if (((player -  comp) > 0 && (player -  comp) <= half) || ((player - comp) < 0 && (comp - player) > half))
                result = "You win!";
            else result = "lose!";            
            return result;
        }
    }
}
