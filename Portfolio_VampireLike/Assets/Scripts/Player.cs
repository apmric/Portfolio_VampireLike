using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;

    Vector2 inputVec;
    Vector2 nextVec;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        nextVec = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
    
    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
