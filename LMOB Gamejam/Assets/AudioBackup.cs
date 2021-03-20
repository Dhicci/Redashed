using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackup : MonoBehaviour
{
    public AudioSource background_audio;
    // Start is called before the first frame update
    void Start()
    {
        if(!GameObject.FindGameObjectWithTag("BackgroundMusic"))
        {
            background_audio.enabled = true;
        }
    }

}
