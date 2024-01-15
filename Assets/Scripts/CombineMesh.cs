using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CombineMesh : MonoBehaviour
{
    
    List<MeshFilter> meshFilters = new List<MeshFilter>();

    void Start()
    {
        Vector3 transformOffset = transform.position;
        addMeshColliders(gameObject.transform);
        //MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        //Debug.Log(meshFilters.Length);
        CombineInstance[] combine = new CombineInstance[meshFilters.Count];

        for (int i = 0; i < meshFilters.Count; i ++)
        {
            Quaternion rotationOffset = Quaternion.FromToRotation(transform.eulerAngles, meshFilters[i].transform.eulerAngles);

            meshFilters[i].transform.position -= transformOffset;
            meshFilters[i].transform.rotation = Quaternion.Euler(meshFilters[i].transform.eulerAngles) * Quaternion.Inverse(rotationOffset);


            
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);


            //we already stored the 4x4Matrix in combine[i].transform, so it's safe to change back now
            meshFilters[i].transform.position += transformOffset;
            meshFilters[i].transform.rotation *= rotationOffset;
            
        }
        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine);
        transform.GetComponent<MeshFilter>().sharedMesh = mesh;
        transform.gameObject.SetActive(true);

        GetComponent<MeshCollider>().sharedMesh = transform.GetComponent<MeshFilter>().sharedMesh;
        if (transform.GetComponent<MeshFilter>().sharedMesh == null)
        {
            Debug.Log("Null");
        }
    }



    public void addMeshColliders(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.GetComponent<MeshFilter>() != null)
            {
                meshFilters.Add(child.GetComponent<MeshFilter>());
            }
            addMeshColliders(child);
        }
    }

}
