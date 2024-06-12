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
    public GameObject gun11;
    public GameObject gun22;
    public GameObject gun33;
    public GameObject pressE;
    public bool has_gun1;
    public bool has_gun2;
    public bool has_gun3;
    public GameObject truck;
    public bool follow;
    public Vector3 direction;
    private CharacterController control;
    public bool[] whichGun;
    public float recoilForce = 0;
    public float recoilTimer = 0;
    public float timer = 0;


    // Start is called before the first frame update
    void Start()
    {

        follow = true;
        control = GetComponent<CharacterController>();
        has_gun1 = false;
        has_gun2 = false;
        has_gun3 = false;
       
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        direction = (player.transform.position - root.transform.position);        


        if (Input.GetMouseButtonDown(0) && timer >= recoilTimer)
        {
            Vector3 direction = (player.transform.position - root.transform.position);
            Recoil(true, direction);
            timer = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && has_gun1)
        {
            whichGun[0] = true;
            whichGun[1] = false;
            whichGun[2] = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && has_gun2)
        {
            whichGun[1] = true;
            whichGun[0] = false;
            whichGun[2] = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && has_gun3)
        {
            whichGun[2] = true;
            whichGun[1] = false;
            whichGun[0] = false;
        }
        if(whichGun[0])
        {
            gun1.SetActive(true);
            recoilForce = 3f;
            recoilTimer = 1.0f;
        }else{gun1.SetActive(false);}
        if(whichGun[1])
        {
            gun2.SetActive(true);
            recoilForce = 6f;
            recoilTimer = 2.0f;
        }else{gun2.SetActive(false);}
        if(whichGun[2])
        {
            gun3.SetActive(true);
            recoilForce = 9f;
            recoilTimer = 3.0f;
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
            transform.position = new Vector3(-40, 0, 75);
        }

        bool isCollideWithGun3 = false;
        Collider[] collidersgun3 = Physics.OverlapBox(new Vector3(-117.5f, 1.6f, 74.023f), new Vector3(2, 10, 2), new Quaternion(0, 0, 0, 0));
        foreach (Collider collider in collidersgun3)
        {
            if (collider == GetComponent<BoxCollider>())
            {
                isCollideWithGun3 = true;
                break; // Exit the loop once a matching collider is found
            }
        }
        bool isCollideWithGun2 = false;
        Collider[] collidersgun2 = Physics.OverlapBox(new Vector3(-43.41f, 1.6f, 71.418f), new Vector3(2, 10, 2), new Quaternion(0, 0, 0, 0));
        foreach (Collider collider in collidersgun2)
        {
            if (collider == GetComponent<BoxCollider>())
            {
                isCollideWithGun2 = true;
                break; // Exit the loop once a matching collider is found
            }
        }
        bool isCollideWithGun1 = false;
        Collider[] collidersgun1 = Physics.OverlapBox(new Vector3(-40.97f, 1.343f, 17.697f), new Vector3(2, 10, 2), new Quaternion(0, 0, 0, 0));
        foreach (Collider collider in collidersgun1)
        {
            if (collider == GetComponent<BoxCollider>())
            {
                isCollideWithGun1 = true;
                break; // Exit the loop once a matching collider is found
            }
        }

        if (isCollideWithGun1)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                has_gun1 = true;
                gun11.SetActive(false);
                pressE.SetActive(false);
            }
            if(!has_gun1)
            {
                pressE.SetActive(true);
            }
        }
        else if (isCollideWithGun2)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                has_gun2 = true;
                gun22.SetActive(false);
                pressE.SetActive(false);
            }
            if(!has_gun2)
            {
                pressE.SetActive(true);
            }
        }
        else if (isCollideWithGun3)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                has_gun3 = true;
                gun33.SetActive(false);
                pressE.SetActive(false);
            }
            if(!has_gun3)
            {
                pressE.SetActive(true);
            }

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


