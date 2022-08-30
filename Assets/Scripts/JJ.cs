using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JJ : MonoBehaviour
{
    public bool _onground = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _onground = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _onground = false;
    }
}
