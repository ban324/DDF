using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed;
    [SerializeField] private float Damage;
    [SerializeField] private GameObject Patton;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool OnPatton = false;
    [SerializeField] private Vector3 POS;
    [SerializeField] private GameObject attack;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        StartCoroutine(pattonSel()); 

    }
    private void Update()
    {
         POS = Player.transform.position - transform.position;
        if(POS.x < 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if(POS.x > 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
    IEnumerator pattonSel()
    {

        while (true)
        {
            if (!OnPatton)
            {
                float x = Mathf.Abs(POS.x);
                float y = Mathf.Abs(POS.y);
                if (x + y > 1.5)
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        StartCoroutine(Walk());
                    }
                    else StartCoroutine(Cast());
                }
                else  StartCoroutine(Attack());
            }
            yield return null;
        }
        
    }
    IEnumerator Walk()
    {
        OnPatton = true;
        Debug.Log("asdf");
        float a;
        if(POS.x > 0)
        {
            a = 1;
        }
        else
        {
            a = -1;
        }
        animator.SetBool("Walk", true);
        float t = 0;
        while(t < 20)
        {
            rigid.velocity = new Vector2(a * 3, rigid.velocity.y);
            yield return new WaitForSeconds(0.1f);
            t++;
        }
        animator.SetBool("Walk", false);

        rigid.velocity = Vector2.zero;
        yield return new WaitForSeconds(2f);
        OnPatton = false;
    }

    IEnumerator Cast()
    {
        OnPatton = true;
        animator.SetBool("Cast", true);
        Patton.SetActive(true);
        Patton.transform.position = Player.transform.position + Vector3.up * 1;
        Patton.GetComponent<Spell>().Attack(); 
        yield return new WaitForSeconds(1f);
        Patton.SetActive(false);
        animator.SetBool("Cast", false);
        OnPatton = false;
    }
    IEnumerator Attack()
    {
        OnPatton = true;
        animator.SetBool("Attack", true);
        attack.GetComponent<Knife>().ing = true;
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("Attack", false);
        attack.GetComponent<Knife>().ing = false;
        OnPatton = false;
        yield return null;
    }
}
