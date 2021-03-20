using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public GameObject finish_panel;
    public GameObject pause_menu;
    public GameObject player;
    private float time;
    public int restarts;
    bool paused = false;

    private void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pause_menu.SetActive(true);
            pause_menu.transform.GetChild(1).GetComponent<TMP_Text>().text = "Revives: " + restarts;
            pause_menu.transform.GetChild(2).GetComponent<TMP_Text>().text = "Time: " + time.ToString("0.0");
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<CharacterController>().Move(0, false, false, false, false);
            Time.timeScale = 0;
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            UnPause();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        finish_panel.SetActive(true);
        finish_panel.transform.GetChild(1).GetComponent<TMP_Text>().text = "Revives: " + restarts;
        finish_panel.transform.GetChild(2).GetComponent<TMP_Text>().text = "Time: " + time.ToString("0.0");
        player.SetActive(false);
    }

    public void UnPause()
    {
        pause_menu.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController>().Move(0, false, false, false, false);
        Time.timeScale = 1;
        paused = false;
    }
}
