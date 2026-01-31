using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip wompWomp;
    public AudioClip CORRECT;

    public GameObject headChest;

    public float Timer = 0f;

    public string levelToLoad;
    private bool IsTimerRunning = false;
    public bool realChest = false;
    public bool fakeChest = false;
    //store the number of collected items in a variable
    public bool hasChest = false;
    //whenever we collide with a new collectable, add to my variable
    //destroy the collected item so we can't spam collect 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //check to see if we hit a coin specifically
        if(collision.gameObject.tag == "Chest" && (hasChest == false))
        {
            headChest.SetActive(true);
            hasChest = true;
            //Destroy the coin game object that we hit
            Destroy(collision.gameObject);
            realChest = true;
        }
        if (collision.gameObject.tag == "fakeChest" && (hasChest == false))
        {
            headChest.SetActive(true);
            hasChest = true;
            //Destroy the coin game object that we hit
            Destroy(collision.gameObject);
            fakeChest = true;
        }
        if(collision.gameObject.tag == "DropPoint")
        {
            if(hasChest == true)
            {
                headChest.SetActive(false);
                if (realChest == true)
                {
                    IsTimerRunning = true;
                    hasChest = false;
                    realChest = false;
                    if (audioSource != null)
                    {
                        audioSource.PlayOneShot(CORRECT);
                    }

                }
                if (fakeChest == true)
                {
                    if (audioSource != null)
                    {
                        audioSource.PlayOneShot(wompWomp);
                    }
                    hasChest = false;
                    fakeChest = false;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTimerRunning == true)
        {
            Timer += Time.deltaTime;
            if (Timer >= 3f)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }

    }
}
