using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class Selector : MonoBehaviour
{
    EquipLoaded eload;

    public Transform[] equipLayout;
    public Image[] equipLayoutSprite;

    int[][] equipmentGrid;
    int row = 0;
    int col = 0;

    int maxRow = 3;
    int maxCol = 2;
    int minRow = 0;
    int minCol = 0;

    private bool m_xAxisInUse = false;
    private bool m_yAxisInUse = false;

    public enum zEquips { nothing, leo, cancer, pisces, scorpius, aquarius, virgo, taurus, gemini, libra, capricorn, aries, sagittarius }
    public zEquips equiped;

    public bool[] equipsGet;

    EquipGet equipGet;

    // Use this for initialization
    void Start()
    {
        equiped = zEquips.nothing;

        eload = FindObjectOfType<EquipLoaded>();
        equipGet = FindObjectOfType<EquipGet>();

        transform.position = equipLayout[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        //equipmentGrid[row][col] = 0;

        if (Input.GetAxisRaw("Vertical") > 0) // W
        {
            if(m_yAxisInUse == false)
            {
                if (col > minCol)
                    col--;

                Debug.Log(col);

                m_yAxisInUse = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) // A
        {
            if(m_xAxisInUse == false)
            {
                if(row > minRow)
                    row--;

                Debug.Log(row);

                m_xAxisInUse = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0) // S
        {
            if (m_yAxisInUse == false)
            {
                if (col < maxCol)
                    col++;

                Debug.Log(col);

                m_yAxisInUse = true;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0) // D
        {
            if (m_xAxisInUse == false)
            {
                if(row < maxRow)
                    row++;

                Debug.Log(row);

                m_xAxisInUse = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0)
            m_yAxisInUse = false;
        if (Input.GetAxisRaw("Horizontal") == 0)
            m_xAxisInUse = false;

        if(equipGet.equipGot[5])
        {
            equipLayoutSprite[5] = (Image)AssetDatabase.LoadAssetAtPath("Assets/Sprite/LeoClaws.png", typeof(Image));
        }

        if      (row == 0 && col == 0)
            transform.position = equipLayout[0].position;
        else if (row == 1 && col == 0)
            transform.position = equipLayout[1].position;
        else if (row == 2 && col == 0)
            transform.position = equipLayout[2].position;
        else if (row == 3 && col == 0)
            transform.position = equipLayout[3].position;
        else if (row == 0 && col == 1)
            transform.position = equipLayout[4].position;
        else if (row == 1 && col == 1)
            transform.position = equipLayout[5].position;
        else if (row == 2 && col == 1)
            transform.position = equipLayout[6].position;
        else if (row == 3 && col == 1)
            transform.position = equipLayout[7].position;
        else if (row == 0 && col == 2)
            transform.position = equipLayout[8].position;
        else if (row == 1 && col == 2)
            transform.position = equipLayout[9].position;
        else if (row == 2 && col == 2)
            transform.position = equipLayout[10].position;
        else if (row == 3 && col == 2)
            transform.position = equipLayout[11].position;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if      (row == 0 && col == 0 && equipGet.equipGot[0]  == true)
                equiped = zEquips.leo;
            else if (row == 1 && col == 0 && equipGet.equipGot[1]  == true)
                equiped = zEquips.cancer;
            else if (row == 2 && col == 0 && equipGet.equipGot[2]  == true)
                equiped = zEquips.pisces;
            else if (row == 3 && col == 0 && equipGet.equipGot[3]  == true)
                equiped = zEquips.scorpius;
            else if (row == 0 && col == 1 && equipGet.equipGot[4]  == true)
                equiped = zEquips.aquarius;
            else if (row == 1 && col == 1 && equipGet.equipGot[5]  == true)
                equiped = zEquips.virgo;
            else if (row == 2 && col == 1 && equipGet.equipGot[6]  == true)
                equiped = zEquips.taurus;
            else if (row == 3 && col == 1 && equipGet.equipGot[7]  == true)
                equiped = zEquips.gemini;
            else if (row == 0 && col == 2 && equipGet.equipGot[8]  == true)
                equiped = zEquips.libra;
            else if (row == 1 && col == 2 && equipGet.equipGot[9]  == true)
                equiped = zEquips.capricorn;
            else if (row == 2 && col == 2 && equipGet.equipGot[10] == true)
                equiped = zEquips.aries;
            else if (row == 3 && col == 2 && equipGet.equipGot[11] == true)
                equiped = zEquips.capricorn;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
            equiped = zEquips.nothing;
    }
}
