using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject root;
    public GameObject recoiler;
    public bool follow;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

        follow = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        direction = (player.transform.position - root.transform.position);        

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = (root.transform.position - player.transform.position);
            Recoil(true, direction);
        }
    }

    void Recoil(bool recoil, Vector3 direction)
    {
        if (recoil)
        {
            recoiler.GetComponent<Rigidbody>().AddForce(direction * 100f);
            follow = true;
        }
        else
        {
            follow = false;
        }
    }


}
