using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : Interactable
{
    // Start is called before the first frame update
    public override float rotationX { get { return 0f; } }
    public override float rotationY { get { return 190f; } }
    public override float rotationZ { get { return 0f; } }

    private new GameObject player;
    private Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0);
    public GameObject fire;
    public LineRenderer lineRenderer;
    Ray ray;
    RaycastHit hit;
    public new Camera camera;
    //ray.origin = fire.transform.position;
    Vector3 destination;

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
            //ray.origin = fire.transform.position;
            //ray = Camera.main.ScreenPointToRay(screenCenter);
            screenCenter = new Vector3(0.5f, 0.5f, 0);
            destination = camera.transform.forward - fire.transform.position;
            //Debug.Log(destination);
            destination.Normalize();
            ray = new Ray(fire.transform.position, camera.transform.forward);
        }
    }

    public override void interactable()
    {
        //Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        //RaycastHit hit;
        //ray.origin = fire.transform.position;
        int layerMask = ~(LayerMask.GetMask("FireArm") | LayerMask.GetMask("Player"));
        //int layerMask2 = ~LayerMask.GetMask("Player");
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            Debug.Log("shot " + hit.collider.gameObject.name);
            Debug.Log("shot " + hit.collider.gameObject.layer);
            Vector3 hitPoint = hit.point;
            //Debug.DrawRay(fire.transform.position, destination, Color.green);
            lineRenderer.SetPosition(0, fire.transform.position);
            lineRenderer.SetPosition(1, hitPoint);
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
}
