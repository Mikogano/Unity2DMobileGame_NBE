using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    public string levelToLoad;
    public bool realChest = false;
    public bool fakeChest = false;
    //store the number of collected items in a variable
    public bool hasChest = false;
    //whenever we collide with a new collectable, add to my variable
    //destroy the collected item so we can't spam collect 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //check to see if we hit a coin specifically
        if(collision.gameObject.tag == "Chest" && (hasChest == false))
        {
            hasChest = true;
            //Destroy the coin game object that we hit
            Destroy(collision.gameObject);
            realChest = true;
        }
        if (collision.gameObject.tag == "fakeChest" && (hasChest == false))
        {
            hasChest = true;
            //Destroy the coin game object that we hit
            Destroy(collision.gameObject);
            fakeChest = true;
        }
        if(collision.gameObject.tag == "DropPoint")
        {
            if(hasChest == true)
            {
                if (realChest == true)
                {
                    hasChest= false;
                    realChest= false;
                    SceneManager.LoadScene(levelToLoad);
                }
                if (fakeChest == true)
                {
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
        
    }
}
