using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class EquipLoaded : MonoBehaviour
{
    Image equip;

    public Sprite equipSprite;

    public bool leoOn;

    public bool[] zodiacWeapon;

	// Use this for initialization
	void Start ()
    {
        equip = GetComponent<Image>();

        //equipSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprite/LeoClaws.png", typeof(Sprite));
    }

    // Update is called once per frame
    void Update ()
    {
        equip.sprite = equipSprite;

        if(zodiacWeapon[0] == true)
            equipSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprite/LeoClaws.png", typeof(Sprite));

    }
}
