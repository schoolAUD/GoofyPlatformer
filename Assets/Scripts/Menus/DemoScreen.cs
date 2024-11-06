using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

// handles the "demo" screen, very simple
public class DemoScreen : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true); // shows the panel on start
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void buttonClicked() // ooh, fancy! a function!
    {
        // just something that I want to put here, you define an onclick WITHIN UNITY. It's so odd, and a completely alien process to me. LET ME DO BUTTON.ONCLICK += <function>!!!! (that's deprecated)
        panel.SetActive(false);
    }

    public void buttonClicked2() // ooh, fancy! a function!
    {
        SceneManager.LoadScene(0);
    }
}
