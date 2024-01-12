using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSpawner : MonoBehaviour
{

    public GameObject flashlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            GameObject FlashLightClone= Instantiate(flashlight, new Vector3(1,1,1), Quaternion.identity);
            
        }
    }
}
