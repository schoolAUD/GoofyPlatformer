using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldScript : MonoBehaviour
{
    // this is where it gets longer
    // 7 public integers for modification
    // making my life easier in the long run
    public int World1;
    public int World2;
    public int World3;
    public int World4;
    public int World5;
    public int World6;
    public int World7;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadScene(int scene) // why did I do this? oh yeah it was 5AM
    {
        SceneManager.LoadScene(scene);
    }

    public void world1click() // I noticed later on that I could simplify these a lot more, but oh well, I've done it now
    {
        loadScene(World1);
    }

    public void world2click()
    {
        loadScene(World2);
    }

    public void world3click()
    {
        loadScene(World3);
    }

    public void world4click()
    {
        loadScene(World4);
    }

    public void world5click()
    {
        loadScene(World5);
    }

    public void world6click()
    {
        loadScene(World6);
    }

    public void world7click()
    {
        loadScene(World7);
    }
}
