using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float YMovement = 2.0f;
    public float XMovement = 2.0f;
    public float Speed = 1f;
    
    private float XPos;
    private float YPos;
    private float CurrentXPos;
    private float CurrentYPos;
    private bool movingUp = true;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        XPos = this.transform.position.x;
        YPos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentXPos = this.transform.position.x;
        CurrentYPos = this.transform.position.y;

        // handle horizontal movement
        if (movingRight)
        {
            if (CurrentXPos < XPos + XMovement/2)
            {
                this.transform.position = new Vector3(CurrentXPos + Speed * Time.deltaTime, CurrentYPos);
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            if (CurrentXPos > XPos - XMovement/2)
            {
                this.transform.position = new Vector3(CurrentXPos - Speed * Time.deltaTime, CurrentYPos);
            }
            else
            {
                movingRight = true;
            }
        }

        // handle vertical movement
        if (movingUp)
        {
            if (CurrentYPos < YPos + YMovement/2)
            {
                this.transform.position = new Vector3(CurrentXPos, CurrentYPos + Speed * Time.deltaTime);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (CurrentYPos > YPos - YMovement/2)
            {
                this.transform.position = new Vector3(CurrentXPos, CurrentYPos - Speed * Time.deltaTime);
            }
            else
            {
                movingUp = true;
            }
        }
    }
}
