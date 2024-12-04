using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStatus))]

public class Tracking_movement : MovementBase
{

    [SerializeField] private CharacterStatus _characterStatus;


    [SerializeField]private GameObject lookTarget;

    [SerializeField]private float _rotationSpeed =0.1f;

    private bool _canmove=false;
    


    protected override void FirstMove()
    {


        _characterStatus = this.gameObject.GetComponent<CharacterStatus>();


    }
    /// <summary>
    /// ���t���[�������̏�Ԃ��m�F����B
    /// </summary>
    protected override void CheckStatus()
    {

        if (lookTarget != null)
        {
            if (_characterStatus.CurrentIsDeath != true)
            {
                _canmove = true;
            }
            else
            {

                _canmove = false;
            }

        }

    }

    /// <summary>
    /// ���x����
    /// </summary>

    protected override void SpeedControl()
    {
        if (lookTarget != null)
        {
            if (_canmove)
            {
                Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                if (flatVel.magnitude > _moveSpeed)
                {
                    Vector3 limitdVel = flatVel.normalized * _moveSpeed;
                    rb.velocity = new Vector3(limitdVel.x, rb.velocity.y, limitdVel.z);

                }
            }

        }



    }


    /// <summary>
    /// �v���C���[�̈ړ�����
    /// </summary>

    protected override void Move()
    {
        if (lookTarget != null)
        {
            if (_canmove)
            {
                Rotate();
                //�i�s�����ɐݒ葬�x���悶���͂�^����B
                rb.AddForce(transform.forward * _moveSpeed * _firstSpeed, ForceMode.Force);
            }
        }


    }

    /// <summary>
    /// ��]����
    /// </summary>

    protected void Rotate()
    {
        if (lookTarget != null)
        {
            if (_canmove)
            {
                var direction = lookTarget.transform.position - transform.position;
                direction.y = 0;
                var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, _rotationSpeed);

            }

        }
    }


}
