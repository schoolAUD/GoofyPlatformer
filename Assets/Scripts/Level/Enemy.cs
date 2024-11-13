using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float wanderRadius = 2.0f;
    public AudioSource audioSource;
    public AudioClip deathAudioClip;
    private float ogxpos;
    private bool direction = false;
    // Start is called before the first frame update
    void Start()
    {
        ogxpos = this.transform.position.x;
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = this.transform.position.x;
        if (direction) {
            if (ogxpos + wanderRadius > xpos) {
                this.transform.position = new Vector3(xpos+2.0f*Time.deltaTime, this.transform.position.y);
            } else {
                direction = !direction;
            }
            this.GetComponent<SpriteRenderer>().flipX = true;
        } else {
            
            if (ogxpos - wanderRadius < xpos) {
                this.transform.position = new Vector3(xpos-2.0f*Time.deltaTime, this.transform.position.y);
            } else {
                direction = !direction;
            }
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        xpos = this.transform.position.x;
        float ypos = this.transform.position.y;

        this.transform.rotation = new Quaternion(0,0,0,0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.transform.position.y > this.gameObject.transform.position.y + 1 && !collision.gameObject.name.ToLower().Contains("platform")) {
            enemyDeath();
        } else {
            direction = !direction;
        }
    }

    private void enemyDeath() {
        audioSource.PlayOneShot(deathAudioClip);
        this.gameObject.transform.localScale = new Vector3(5.69f, 2.0f);
        Invoke("enemyVanish", 0.5f);
    }

    private void enemyVanish() {
        this.gameObject.SetActive(false);
    }
}
