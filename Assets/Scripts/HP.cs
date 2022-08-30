using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HP : MonoBehaviour
{
    public float MaxHP;
    public float CurHP;
    [SerializeField] private bool Damaging = false;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] float Damage;
    [SerializeField] private SpriteRenderer SP;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        SP = GetComponent<SpriteRenderer>();
    }
    public void Damaged(Vector3 trans, float damage)
    {
        if(Damaging == false)
        {
            rigid.AddForce((transform.position -trans) * 5, ForceMode2D.Impulse);
            CurHP -= damage;
            StartCoroutine(DmgEff());
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HP>().Damaged(transform.position, Damage);
        }
    }
    IEnumerator DmgEff()
    {
        Damaging = true;
        int i = 0;
        while(i < 2)
        {
            SP.color = Color.black;
            yield return new WaitForSeconds(0.1f);
            SP.color = Color.white;
            yield return new WaitForSeconds(0.11f);
            i++;
        }
        if (CurHP <= 0)
        {
            if (gameObject.name == "boss")
            {
                SceneManager.LoadScene("End");
            }else
            if (CompareTag("Player"))
            {
                SceneManager.LoadScene("Die");
            }
            else gameObject.SetActive(false);
        }

        Damaging = false;
        yield return null;
    }
}
