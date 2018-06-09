using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    RectTransform rTransform;
    EquipLoaded eload;

    int[][] equipmentGrid;
    int row = 0;
    int col = 0;

    int maxRow = 3;
    int maxCol = 2;
    int minRow = 0;
    int minCol = 0;

    private bool m_xAxisInUse = false;
    private bool m_yAxisInUse = false;


    // Use this for initialization
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        eload = FindObjectOfType<EquipLoaded>();
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

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if      (row == 0 && col == 0)
                eload.zodiacWeapon[0] =  true;
            else if (row == 1 && col == 0)
                eload.zodiacWeapon[1] =  true;
            else if (row == 2 && col == 0)
                eload.zodiacWeapon[2] =  true;
            else if (row == 3 && col == 0)
                eload.zodiacWeapon[3] =  true;
            else if (row == 0 && col == 1)
                eload.zodiacWeapon[4] =  true;
            else if (row == 1 && col == 1)
                eload.zodiacWeapon[5] =  true;
            else if (row == 2 && col == 1)
                eload.zodiacWeapon[6] =  true;
            else if (row == 3 && col == 1)
                eload.zodiacWeapon[7] =  true;
            else if (row == 0 && col == 2)
                eload.zodiacWeapon[8] =  true;
            else if (row == 1 && col == 2)
                eload.zodiacWeapon[9] =  true;
            else if (row == 2 && col == 2)
                eload.zodiacWeapon[10] = true;
            else if (row == 3 && col == 2)
                eload.zodiacWeapon[11] = true;
        }
    }
}
