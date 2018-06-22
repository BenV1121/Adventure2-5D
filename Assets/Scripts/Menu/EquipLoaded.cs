using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class EquipLoaded : MonoBehaviour
{
    Image equip;

    public Sprite equipSprite;

    Selector selector;
    MenuManager menuManager;

    public bool canClimb;

	// Use this for initialization
	void Start ()
    {
        equip = GetComponent<Image>();
        menuManager = FindObjectOfType<MenuManager>();

        //equipSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprite/LeoClaws.png", typeof(Sprite));
    }

    // Update is called once per frame
    void Update ()
    {
        equip.sprite = equipSprite;

        if (menuManager.menuOn == true)
            selector = FindObjectOfType<Selector>();
        else
            return;

        if      (selector.equiped == Selector.zEquips.nothing)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.leo)
        {
            canClimb = true;
            equipSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprite/LeoClaws.png", typeof(Sprite));
        }
        else if (selector.equiped == Selector.zEquips.cancer)
        { 
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.pisces)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.scorpius)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.aquarius)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.virgo)
        {
            equipSprite = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Sprite/VirgoRaiment.png", typeof(Sprite));
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.taurus)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.gemini)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.libra)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.capricorn)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.aries)
        {
            equipSprite = null;
            canClimb = false;
        }
        else if (selector.equiped == Selector.zEquips.sagittarius)
        {
            equipSprite = null;
            canClimb = false;
        }
    }
}
