using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5;
    public float playerHealth = 100;
    public int enemyKilled = 0;
    private float timeCounter = 60f; // 1 min time counter

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GameTimer();
        PlayerMovement();
        GameStop();
    }

    private void PlayerMovement() // For player movement
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.right * speed * Time.deltaTime * horizontalInput, ForceMode.Impulse);
        playerRb.AddForce(Vector3.forward * speed * Time.deltaTime * verticalInput, ForceMode.Impulse);
    }
    private void GameStop() // For making the game stop
    {
        if (playerHealth <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }
    private void GameTimer() // The game timer to check the results after a certain time
    {
        timeCounter -= Time.deltaTime;
        if (timeCounter <= 0) // after 1 min of time
        {
            if (enemyKilled >= 15) // 15 enemies killed check
            {
                Time.timeScale = 0;
                Debug.Log("!!!Winner!!!");
            }
            else if (enemyKilled >= 15)
            {
                Time.timeScale = 0;
                Debug.Log("!!!Lose!!!");
            }
        }
    }
}
