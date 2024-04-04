using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{

    [SerializeField] private Image[] uiImages;
    private int index;

    [SerializeField] private Sprite moving;
    [SerializeField] private Sprite shooting;
    private Sprite defaultSprite;

    [SerializeField] private CowboyMovement[] players;

    private int playerIndex;

    [SerializeField] private GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = uiImages[0].sprite;
        index = 0;

        playerIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMove()
    {
        uiImages[index].sprite = moving;
        index++;
    }

    public void AddShooting()
    {
        uiImages[index].sprite = shooting;
        index++;
    }

    public void ClearMoves()
    {
        index = 0;

        foreach (var image in uiImages)
        {
            image.sprite = defaultSprite;
        }
    }

    public void EndTurn()
    {
        Debug.Log("End turn called");
        players[playerIndex].ToggleMoving(false);
        Debug.Log($"Player {playerIndex + 1} turn ended");
        playerIndex++;

        if (playerIndex < players.Length)
        {

            Debug.Log($"Player {playerIndex + 1} turn started");
            players[playerIndex].ToggleMoving(true);
        }
        else
            PlayOutTurns();
    }

    private void PlayOutTurns()
    {
        crosshair.SetActive(false);
        foreach (CowboyMovement player in players)
        {
            player.PlayTurnOut();
        }

        Invoke("ResetRound", 4);
    }

    private void ResetRound()
    {
        playerIndex = 0;
        players[playerIndex].ToggleMoving(true);
        Debug.Log($"Player {playerIndex + 1} turn started");
        crosshair.SetActive(true);
    }
}
