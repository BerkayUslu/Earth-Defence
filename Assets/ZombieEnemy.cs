using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    [SerializeField] float enemySpeedConstant = 3;
    [SerializeField] float enemyMaxSpeed = 2;
    [SerializeField] float enemyMinSpeed = 0;

    Transform _transform;
    PlayerMovement _playerMovement;
    PlayerHealth _playerHealth;
    bool coroutineFlag = false;
    Coroutine attackCoroutine;

    private void Awake()
    {
        GameObject player = GameObject.Find("PlayerMain");
        _playerHealth = player.GetComponent<PlayerHealth>();
        _playerMovement = player.GetComponent<PlayerMovement>();
        _transform = transform;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = _playerMovement.GetPosition();
        if (new Vector2(playerPosition.x - _transform.position.x, playerPosition.z - _transform.position.z).magnitude > 1.8f)
        {
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;

            }
            coroutineFlag = false;
            float adjustedSpeed = Mathf.Clamp(enemySpeedConstant * Time.deltaTime, enemyMinSpeed, enemyMaxSpeed);
            _transform.position = Vector3.MoveTowards(_transform.position, playerPosition, adjustedSpeed);
        }
        else
        {
            //attack
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(Attack());
            }
        }



        Quaternion lookTowards = Quaternion.LookRotation(new Vector3(playerPosition.x - _transform.position.x, 0, playerPosition.z - _transform.position.z));
        _transform.rotation = Quaternion.Lerp(_transform.rotation, lookTowards, 1);

    }

    IEnumerator Attack()
    {
        while (true)
        {
            _playerHealth.DamagePlayer(1);
            yield return new WaitForSeconds(.5f);
        }
    }
}
