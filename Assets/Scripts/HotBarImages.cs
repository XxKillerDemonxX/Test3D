using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HotBarImages : MonoBehaviour
{
    // Start is called before the first frame update
    public Button slot1;
    public Button slot2;
    public Button slot3;
    public Button slot4;
    private Button[] btnArr = new Button[4];
    public PlayerSO playerData;
    private Texture2D imgTexture;
    //private AssetPreview

    void Start()
    {
        btnArr[0] = slot1;
        btnArr[1] = slot2;
        btnArr[2] = slot3;
        btnArr[3] = slot4;
    }

    // Update is called once per frame
    void Update()
    {   
        //needs to be updated, might not be possible to generate a asset preview image if gameObject is disabled;
        for (int i = 0; i < 4; i ++)
        {
            imgTexture = AssetPreview.GetAssetPreview(playerData.inventory[i]);
            //imgTexture = PrefabUtility.GetIconForGameObject(playerData.inventory[i]);
            //Debug.Log(playerData.inventory[0].name);
            //GUILayout.Label(imgTexture, GUILayout.Width(64), GUILayout.Height(64));


            btnArr[i].GetComponent<Image>().sprite = Sprite.Create(imgTexture, new Rect(0, 0, imgTexture.width, imgTexture.height), new Vector2(0.5f, 0.5f));   
        }
    }
    
}
