using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject root;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject truck;
    public bool follow;
    public Vector3 direction;
    private CharacterController control;
    public bool[] whichGun;
    public float recoilForce = 0;


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

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            whichGun[0] = true;
            whichGun[1] = false;
            whichGun[2] = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            whichGun[1] = true;
            whichGun[0] = false;
            whichGun[2] = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            whichGun[2] = true;
            whichGun[1] = false;
            whichGun[0] = false;
        }
        if(whichGun[0])
        {
            gun1.SetActive(true);
            recoilForce = 3f;
        }else{gun1.SetActive(false);}
        if(whichGun[1])
        {
            gun2.SetActive(true);
            recoilForce = 6f;
        }else{gun2.SetActive(false);}
        if(whichGun[2])
        {
            gun3.SetActive(true);
            recoilForce = 9f;
        }else{gun3.SetActive(false);}

        // Needed chat gpt's help for this part

        // Assuming you have a collider called 'colliderToCheck'
        bool isColliderInArray = false;
        Collider[] colliders = Physics.OverlapBox(new Vector3(18.62f, 0.0114f, 11.8f), new Vector3(4, 10, 6), new Quaternion(0, 0, 0, 0));
        foreach (Collider collider in colliders)
        {
            if (collider == GetComponent<BoxCollider>())
            {
                isColliderInArray = true;
                break; // Exit the loop once a matching collider is found
            }
        }

        if (isColliderInArray)
        {
            transform.position = new Vector3(-37, 0, 11);
        }

        //helicopter

        bool isColliderInArray1 = false;
        Collider[] colliders1 = Physics.OverlapBox(new Vector3(-122.6f, 0.0f, 14.69f), new Vector3(2, 10, 6), new Quaternion(0, 0, 0, 0));
        foreach (Collider collider in colliders1)
        {
            if (collider == GetComponent<BoxCollider>())
            {
                isColliderInArray1 = true;
                break; // Exit the loop once a matching collider is found
            }
        }

        if (isColliderInArray1)
        {
            transform.position = new Vector3(0, 0, 0);
        }

        void Recoil(bool recoil, Vector3 direction)
        {
            if (recoil)
            {
                control.Move(direction.normalized * recoilForce + new Vector3(0.0f, (direction.y) * recoilForce, 0.0f) * Time.deltaTime);
                follow = true;
            }
            else
            {
                follow = false;
            }
        }
    }

}


