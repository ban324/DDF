using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public bool ing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ing)
            {
                collision.gameObject.GetComponent<HP>().Damaged(transform.position, 2f);
                ing = false;
            }
        }

    }
    private void Update()
    {
        int a;
        if(GameObject.Find("boss").transform.rotation.y == 180)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            a = -1;
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            a = 1;
        }
        transform.position = GameObject.Find("boss").transform.position + Vector3.right * a;
    }
}
