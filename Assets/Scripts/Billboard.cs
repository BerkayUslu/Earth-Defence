using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform player;
    Transform _transform;
    Vector3 positionDifference;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        positionDifference = -player.position + transform.position;
    }

    private void LateUpdate()
    {
        _transform.position = player.position + positionDifference;
        transform.LookAt(transform.position + cam.forward);
    }
}
