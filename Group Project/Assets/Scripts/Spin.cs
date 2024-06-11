using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public GameObject[] gameObjects;
    private Quaternion helping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.transform.Rotate(0, 20, 0);
        }
        
    }
}
