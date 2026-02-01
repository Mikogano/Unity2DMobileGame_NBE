using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip playerDamage;

    float Timer = 0f;
    public float flashRed = 0.1f;

    public GameObject prefab;
    public GameObject newCanvasGameObject;
    public float shootSpeed = 10f;
    public float bulletLifetime = 2f;
    //store the players health
    public float health = 3;
    float maxHealth;
    public Image healthBar;
    //if we collide with something tagged as enemy, take damage
    //if health gets too low, we die (reload the level)
    //if we collide with something tagged as health pack, increase health
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Timer = 0f;
            if (audioSource != null)
            {
                audioSource.PlayOneShot(playerDamage);
            }
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            health--;
            healthBar.fillAmount = health / maxHealth;
            if (health <= 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                newCanvasGameObject.SetActive(true); //activate a new canvas (whatever you select)
                Time.timeScale = 0f;
            }
            //get the mouse's position in the game
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            mousePos.z = 0;
            //spawn a bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            //push the bullet in the direction of the mouse
            //destination (mousePosition) - starting position (transform.position)
            Vector3 mouseDir = mousePos - transform.position;
            mouseDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = mouseDir * shootSpeed;
            Destroy(bullet, bulletLifetime);
        }
        //if we collide with the health pack collectable
        if(collision.gameObject.tag == "HealthPack")
        {
            //increase the health value
            health++;
            healthBar.fillAmount = health / maxHealth;
            Destroy(collision.gameObject);
            //if our health is trying to exceed our max health
            if(health > maxHealth)
            {
                //cap our health at max health
                health = maxHealth;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > flashRed)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
