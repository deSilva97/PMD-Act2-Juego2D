using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] EnemyControllerOld prefab; 
    [SerializeField] [Min(0)] int maxInstances = 1;
    [SerializeField] float timeToSpawn = 10f;
    [SerializeField] float minDistanceToSpawn = 10;
    [SerializeField] bool startAwake = true;

    List<EnemyControllerOld> myList;

    float timer;

    bool canSpawn;

    private void OnEnable()
    {
        PlayerController.onPlayerDead += () => canSpawn = false;
    }

    private void OnDisable()
    {
        PlayerController.onPlayerDead -= () => canSpawn = false;
    }

    private void Start()
    {
        myList = new List<EnemyControllerOld>();
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
        EnemyControllerOld e = Instantiate(prefab);
        e.transform.position = transform.position;
        e.onEnemyDie += ResolveEnemyDie;

        myList.Add(e);

        timer = timeToSpawn;
    }

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

    private void ResolveEnemyDie(EnemyControllerOld e)
    {
        myList.Remove(e);
    }
}
