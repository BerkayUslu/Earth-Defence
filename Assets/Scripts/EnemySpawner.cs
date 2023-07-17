using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Transform playerTransform;
    private void Awake()
    {
        playerTransform = GameObject.Find("PlayerMain").transform;
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private Vector3 GenerateRandomLocationAroudnPlayer()
    {
        //Generate random angle
        //Genrate random between 25 and 30
        //Get that point accoring to the player then generate
        float angle = Random.Range(0f, 360f);
        float magnitude = Random.Range(30f, 35f);
        float x = magnitude * Mathf.Sin(angle * Mathf.Deg2Rad);
        float y = magnitude * Mathf.Cos(angle * Mathf.Deg2Rad);
        Vector3 location = new Vector3(x, 0, y) + playerTransform.position;
        return location;

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = EnemyPool.enemyPoolSharedInstance.GetPooledObject();
            if(enemy != null)
            {
                enemy.transform.position = GenerateRandomLocationAroudnPlayer();
                enemy.transform.rotation = Quaternion.identity;
                enemy.SetActive(true);

            }
            yield return new WaitForSeconds(3);
        }
    }
}
