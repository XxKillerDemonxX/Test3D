using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public virtual float rotationX { get { return 0f; } }
    public virtual float rotationY { get { return 0f; } }
    public virtual float rotationZ { get { return 0f; } }
    public virtual GameObject player { get { return null; } }
    public virtual void interactable()
    {

    }
    public virtual void holdInteractable()
    {

    }
    public virtual void endHoldInteractable()
    {
        
    }
    public virtual void setPlayer(GameObject player)
    {

    }
    public virtual void resetPlayer() { }

}
