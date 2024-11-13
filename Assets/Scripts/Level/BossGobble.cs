using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossGobble : MonoBehaviour
{
    public GameObject obj;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = obj.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = this.gameObject.transform;
        if (transform.position.y < 100)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f*Time.deltaTime);
        }

        if (player.dead)
        {
            transform.position = new Vector3(transform.position.x, -50);
        }
    }
}
