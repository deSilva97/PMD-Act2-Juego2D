using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AndroidInputs : MonoBehaviour
{
    [SerializeField] GameObject content;
    private void Start()
    {
        content.SetActive(false);
#if UNITY_ANDROID
        content.SetActive(true);
#endif
    }
#if UNITY_ANDROID
    PlayerController playerController;

    bool jumping;
    int currentMove;

    private void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();

    }

    private void Update()
    {
        if (!playerController.isAlive)
            return;

        playerController.Move(currentMove, jumping);        
    }

    public void Attack()
    {
        Debug.Log("Attack");
        playerController.Attack(true);
    }

    public void StartJump()
    {
        jumping = true;
    }
    public void EndJump()
    {
        jumping=false;
    }

    public void Stop()
    {
        currentMove = 0;
    }

    public void MoveLeft()
    {
        currentMove = -1;
    }

    public void MoveRight()
    {
        currentMove = 1;
    }
#endif
}
