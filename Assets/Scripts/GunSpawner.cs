using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public GameObject[] gunPrefab;
    private PlayerController playerController;
    private GunsManager gunsManager;
    public GameObject gunManagerObject;
    public GameObject playerObject;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        gunsManager = gunManagerObject.GetComponent<GunsManager>();
    }

    void Update()
    {
        GunSpawing();
    }
    private void GunSpawing() // For Spawing 3 different kind of guns
    {
        bool getGunKey1 = Input.GetButtonDown("Gun 1");
        bool getGunKey2 = Input.GetButtonDown("Gun 2");
        bool getGunKey3 = Input.GetButtonDown("Gun 3");
        Vector3 gunSpawnLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (GameObject.FindGameObjectWithTag("Gun1") == false && GameObject.FindGameObjectWithTag("Gun2") == false && GameObject.FindGameObjectWithTag("Gun3") == false)
        {
            Instantiate(gunPrefab[0], gunSpawnLocation, gunsManager.transform.rotation, gunsManager.transform);
        }
        if (getGunKey1 == true) // Spawning gun 1
        {
            getGunKey2 = false;
            getGunKey3 = false;
            if (GameObject.FindGameObjectWithTag("Gun2"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Gun2").gameObject);
            }
            if (GameObject.FindGameObjectWithTag("Gun3"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Gun3").gameObject);
            }
            if (GameObject.FindGameObjectWithTag("Gun1") == false)
            {
                Instantiate(gunPrefab[0], gunSpawnLocation, gunsManager.transform.rotation, gunsManager.transform);
            }
        }
        else if (getGunKey2 == true) // Spawning gun 2
        {
            getGunKey1 = false;
            getGunKey3 = false;
            if (GameObject.FindGameObjectWithTag("Gun1"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Gun1").gameObject);
            }
            if (GameObject.FindGameObjectWithTag("Gun3"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Gun3").gameObject);
            }
            if (GameObject.FindGameObjectWithTag("Gun2") == false)
            {
                Instantiate(gunPrefab[1], gunSpawnLocation, gunsManager.transform.rotation, gunsManager.transform);
            }
        }
        else if (getGunKey3 == true) // Spawning gun 3
        {
            getGunKey1 = false;
            getGunKey2 = false;
            if (GameObject.FindGameObjectWithTag("Gun1"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Gun1").gameObject);
            }
            if (GameObject.FindGameObjectWithTag("Gun2"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Gun2").gameObject);
            }
            if (GameObject.FindGameObjectWithTag("Gun3") == false)
            {
                Instantiate(gunPrefab[2], gunSpawnLocation, gunsManager.transform.rotation, gunsManager.transform);
            }
        }
    }
}
