using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private void Start()
    {
        
    }

    public static Level currentLevel { get; private set; }

    public static void FinnishLevel(int score, int stars)
    {

    }


    public struct Level
    {
        public string id;
        public string highscore;
        public int stars;
        public bool complete;
    }
}
