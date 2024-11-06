using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float wanderRadius = 2.0f;
    private float ogxpos;
    private bool direction = false;
    // Start is called before the first frame update
    void Start()
    {
        ogxpos = this.transform.position.x;
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
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.transform.position.y > this.gameObject.transform.position.y + 1) {
            enemyDeath();
        } else {
            direction = !direction;
        }
    }

    private void enemyDeath() {
        this.gameObject.transform.localScale = new Vector3(5.69f, 2.0f);
        Invoke("enemyVanish", 0.5f);
    }

    private void enemyVanish() {
        this.gameObject.SetActive(false);
    }
}
