using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerSO playerData;
    void Start()
    {
        playerData.camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
