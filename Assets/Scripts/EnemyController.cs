using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemySpawner enemySpawner;
    public float enemyHealth = 150f;
    public float speed = 100f;
    private Rigidbody enemyRb;
    private PlayerController playerController;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        EnemyAI();
        EnemyDestroyer();
    }
    private void EnemyAI() // Enemy AI to follow the player
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
    private void EnemyDestroyer() // Destryoying the enemy on the health of zero
    {
        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            enemySpawner.enemiesSpawned--;
            playerController.enemyKilled++;
            Debug.Log("Enemy Destroyed");
        }
        if(transform.position.y <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) // On the collision with the player perfroming enemy destroy and player health reduction
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.playerHealth -= 10;
            Debug.Log("Health: " + playerController.playerHealth);
            Destroy(this.gameObject);
            enemySpawner.enemiesSpawned--;
            playerController.enemyKilled++;
            Debug.Log("Enemy Destroyed");
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            enemySpawner.enemiesSpawned--;
            Destroy(this.gameObject);
            Debug.Log("Enemy Destroyed");
        }
    }
    public void GetEnemySpawner(EnemySpawner enemySpawnerObject) // Getting reference of the enemy spawner
    {
        enemySpawner = enemySpawnerObject;
        enemySpawner.enemiesSpawned++;
    }
}
