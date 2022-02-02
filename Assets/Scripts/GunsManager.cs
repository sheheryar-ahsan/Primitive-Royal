using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsManager : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject playerObject;
    private GunSpawner gunSpawner;
    public GameObject gunSpawnerObject;
    public GameObject[] bulletPrefab;
    private float rotationSpeed = 150f;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        gunSpawner = gunSpawnerObject.GetComponent<GunSpawner>();
    }

    void Update()
    {
        GunSpawningLocation();
        GunRotation();
        BulletSpawning();
    }
    public void GunSpawningLocation() // Binding the Guns manager to the location of the player
    {
        transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, playerController.transform.position.z);
    }
    private void GunRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
    private void BulletSpawning() // Spawing the bullet
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawningBulletType();
        }
    }
    private void SpawningBulletType() // Giving location to spawn the bullet
    {
        Vector3 bulletPosition = new Vector3(gunSpawner.transform.position.x, gunSpawner.transform.position.y, gunSpawner.transform.position.z);
        if (GameObject.FindGameObjectWithTag("Gun1"))
        {
            Instantiate(bulletPrefab[0], bulletPosition, gunSpawner.transform.rotation);
        }
        else if (GameObject.FindGameObjectWithTag("Gun2"))
        {
            Instantiate(bulletPrefab[1], bulletPosition, gunSpawner.transform.rotation);
        }
        else if (GameObject.FindGameObjectWithTag("Gun3"))
        {
            Instantiate(bulletPrefab[2], bulletPosition, gunSpawner.transform.rotation);
        }
    }

}
