using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public string name;
    public void Onclicked()
    {
        SceneManager.LoadScene(name);
    }
}
