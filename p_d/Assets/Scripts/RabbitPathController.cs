using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  RabbitPathController : MonoBehaviour {
    public BoardController boardController;
    public GameObject player;
    List<GameObject> theWay = new List<GameObject>();
    public int size;

    Animator anim;
    Coroutine MoveIE;

    public bool isWin, isAnimationFinished;

    #region Finding The Way
    public void FindTheWay()
    {
        GameObject startField = GameObject.FindWithTag("StartField");
        BoardField bf = startField.GetComponent<BoardField>();

        int col = 0, row = 0;
        for (int i = 0; i < boardController.fields.GetLength(0); i++)
        {
            for (int j = 0; j < boardController.fields.GetLength(1); j++)
            {
                if (boardController.fields[i, j] == startField)
                {
                    col = j;
                    row = i;
                }
            }
        }
        theWay.Add(boardController.fields[row, col]);
        FindNextField(row, col, bf.direction);
    }
    private void FindNextField(int _row, int _col, Direction _dir)
    {
        bool jumpOutOfBoard = false;
        Direction dir = _dir;
        int row = _row, col = _col;

        if (dir == Direction.Down)
        {
            if (_row == 0)
                jumpOutOfBoard = true;
            else
                row--;
        }
        else if (dir == Direction.Right)
        {
            if (_col == size - 1)
                jumpOutOfBoard = true;
            else
                col++;
        }
        else if (dir == Direction.Up)
        {
            if (_row == size - 1)
                jumpOutOfBoard = true;
            else
                row++;
        }
        else if (dir == Direction.Left)
        {
            if (_col == 0)
                jumpOutOfBoard = true;
            else
                col--;
        }

        if (jumpOutOfBoard)
        {
            return;
        }
        else
        {
            if (boardController.fields[row, col].tag == "ArrowField" || boardController.fields[row, col].tag == "StartField")
            {
                if (theWay.Contains(boardController.fields[row, col]))
                {
                    return;
                }
                else
                {
                    BoardField bf = boardController.fields[col, row].GetComponent<BoardField>();
                    dir = bf.direction;
                }
            }
            else if (boardController.fields[row, col].tag == "BarrierField")
            {
                return;
            }
            else if (boardController.fields[row, col].tag == "FinishField")
            {
                isWin = true;
                theWay.Add(boardController.fields[row, col]);
                return;
            }
            theWay.Add(boardController.fields[row, col]);
            FindNextField(row, col, dir);
        }

    }
    #endregion
    #region Animation
    public void Animate(Transform parent)
    {
        player = Instantiate(player, theWay[0].transform.position, new Quaternion(0f,0f,0f,0f), parent);
        anim = player.GetComponent<Animator>();
        StartCoroutine(Mover());
    }

    IEnumerator Mover()
    {
        for (int i = 0; i < theWay.Count; i++)
        {
            MoveIE = StartCoroutine(Moving(i));
            yield return MoveIE;
        }
    }
    IEnumerator Moving(int currentIndex)
    {
        while (player.transform.position != theWay[currentIndex].transform.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, theWay[currentIndex].transform.position, Time.deltaTime * 1.0f);
            yield return null;
        }
        if (currentIndex == theWay.Count - 1)
        {
            if (isWin == true)
            {
                anim.Play("WinAnimation");
                isAnimationFinished = true;
            }
            else
            {
                anim.Play("LostAnimation");
                isAnimationFinished = true;
            }
        }

    }
    #endregion
}
