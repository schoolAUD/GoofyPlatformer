
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player; // the player. also public so we can set it.
    public SpriteRenderer sprRender; // the sprite, so we can flip it when needed
    public float playerSpeed = 2.0f; // playerspeed. public because we can modify it for later levels where we want to go FAST.
    private float actualPlayerSpeed; // actualplayerspeed. is used for sprinting and walking, but not for changing jump height.
    private bool sprinting = false; // are we sprinting?
    private bool jumping = false; // jumping variable
    private bool canJump = false;
    private float offset = 0f;
    private float ogpos = 0f;
    private float newpos = 0f;
    private Transform collidedObject;

    private Transform currentPlatform;  // The platform the player is standing on
    private Vector3 lastPlatformPosition;
    private bool onPlatform;

    public ParticleSystem particleSystem;

    private float jumpMomentum = 0f;
    private bool jumpIncreasing = false;
    private Camera pcamera;
    private bool dead = false;
    private Vector3 deadpos = new Vector3(0,0);

    private Vector3 originalposition;
    // Start is called before the first frame update
    void Start()
    {
        originalposition = transform.position;
        actualPlayerSpeed = playerSpeed;
        pcamera = (Camera) FindObjectOfType(typeof(Camera));
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0,0,0,0);
        float playerX = transform.position.x;
        float playerY = transform.position.y;

        sprinting = Input.GetKey(KeyCode.LeftShift);
        if (sprinting) {
            actualPlayerSpeed = playerSpeed*2.5f;
        } else {
            actualPlayerSpeed = playerSpeed;
        }

        if (Input.GetKey(KeyCode.A)) // left movement
        {

         playerX = transform.position.x;
         playerY = transform.position.y;
            player.position = new Vector3(playerX - actualPlayerSpeed * Time.deltaTime, playerY, 0);
            sprRender.flipX = false;
        }
        if (Input.GetKey(KeyCode.D)) // right movement
        {

         playerX = transform.position.x;
         playerY = transform.position.y;
            player.position = new Vector3(playerX + actualPlayerSpeed * Time.deltaTime, playerY, 0);
            sprRender.flipX = true;
        }
        if (Input.GetKey(KeyCode.Space))
            
        {
            Debug.Log(jumping.ToString()+canJump.ToString()+jumpMomentum.ToString());
            if (jumping == false && canJump == true) // conditions to prevent jumping whilst falling (mostly works)
            {
                jumping = true; // sets jumping to true
                Invoke("setJumpingFalse", 0.4f); // 0.4 second interval before jumping = false -- added this because you couldn't jump.
            }
        }
        if (jumping == true)
        {
            jumpMomentum = 3f;
         playerX = transform.position.x;
         playerY = transform.position.y;
            player.position = new Vector3(playerX, playerY + playerSpeed * jumpMomentum * Time.deltaTime, 0); // jumps
            
        }
        // camera scrolling
        if (playerY > 0) {
            pcamera.transform.position = new Vector3(pcamera.transform.position.x, playerY, -10);
        } else if (playerY < 0) {
            pcamera.transform.position = new Vector3(pcamera.transform.position.x, playerY, -10);
        } 
        if (playerX > 0) {
            pcamera.transform.position = new Vector3(playerX, pcamera.transform.position.y, -10);
        } else if (playerX < 0) {
            pcamera.transform.position = new Vector3(playerX, pcamera.transform.position.y, -10);
        } 

        // player falling to death check
        if (playerY < -5 && !dead) {
            playerDeath();
        }

        // move with X platforms
        if (onPlatform && currentPlatform != null)
        {
            // calculate platform movement
            Vector3 platformMovement = currentPlatform.position - lastPlatformPosition;

            // move the player along with the platform
            transform.position += platformMovement;

            // update last known platform position
            lastPlatformPosition = currentPlatform.position;
        }

        if (dead)
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.transform.position = deadpos;
        }
    }

    void LateUpdate() {
        if (collidedObject != null) {
            ogpos = collidedObject.transform.position.x;
        }
    }

    void setJumpingFalse() // sets jumping to false. pretty self explanatory
    {
        jumping = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // player stepped on a platform
        onPlatform = true;
        currentPlatform = collision.transform;
        lastPlatformPosition = currentPlatform.position;
        canJump = true;
        if (collision.gameObject.name.ToLower().Contains("spike")) {
            playerDeath();
        } else if (collision.gameObject.name.ToLower().Contains("gobble")) {
            if (collision.gameObject.transform.position.y + 1 > transform.position.y && collision.gameObject.transform.localScale.y != 2.0f) {
                playerDeath();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ogpos = collision.gameObject.transform.position.x;
        collidedObject = collision.gameObject.transform;
        canJump = true;

    }

    void OnCollisionExit2D(Collision2D collision) {
        collidedObject = null;
        canJump = false;
        ogpos = 0;
        newpos = 0;

        // player left platform
        onPlatform = false;
        currentPlatform = null;
    }

    private void playerDeath() {
        dead = true;
        deadpos = player.transform.position;
        canJump = false;
        particleSystem.Play();
        sprRender.enabled = false;
        Invoke("resetPlayer", 1.0f);
    }

    private void resetPlayer() {
        transform.position = originalposition;
        sprRender.enabled = true;
        jumping = false;
        jumpIncreasing = false;
        canJump = false;
        dead = false;
    }
}