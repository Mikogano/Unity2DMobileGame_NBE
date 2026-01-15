using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        //tell the animator component the values for x, and y
        GetComponent<Animator>().SetFloat("x", xInput);
        GetComponent<Animator>().SetFloat("y", yInput);
    }
}
