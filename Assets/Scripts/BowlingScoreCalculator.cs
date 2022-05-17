using System.Collections.Generic;
using UnityEngine;

public class BowlingScoreCalculator
{
    private readonly int _numberOfTurns;
    private const int MaxScore = 10;

    public BowlingScoreCalculator(int numberOfTurns)
    {
        _numberOfTurns = numberOfTurns;
    }

    public int CalculateScore(List<int> gameScores)
    {
        int total = 0;
        for (int i = 0; i < _numberOfTurns; i++)
        {
            switch (gameScores[i])
            {
                case 11:
                    total += GetStrikeScore(gameScores, i);
                    break;
                case 10:
                    total += GetSpareScore(gameScores, i);
                    break;
                default:
                    total += gameScores[i];
                    break;
            }
        }

        return total;
    }
    
    private static int GetSpareScore(List<int> gameScores, int i)
    {
        return GetScore(gameScores[i]) + GetScore(gameScores[i + 1]);
    }
    
    private int GetStrikeScore(List<int> gameScores, int i)
    {
        return GetScore(gameScores[i]) + GetScore(gameScores[i + 1]) + GetScore(gameScores[i + 2]);
    }

    private static int GetScore(int scoreWithBonusFlag)
    {
        int actualScore = Mathf.Min(scoreWithBonusFlag, MaxScore);
        return actualScore;
    }
}
