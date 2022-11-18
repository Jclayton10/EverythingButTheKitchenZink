using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BackgroundMusic : MonoBehaviourPunCallbacks
{
    public List<AudioClip> music;

    public AudioSource currentlyPlaying;

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponent<AudioSource>().enabled = false;
            this.enabled = false;
        }
        else
        {
            currentlyPlaying = GetComponent<AudioSource>();
            getNewSong();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentlyPlaying.isPlaying)
        {
            getNewSong();
        }
    }

    void getNewSong()
    {
        currentlyPlaying.clip = music[Random.Range(0, music.Count)];
        currentlyPlaying.Play();
    }
}
