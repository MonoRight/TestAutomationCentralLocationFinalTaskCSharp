using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationCentralLocationFinalTaskCSharp.BLL
{
    public class Score
    {
        public int ScoreTeam1 { get; private set; }
        public int ScoreTeam2 { get; private set; }

        public Score(int scoreTeam1, int scoreTeam2)
        {
            ScoreTeam1 = scoreTeam1;
            ScoreTeam2 = scoreTeam2;
        }
    }
}
