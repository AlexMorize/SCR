using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip Begin, Loop, End;

    AudioSource player;
    void PlayLoop()
    {
        player.clip = Loop;
        player.loop = true;
        player.Play();
    }

    public void Stop()
    {
        player.Stop();
        player.clip = End;
        player.loop = false;
        player.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        player.clip = Begin;
        player.loop = false;
        player.Play();
        Invoke("PlayLoop", Begin.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
