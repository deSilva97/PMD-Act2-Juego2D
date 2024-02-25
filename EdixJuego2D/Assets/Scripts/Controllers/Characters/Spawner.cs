using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] EnemyController prefab; 
    [SerializeField] [Min(0)] int maxInstances = 1;
    [SerializeField] float timeToSpawn = 10f;
    [SerializeField] float minDistanceToSpawn = 10;
    [SerializeField] bool startAwake = true;

    List<EnemyController> myList;

    float timer;

    bool canSpawn;

    private void OnEnable()
    {
        PlayerManager.onPlayerDead += StopSpawning;
    }

    private void OnDisable()
    {
        PlayerManager.onPlayerDead -= StopSpawning;
    }

    private void Start()
    {
        myList = new List<EnemyController>();
        timer = startAwake? 0 : timeToSpawn;
        Recover();
    }

    public void Recover()
    {
        canSpawn = true;
        StartCoroutine(SpawnSystem());
    }

    private void Spawn()
    {
        EnemyController e = Instantiate(prefab);
        e.transform.position = transform.position;
        //e.onEnemyDie += ResolveEnemyDie;

        myList.Add(e);

        timer = timeToSpawn;
    }

    private void StopSpawning() => canSpawn = false;
    IEnumerator SpawnSystem()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(timer);

            while (myList.Count >= maxInstances)
                yield return new WaitForEndOfFrame();

            while (Vector2.Distance(Camera.main.transform.position, transform.position) < minDistanceToSpawn)
                yield return new WaitForEndOfFrame();

            Spawn();
        }
    }

    private void ResolveEnemyDie(EnemyController e)
    {
        myList.Remove(e);
    }
}
