using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable 
{
    int maxLife = 3;

    public int currentLife { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDamage(int value)
    {
        currentLife -= value;
        if (currentLife <= 0)
            Destroy(gameObject);
    }

}
