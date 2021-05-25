namespace ScoreListDB
{
    public class ScoreEntity
    {     
        public string StudentName { get; set;}

        public int EnglishScore { get; set; }

        public int MathScore { get; set; }

        public int EconomicScore { get; set; }

        public ScoreEntity(string studentname, int englishscore, int mathscore, int economicscore)
        {
            StudentName = studentname;

            EnglishScore = englishscore;

            MathScore = mathscore;

            EconomicScore = economicscore;
        }
        
    }
}