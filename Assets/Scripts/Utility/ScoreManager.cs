using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platatformer2D
{
    public class ScoreManager
    {
        static int score;
        public static void ResetScore()
        {
            score = 0;
        }
        public static void IncreseScore()
        {
            score += 10;
        }
        public static int GetScore()
        {
            return score;
        }
    }
}

