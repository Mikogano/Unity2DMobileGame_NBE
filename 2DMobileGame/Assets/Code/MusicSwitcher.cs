using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    // Public Prefabs
    public GameObject SafePlaceMusic;
    public AudioSource SoundTrack1;
    public AudioSource SoundTrack2;
    //public floats
    public float fadeDuration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player is touching the trigger
        if (collision.gameObject.tag == "SafePlace")
        {
            StartCoroutine(AudioHelper1.FadeOut(SoundTrack1, fadeDuration));
            StartCoroutine(AudioHelper2.FadeIn(SoundTrack2, fadeDuration));
        }

    }
    void OnTriggerExit2D(Collider collision)
    {
        if (collision.gameObject.tag == "SafePlace")
        {
            StartCoroutine(AudioHelper2.FadeOut(SoundTrack2, fadeDuration));
            StartCoroutine(AudioHelper1.FadeIn(SoundTrack1, fadeDuration));
        }
    }
}
