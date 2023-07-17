using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackPool : MonoBehaviour
{
    public static PlayerAttackPool attackPoolSharedInstance;
    public List<GameObject> pooledObjects;
    PlayerMovement _playerMovement;
    [SerializeField] GameObject objectToBePolled;
    [SerializeField] int amountToPool = 5;


    private void Awake()
    {
        attackPoolSharedInstance = this;
        pooledObjects = new List<GameObject>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    void Start()
    {
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToBePolled);
            tmp.SetActive(false);
            tmp.GetComponent<Stone>().SetPlayerMovementreference(_playerMovement);
            pooledObjects.Add(tmp);
        }
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
