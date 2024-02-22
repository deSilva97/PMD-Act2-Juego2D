using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerSettings : MonoBehaviour
{
    [SerializeField] [Min(0)] float moveSpeedMultiplier = 1;
    //[SerializeField] [Min(0)] int numberJumps = 1;
    [SerializeField][Min(0)] int attackDamage = 1;

    private void Start()
    {
        savedMoveSpeedMultiplier = moveSpeedMultiplier;
        currentMoveSpeedMultiplier = moveSpeedMultiplier;

        savedAttackDamage = attackDamage;
        currentAttackDamage = attackDamage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (currentMoveSpeedMultiplier == 1)
                currentMoveSpeedMultiplier = 1.2f;
            else currentMoveSpeedMultiplier = 1;
        }
            
    }

    public static float currentMoveSpeedMultiplier { get; set; }

    public static float currentNumberJumps { get; set; }
    public static float currentAttackDamage { get; set; }



    private static float savedMoveSpeedMultiplier;
    private static int savedAttackDamage;


    public static void RecoverMoveSpeedMultiplier() => currentMoveSpeedMultiplier = savedMoveSpeedMultiplier;
    public static void RecoverSavedAttackDamage() => currentAttackDamage = savedAttackDamage;

}
