using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMeshCollider : MonoBehaviour
{
    List<MeshFilter> meshFilters = new List<MeshFilter>();
    // Start is called before the first frame update
    void Start()
    {
        addMeshColliders(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addMeshColliders(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.GetComponent<MeshFilter>() != null)
            {
                meshFilters.Add(child.GetComponent<MeshFilter>());
                child.gameObject.AddComponent<MeshCollider>().convex = true;
                Mesh mesh = child.GetComponent<MeshFilter>().sharedMesh;
                child.gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
            }
            addMeshColliders(child);
        }
    }
}
