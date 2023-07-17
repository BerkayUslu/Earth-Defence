using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    private void Awake()
    {
        
    }

    public void DamagePlayer(int a)
    {
        playerHealth -= a;
        if(playerHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
}
