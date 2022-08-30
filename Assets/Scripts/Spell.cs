using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        animator.SetBool("Attacking", true);
        StartCoroutine(Atc());
    }
    IEnumerator Atc()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.7f);
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(1f);
        animator.SetBool("Attacking", false); GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(1f);
    }
}
