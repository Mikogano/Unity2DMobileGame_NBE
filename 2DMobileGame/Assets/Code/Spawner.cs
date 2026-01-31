using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    // Public Floats
    public float Timer = 0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Timer >= 10f)
        {
            Timer = 0f;
            if (!(collision.gameObject.tag == "Enemy"))
            {
                GameObject Enemy1 = Instantiate(prefab, transform.position, Quaternion.identity);
            }
        }
    }
}


 