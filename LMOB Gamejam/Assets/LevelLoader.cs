using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transition_time = 1f;
    
    public void LoadNextLevel(int x)
    {
        StartCoroutine(LoadLevel(x));
    }

    IEnumerator LoadLevel(int level_index)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transition_time);

        SceneManager.LoadScene(level_index);
    }
}
