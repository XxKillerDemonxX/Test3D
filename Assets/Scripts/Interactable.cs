using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public virtual float rotationX { get { return 0f; } }
    public virtual float rotationY { get { return 0f; } }
    public virtual float rotationZ { get { return 0f; } }
    public virtual void interactable()
    {

    }
    // public virtual Mesh CombineChildMeshes()
    // {
    //     MeshFilter[] meshFilters;
    //     for (int i = 0; i < transform.childCount; i ++)
    //     {

    //     }
        
    //     return null;
    // }
}
