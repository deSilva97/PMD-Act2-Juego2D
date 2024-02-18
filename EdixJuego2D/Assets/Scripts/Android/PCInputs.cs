using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputs : MonoBehaviour
{
#if UNITY_STANDALONE
    [Header("Inputs")]
    [SerializeField] KeyCode inputJump = KeyCode.Space;
    [SerializeField] KeyCode inputAttack = KeyCode.X;
    PlayerController playerController;

    private void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (!playerController.isAlive)
            return;

        playerController.Move(Input.GetAxisRaw("Horizontal"), Input.GetKey(inputJump));
        playerController.Attack(Input.GetKey(inputAttack) );
    }
#endif
}
