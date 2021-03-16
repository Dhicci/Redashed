using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject player;
    public GameObject my_canvas;

    private void Start()
    {
        //my_canvas.enabled = false;
    }

    public void OnTriggerEnter2D()
    {
        Debug.Log("k");
        my_canvas.SetActive(true);
    }

}
