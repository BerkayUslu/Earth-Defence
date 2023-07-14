using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool enemyPoolSharedInstance;
    public List<GameObject> pooledObjects;
    private PlayerMovement _playerMovement;
    private PlayerHealth _playerHealth;
    private EnemySpawner _enemySpawner;
    [SerializeField] GameObject objectToPool;
    [SerializeField] int amountToPool = 20;


    private void Awake()
    {
        GameObject player = GameObject.Find("PlayerMain");
        _playerMovement = player.GetComponent<PlayerMovement>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        enemyPoolSharedInstance = this;
        _enemySpawner = GetComponent<EnemySpawner>();

    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.GetComponent<ZombieEnemy>().SetPlayerReferences(_playerHealth, _playerMovement);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        _enemySpawner.enabled = true;
    }

    //If there is any unused object it will return it
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
