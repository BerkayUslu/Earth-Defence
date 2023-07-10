using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    bool isCollided = false;
    float collisionTime;
    PlayerMovement _playerMovement;
    Transform _transform;
    Vector3 direction;
    float stoneSpeed = 20;
    [SerializeField] float totalLifeTime = 6;
    float deathTime;


    float secondsToDestroyAfterCollision = 0.15f;

    private void Awake()
    {
        collisionTime = Time.time;
        _transform = transform;
        _playerMovement = GameObject.Find("PlayerMain").GetComponent<PlayerMovement>();
        direction = _playerMovement.WherePlayerLooks();
        deathTime = Time.time + totalLifeTime;
    }
    void Start()
    {
        
    }


    void Update()
    {
        IfCollidedAndSecondsPassedDestroy(secondsToDestroyAfterCollision);
        MoveStone();
    }

    private void IfCollidedAndSecondsPassedDestroy(float a)
    {
        float time = Time.time;
        if ((time - collisionTime > a && isCollided) || time > deathTime)
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollided = true;
        collisionTime = Time.time;
    }
    private void MoveStone()
    {
        _transform.position = new Vector3(direction[0] * stoneSpeed * Time.deltaTime + _transform.position.x, _transform.position.y, direction[2] * stoneSpeed * Time.deltaTime + _transform.position.z);
    }

}
