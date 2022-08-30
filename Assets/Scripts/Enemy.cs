using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float Vanghyang;
    [SerializeField] float Speed;
    [SerializeField] Vector3 start;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        start = transform.position;
    }
    private void Update()
    {
        Runn();
    }
    void Runn()
    {
        transform.position += Vector3.right * Speed * Time.deltaTime * Vanghyang;
        if(transform.position.x > start.x+3f)
        {
            Vanghyang = -1;
            spriteRenderer.flipX = false;
        }
        if(transform.position.x < start.x-3f)
        {
            Vanghyang = 1;
            spriteRenderer.flipX = true;
        }
    }


}
