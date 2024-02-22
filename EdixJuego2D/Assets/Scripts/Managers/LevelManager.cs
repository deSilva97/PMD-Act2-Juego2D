using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance => instance;

    public static event System.Action<int, int> onPointAdded;

    public static event Action<int, int> onScoreCompareEnds;
    public static event Action<int> onStarsCompareEnds;

    public static event Action onGameWin;
    public static event Action onGameLose;

    public static int currentLevel { get; set; }

    public int currentPoints { get; private set; }


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
    private void Update()
    {
        //Debug.Log("Valor del input: " + Input.GetAxis("Horizontal"));

    }
    public void AddPoints(int value)
    {
        currentPoints += value;
        onPointAdded?.Invoke(currentPoints, value);
    }
    public void Win()
    {
        Debug.Log("Win Game " + currentLevel);
        onGameWin?.Invoke();
        FinnishLevel();
    }
    public void Lose() => onGameLose?.Invoke();

    public void FinnishLevel()
    {
        string scene = SceneManager.GetActiveScene().name;
        string[] split = scene.Split(" ");
        int id = Convert.ToInt32(split[1]);       

        Level levelLoaded = LoadLevel(id);
        Level levelToCompare = new Level(id);
        Level levelToSave = new Level(id);

        levelToCompare.score = currentPoints;
        levelToCompare.stars = PlayerManager.Instance.getChests();

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
        Level lvl = new Level(buildIndex);
        lvl.score = PlayerPrefs.GetInt("lvl" + lvl.id + "score", 0);
        lvl.stars = PlayerPrefs.GetInt("lvl" + lvl.id + "stars", 0);
        lvl.complete = Convert.ToBoolean(PlayerPrefs.GetInt("lvl" + lvl.id + "complete", 0));
        return lvl;
    }

    [System.Serializable]
    public class Level
    {
        public int id;
        public int score;
        public int stars;
        public bool complete;

        public Level(int id)
        {
            this.id = id;
        }

        public Level(int id, int score, int stars, bool complete)
        {
            this.id = id;
            this.score = score;
            this.stars = stars;
            this.complete = complete;
        }
    }

}
