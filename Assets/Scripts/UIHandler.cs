using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject healthUI;
    [SerializeField] PlayerHealth playerHealth;
    Transform _healthTransform;

    private void Awake()
    {
        _healthTransform = healthUI.transform;
    }
    private void Update()
    {
        _healthTransform.localScale = new Vector3((float)(100 - playerHealth.GetPlayerHealth()) / 100, 1, 1);
    }
}
