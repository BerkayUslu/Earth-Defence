using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    PlayerMovement _playerMovement;

    float lastTime;
    [SerializeField] float atackTime = 3;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        SetIdleAnimation(true);
        lastTime = Time.time;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (IsItPunchTimeAndNotPunching())
        {
            SetPunchingStateAndAnimation(true);
        }
        //normalized time 1 is whole animation while 0.5 is half of it like half of frames
        else if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f && _animator.GetBool("Punch"))
        {
            lastTime = Time.time;
            SetPunchingStateAndAnimation(false);
        }

        if (_playerMovement.IsCharacterMoving())
        {
            SetRunAnimation(true);
        }
        else
        {
            SetRunAnimation(false);
        }
    }

    private void SetPunchingStateAndAnimation(bool a)
    {
        SetPunchAnimation(a);
        _playerMovement.SetPunchingFlag(a);
    }

    private bool IsItPunchTimeAndNotPunching()
    {
        return Time.time - lastTime > atackTime && !_animator.GetBool("Punch");
    }

    void SetIdleAnimation(bool a)
    {
        _animator.SetBool("Idle", a);
    }
    void SetPunchAnimation(bool a)
    {
        _animator.SetBool("Punch", a);

    }
    void SetRunAnimation(bool a)
    {
        _animator.SetBool("Run", a);

    }
    public bool IsPunching()
    {
        return _animator.GetBool("Punch");
    }
}
