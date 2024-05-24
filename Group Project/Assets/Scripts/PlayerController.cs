using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject root;
    public bool follow;
    public Vector3 direction;
    private CharacterController control;
    public bool[] whichGun;


    // Start is called before the first frame update
    void Start()
    {


        follow = true;
        control = GetComponent<CharacterController>();
       
    }


    // Update is called once per frame
    void Update()
    {


        direction = (player.transform.position - root.transform.position);        


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = (player.transform.position - root.transform.position);
            Recoil(true, direction);
        }
    }


    void Recoil(bool recoil, Vector3 direction)
    {
        if (recoil)
        {
            control.Move(direction.normalized * 5f + new Vector3(0.0f, (direction.y) * 5f, 0.0f) * Time.deltaTime);
            follow = true;
        }
        else
        {
            follow = false;
        }
    }




}


