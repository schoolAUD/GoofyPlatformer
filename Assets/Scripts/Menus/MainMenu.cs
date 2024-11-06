using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// handles the main menu, again really simple, because Unity does a lot of the lifting for me

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startClicked()
    {
        SceneManager.LoadScene(1); // wow, so long and complicated
    }
}
