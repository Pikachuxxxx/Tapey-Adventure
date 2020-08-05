using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    private float playerHealth = 100f;
    private float currentBatteryTime;

    public Slider healthBar;
    public Slider batteryBar;
    public bool canUseButtons { get; private set;}
    public float batteryLifeTime = 10f;
    private void Update()
    {
        if(playerHealth <= 0)
        {
            print("Game Over");
        }
        healthBar.value = playerHealth;

        if(currentBatteryTime > 1f && batteryBar.value > 0)
        {
            batteryBar.value -= 1 / batteryLifeTime;
            currentBatteryTime = 0f;
        }
        currentBatteryTime += Time.deltaTime;

        if(batteryBar.value <= 0)
        {
            canUseButtons = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet")
        {
            print("Player says AAhh....");
            playerHealth -= 10f;
        }

        if(collision.tag == "PowerBank")
        {
            canUseButtons = true;
            batteryBar.value = 1;
        }
    }
}

