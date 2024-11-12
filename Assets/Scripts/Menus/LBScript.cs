using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LBScript : MonoBehaviour
{
    public int number = 1;
    // Start is called before the first frame update
    void Start()
    {
        int num = PlayerPrefs.GetInt("currentLevel");
        if (num < number)
        {
            this.GetComponent<Button>().interactable = false;
        } else
        {
            this.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
