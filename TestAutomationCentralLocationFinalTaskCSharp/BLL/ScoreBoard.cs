using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationCentralLocationFinalTaskCSharp.Pages;

namespace TestAutomationCentralLocationFinalTaskCSharp.BLL
{
    public class ScoreBoard
    {
        public Score GetScore(FootballScoresAndFixturesPage footballScoresAndFixturesPage, string team1, string team2)
        {
            for (int i = 0; i < footballScoresAndFixturesPage.TeamsList.Count - 1; i++)
            {
                if (footballScoresAndFixturesPage.GetTextTeamByIndex(i) == team1 && footballScoresAndFixturesPage.GetTextTeamByIndex(i + 1) == team2) 
                {
                    int score1 = footballScoresAndFixturesPage.GetIntScoreByIndex(i);
                    int score2 = footballScoresAndFixturesPage.GetIntScoreByIndex(i + 1);
                    return new Score(score1, score2);
                }
            }
            return null;
        }
    }
}
