using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public GameObject finish_panel;
    public GameObject player;
    private float time;
    public int restarts;

    private void Update()
    {
        time += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        finish_panel.SetActive(true);
        finish_panel.transform.GetChild(1).GetComponent<TMP_Text>().text = "Revives: " + restarts;
        finish_panel.transform.GetChild(2).GetComponent<TMP_Text>().text = "Time: " + time.ToString("0.0");
        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
