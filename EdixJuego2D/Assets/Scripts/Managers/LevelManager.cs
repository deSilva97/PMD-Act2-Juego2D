using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    public int currentPoints { get; private set; }

    public static event System.Action<int, int> onPointAdded;

    public static event Action<int, int> onScoreCompareEnds;
    public static event Action<int> onStarsCompareEnds;

    private void OnEnable()
    {
        EndGameManager.onGameWin += FinnishLevel;        
    }

    private void OnDisable()
    {
        EndGameManager.onGameWin -= FinnishLevel;        
    }

    private void Awake()
    {

        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        AddPoints(0);
        TimeManager.Resume();
    }

    public void AddPoints(int value)
    {
        currentPoints += value;
        onPointAdded?.Invoke(currentPoints, value);
    }

    public void FinnishLevel()
    {
        Level levelLoaded = LoadLevel(SceneManager.GetActiveScene().buildIndex);
        Level levelToCompare = new Level();
        Level levelToSave = new Level();

        levelToCompare.score = currentPoints;
        levelToCompare.stars = PlayerManager.Instance.getChests();

        levelToSave.id = levelLoaded.id;

        levelToSave.score = CompareInts(levelToCompare.score, levelLoaded.score);
        onScoreCompareEnds?.Invoke(levelToCompare.score, levelLoaded.score);

        levelToSave.stars = CompareInts(levelToCompare.stars, levelLoaded.stars);
        onStarsCompareEnds?.Invoke(levelToCompare.stars);

        SaveLevel(levelToSave);
    }

    private int CompareInts(int a, int b) => (a > b) ? a : b;

    public static void SaveLevel(Level level)
    {
        PlayerPrefs.SetInt("lvl" + level.id + "score", level.score);
        PlayerPrefs.SetInt("lvl" + level.id + "stars", level.stars);
        PlayerPrefs.SetInt("lvl" + level.id + "complete", Convert.ToInt16(1));
    }

    public static Level LoadLevel(int buildIndex)
    {
        Level lvl = new Level();
        lvl.id = buildIndex;
        lvl.score = PlayerPrefs.GetInt("lvl" + lvl.id + "score", 0);
        lvl.stars = PlayerPrefs.GetInt("lvl" + lvl.id + "stars", 0);
        lvl.complete = Convert.ToBoolean(PlayerPrefs.GetInt("lvl" + lvl.id + "complete", 0));
        return lvl;
    }

    public class Level
    {
        public int id;
        public int score;
        public int stars;
        public bool complete;
    }

}
