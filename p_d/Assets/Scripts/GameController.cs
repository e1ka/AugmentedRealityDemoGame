using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class GameController : MonoBehaviour {

    [Header("Controllers")]
    public AugmentedRealityController augmentedController;
    public BoardController boardController;
    public RabbitPathController pathController;
    [Header("Canvas")]
    public Canvas startCanvas;
    public Canvas endCanvas;
    [Header("Board Set Up")]
    public int boardSize = 4;

    Transform corner1, corner2,  corner3, corner4;
    bool isBoardSetUp;

    void Start()
    {
        NewGame();
        pathController.size = boardSize;
    }
    void Update()
    {
        if (!isBoardSetUp && augmentedController.CheckCornersMarkers())
        {
            isBoardSetUp = true;
            augmentedController.GetTransforms(ref corner1, ref corner2, ref corner3, ref corner4);
            boardController.SetUpBoard(corner1.position, corner2.position, corner3.position, corner4.position, boardSize, corner1);
            startCanvas.gameObject.SetActive(true);
        }
        else if(isBoardSetUp && !augmentedController.CheckCornersMarkers())
        {
            isBoardSetUp = false;
            boardController.CleanUpBoard();
            startCanvas.gameObject.SetActive(false);
        }
        if (!endCanvas.isActiveAndEnabled && pathController.isAnimationFinished)
        {
            endCanvas.gameObject.SetActive(true);
            Text endText = endCanvas.GetComponent<Text>();
            if (pathController.isWin)
                endText.text = "GOOD JOB";
            else
                endText.text = "TRY AGAIN";
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown("return"))
        {
            ButtonStart();
        }
    }
    public void NewGame()
    {
        isBoardSetUp = false;
        corner1 = null;
        corner2 = null;
        corner3 = null;
        corner4 = null;
        endCanvas.gameObject.SetActive(false);
        startCanvas.gameObject.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ButtonStart()
    {
        boardController.HideCheckMarkers();
        pathController.FindTheWay();
        pathController.Animate(corner1);
        startCanvas.gameObject.SetActive(false);
    }  
}
