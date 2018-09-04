using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject boardField;
    public GameObject[,] fields;
    public Vector3[,] positions;
    int size;

    public void SetUpBoard(Vector3 c1Pos, Vector3 c2Pos, Vector3 c3Pos, Vector3 c4Pos, int _size, Transform parent)
    {
        size = _size;
        positions = new Vector3[size, size];
        for (int i = 0; i < size; i++)
        {
            positions[i, i] = CalculatePositionBetween(c1Pos, c4Pos, size, i);
            positions[i, size - 1 - i] = CalculatePositionBetween(c2Pos, c3Pos, size, i);
        }
        for (int i = 0; i < size - 2; i += 2)
        {
            c1Pos = positions[i / 2, i / 2];
            c2Pos = positions[i / 2, size - 1 - i / 2];
            c3Pos = positions[size - 1 - i / 2, i / 2];
            c4Pos = positions[size - 1 - i / 2, size - 1 - i / 2];
            for (int j = 0; j < size - 2 - i; j++)
            {
                positions[i / 2, i / 2 + j + 1] = CalculatePositionBetween(c1Pos, c2Pos, size - 2 - i, j);
                positions[size - 1 - i / 2, i / 2 + j + 1] = CalculatePositionBetween(c3Pos, c4Pos, size - 2 - i, j);
                positions[i / 2 + j + 1, i / 2] = CalculatePositionBetween(c1Pos, c3Pos, size - 2 - i, j);
                positions[i / 2 + j + 1, size - 1] = CalculatePositionBetween(c2Pos, c4Pos, size - 2 - i, j);
            }
        }
        InstantiateBoardFields(boardField, parent);
    }
    public void CleanUpBoard()
    {
        foreach (GameObject obj in fields)
        {
            Destroy(obj);
        }
    }
    public void HideCheckMarkers()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("CheckField"))
        {
            o.SetActive(false);
        }
    }
    private Vector3 CalculatePositionBetween(Vector3 a, Vector3 b, int _size, int n)
    {
        return (b - a) * (1 + n) / (_size + 1) + a;
    }
    private void InstantiateBoardFields(GameObject boardField, Transform parent)
    {
        fields = new GameObject[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                    fields[i, j] = Instantiate(boardField, positions[i, j], parent.rotation, parent);
            }
        }
    }
    public void InstantiateField(int row, int col, Transform parent)
    {
        Instantiate(boardField, positions[row,col], new Quaternion(0f,0f,0f,0f), parent);
    }
}
