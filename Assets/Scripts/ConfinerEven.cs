using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConfinerEven : MonoBehaviour
{
    [SerializeField] private GameObject Monsters;
    [SerializeField] private List<Transform> monster;
    [SerializeField] private List<Vector3> wich;
    [SerializeField] private float hp;
    private void Awake()
    {
        int i = 0;
        Debug.Log(Monsters.transform.childCount);
        while(i < Monsters.transform.childCount)
        {
            Debug.Log(Monsters.transform.GetChild(i).name);
            monster.Add(Monsters.transform.GetChild(i));
            i++;
        }
        for (i = 0; i < monster.Count; i++)
        {
            wich.Add(monster[i].position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("PlayerCam").GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = GetComponent<PolygonCollider2D>();
            Monsters.SetActive(true);
            for(int i =0; i<monster.Count; i++)
            {
                monster[i].gameObject.SetActive(true);
                monster[i].GetComponent<HP>().CurHP = monster[i].GetComponent<HP>().MaxHP;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for(int i = 0; i< monster.Count; i++)
            {
                monster[i].position = wich[i];
            }
            Monsters.SetActive(false);
        }
    }
}
