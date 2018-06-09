using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    RectTransform rTransform;

    int[][] equipmentGrid;
    int row;
    int col;

    int maxRow = 3;
    int maxCol = 2;

    // Use this for initialization
    void Start()
    {
        rTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        for (row = 0; row < maxRow; row++)
            for (col = 0; col < maxCol; col++)
                equipmentGrid[row][col] = 0;
    }
}
