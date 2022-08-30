using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Animator ani;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private bool _onground;
    [SerializeField] private bool _attaking;
    [SerializeField] private bool _DoJump;
    [SerializeField] private JJ jj;
    [SerializeField] private GameObject AtkRange;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        jj= GetComponentInChildren<JJ>();
    }
    private void Update()
    {
        Walk();
        Jump();
        Attack();
        Judge();
    }
    void Judge()
    {
        if (jj._onground)
        {
            _onground = true;
            _DoJump = true;
        }
        else
        {
            _onground=false;
        }
    }

    void Walk()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (!_attaking || (_attaking && !_onground))
        {
            rb.velocity = new Vector2(x * _speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if(x != 0)
        {
            ani.SetBool("Run", true);
        }
        else
        {
            ani.SetBool("Run", false);
        }
        if(x > 0)
        {
            sp.flipX = false;
            AtkRange.transform.rotation = new Quaternion(0, 0, 0, 0);
        }else if (x < 0)
        {
            sp.flipX = true;
            AtkRange.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
    
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (_onground)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jump);
            }
            else if (_DoJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jump);
                _DoJump = false;
            }
        }
        if (!_onground)
        {
            ani.SetBool("Jump", true);
        }
        else 
        {
            ani.SetBool("Jump", false);
        }
        float y = Mathf.Clamp(rb.velocity.y, -9, 9);
        rb.velocity = new Vector2(rb.velocity.x, y);
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!_attaking)
            {
                _attaking = true ;
                ani.SetBool("Attack", true);
            }
        }
    }
    void AttackStart()
    {
        if (_attaking)
        {
            AtkRange.SetActive(true);
        }

    }
    void Attack_End()
    {
        AtkRange.SetActive(false);
        _attaking = false;

        ani.SetBool("Attack", false);
    }
}
