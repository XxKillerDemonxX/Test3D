using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : Interactable
{
    private new GameObject player;
    private Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0);
    [SerializeField]
    private GameObject fire;
    private LineRenderer lineRenderer;
    RaycastHit hit;
    private new Camera camera;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            camera = player.GetComponent<Action>().playerData.camera;
            screenCenter = new Vector3(0.5f, 0.5f, 0);
        }
    }

    public override void interactable()
    {
        Ray ray = camera.ViewportPointToRay(screenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log("shot " + hit.collider.gameObject.name);
            Debug.Log("shot " + hit.collider.gameObject.layer);
            Vector3 hitPoint = hit.point;
        }
    }


    public override void setPlayer(GameObject player)
    {
        this.player = player;
    }
    public override void resetPlayer()
    {
        player = null;
    }


    public override float rotationX { get { return 0f; } }
    public override float rotationY { get { return 190f; } }
    public override float rotationZ { get { return 0f; } }



}
