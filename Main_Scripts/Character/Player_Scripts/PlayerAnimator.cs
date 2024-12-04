using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private Animator _playerAnimator;

    Vector3 movement;



    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        _playerAnimator.SetFloat("Horizontal", movement.x);
        _playerAnimator.SetFloat("Vertical", movement.z);
        _playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }




}
