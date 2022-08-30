using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye : MonoBehaviour
{
    [SerializeField] private Animator Anim;
    [SerializeField] GameObject Player;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Vector3 Dist;
    private void Awake()
    {
        Player = GameObject.Find("Player");
        Anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        Anim.SetBool("Die", false);
    }
    private void Update()
    {
        if(GetComponent<HP>().CurHP < 1)
        {
            Anim.SetBool("Die", true);
        }
        Dist = Player.transform.position - transform.position;
        if(Mathf.Abs(Dist.x) + Mathf.Abs(Dist.y) > 1)
        {
            transform.position += Dist.normalized * Time.deltaTime * 2;
        }
        if(Dist.x > 0)
        {
            sp.flipX = false;
        }
        else if(Dist.x < 0)
        {
            sp.flipX = true;
        }

    }
    public void DieEnd()
    {
        gameObject.SetActive(false);
    }
}
