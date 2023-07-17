using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float lastTime = 0;
    Transform _transform;
    PlayerMovement _playerMovement;
    PlayerAnimation _playerAnimation;
    [SerializeField] GameObject stonePrefab;
    [SerializeField] float waitTime = .4f;
    bool inProcess = false;
    float castTime = 0;

    private void Awake()
    {
        _transform = transform;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerAnimation.IsPunching() && ! inProcess && Time.time > lastTime + 1)
        {
            castTime = Time.time + waitTime;
            inProcess = true;
        }
        if (Time.time >= castTime && inProcess)
        {
            inProcess = false;
            lastTime = Time.time;
            GameObject attack = PlayerAttackPool.attackPoolSharedInstance.GetPooledObject();
            if(attack != null)
            {
                Vector3 movementVector = _playerMovement.WherePlayerLooks();
                //Instantiate(stonePrefab
                //    ,new Vector3(_transform.position.x + (movementVector.x * StoneDistanceFromPlayer), _transform.position.y + 1, _transform.position.z + (movementVector.z * StoneDistanceFromPlayer))
                //    , Quaternion.identity);
                attack.transform.rotation = Quaternion.identity;
                attack.transform.position = new Vector3(_transform.position.x + movementVector.x , _transform.position.y + 1, _transform.position.z + movementVector.z );
                attack.SetActive(true);

            }
            
        }
    }
}
