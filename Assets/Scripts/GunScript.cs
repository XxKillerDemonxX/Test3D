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


// == Results from bdsmtest.org == 
// 91% Vanilla 
// 21% Submissive 
// 6% Exhibitionist 
// 5% Dominant 
// 2% Rope bunny 
// 0% Experimentalist 
// 0% Daddy/Mommy 
// 0% Rigger 
// 0% Ageplayer 
// 0% Brat 
// 0% Brat tamer 
// 0% Degrader 
// 0% Degradee 
// 0% Boy/Girl 
// 0% Masochist 
// 0% Master/Mistress 
// 0% Non-monogamist 
// 0% Owner 
// 0% Primal (Hunter) 
// 0% Pet 
// 0% Primal (Prey) 
// 0% Sadist 
// 0% Slave 
// 0% Switch 
// 0% Voyeur 

