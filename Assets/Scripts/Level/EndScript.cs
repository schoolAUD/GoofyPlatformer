using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public int nextLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player") {
            SceneManager.LoadScene(nextLevel);
            PlayerPrefs.SetInt("currentLevel", nextLevel-2);
        }
    }
}
