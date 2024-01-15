using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightScript : Interactable
{
    public override float rotationX { get { return 90f; } }
    private static int maxBattery = 100;
    private int currentBattery = maxBattery;
    
    private bool isOn = false;
    public new Light light;
    private Light lightComponent;
    // Start is called before the first frame update
    void Start()
    {
        lightComponent = light.GetComponent<Light>();
        lightComponent.enabled = isOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == true)
        {
            float time = Time.deltaTime;
            if (time >= 5)
            {
                time = 0;
                currentBattery --;
            }
        }
        
    }
    public override void interactable()
    {
        base.interactable();
        Debug.Log("turn flashlight on");
        lightComponent.enabled = !lightComponent.enabled;
        isOn = !isOn;
        //do flashlight thing
    }

}
