using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float speed = 10f;
    //Bullet 1: 40 damage with maximum force
    private float bullet1Speed = 30f;
    private int bullet1Damage = 40;
    //Bullet 2: 80 damage with medium force
    private float bullet2Speed = 15f;
    private int bullet2Damage = 80;
    //Bullet 3: 120 damage with minimum force
    private float bullet3Speed = 5f;
    private int bullet3Damage = 120;

    void Start()
    {
        StartCoroutine(BulletDestroyer());
    }

    void Update()
    {
        BulletMovement();
    }
    private void BulletMovement() // Moving the bullet
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    IEnumerator BulletDestroyer() // Destroying the bullet after the instantiation time of 3s
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other) // When bullet is colliding with enemy
    {
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
        Vector3 getDirection = -transform.position + other.transform.position;
        if (other.gameObject.CompareTag("Enemy") == true && GameObject.FindGameObjectWithTag("Gun1")) // For bullet 1 Damage + Force
        {
            Debug.Log("Bullet 1");
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Transform enemyPos = other.GetComponent<Transform>();
            enemyRb.GetComponent<Rigidbody>().AddForce(getDirection * bullet1Speed, ForceMode.Impulse);
            enemy.enemyHealth -= bullet1Damage;
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy") == true && GameObject.FindGameObjectWithTag("Gun2")) // For bullet 2 Damage + Force
        {
            Debug.Log("Bullet 2");
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Transform enemyPos = other.GetComponent<Transform>();
            enemyRb.GetComponent<Rigidbody>().AddForce(getDirection * bullet2Speed, ForceMode.Impulse);
            enemy.enemyHealth -= bullet2Damage;
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy") == true && GameObject.FindGameObjectWithTag("Gun3")) // For bullet 3 Damage + Force
        {
            Debug.Log("Bullet 3");
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Transform enemyPos = other.GetComponent<Transform>();
            enemyRb.GetComponent<Rigidbody>().AddForce(getDirection * bullet3Speed, ForceMode.Impulse);
            enemy.enemyHealth -= bullet3Damage;
            Destroy(this.gameObject);
        }
    }
}
