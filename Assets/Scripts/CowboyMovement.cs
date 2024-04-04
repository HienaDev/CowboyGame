using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CowboyMovement : MonoBehaviour
{
    [Header("Moves"), SerializeField] private int maxMoves;
    [SerializeField] private string[] legalMoves;
    private List<string> moves;

    [SerializeField] private float timeBetweenMoves;
    private WaitForSeconds wfs;

    private Vector2 position;

    private ColorGrid colorGrid;

    // Start is called before the first frame update
    void Start()
    {
        moves = new List<string>();
        wfs = new WaitForSeconds(timeBetweenMoves);

        position = transform.position;
        Debug.Log(position);

        colorGrid = GetComponent<ColorGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moves.Count < maxMoves) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddMovement("left");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                AddMovement("right");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                AddMovement("down");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                AddMovement("up");
            }
        }
        

        if(Input.GetKeyDown(KeyCode.R)) 
        {
            moves = new List<string>();
            transform.position = position;
            colorGrid.ClearTiles();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = position;
            colorGrid.ToggleDisplay(false);
            colorGrid.ClearTiles();
            StartCoroutine(ExecuteMovesEverySecond());
        }


    }

    public void AddMovement(string move)
    {
        if (legalMoves.Contains(move))
        {
            if(CheckPossibleMove(move))
            {
                moves.Add(move);
                ExecuteMove(true);
            }
        }
    }

    private bool CheckPossibleMove(string move)
    {
        switch (move)
        {
            case "left":
                return((transform.position.x - 48) / 32 >= 0);
            case "right":
                return ((transform.position.x + 48) / 32 <= 10);
            case "down":
                return ((transform.position.y - 48) / 32 >= 0);
            case "up":
                return ((transform.position.y + 48) / 32 <= 10);
            default:
                return false;
        }
    }


    private IEnumerator ExecuteMovesEverySecond()
    {
        while (moves.Count > 0)
        {
            yield return wfs;
            ExecuteMove(false);
            
        }
        position = transform.position;
        colorGrid.ToggleDisplay(true);
    }

    private void ExecuteMove(bool display)
    {
        int index = 0;

        if(display)
        {
            index = moves.Count - 1;
        }

        switch (moves[index])
        {
            case "left":
                transform.position = new Vector2(transform.position.x - 32, transform.position.y);
                break;
            case "right":
                transform.position = new Vector2(transform.position.x + 32, transform.position.y);
                break;
            case "down":
                transform.position = new Vector2(transform.position.x, transform.position.y - 32);
                break;
            case "up":
                transform.position = new Vector2(transform.position.x, transform.position.y + 32);
                break;
            default:
                break;
        }

        Debug.Log("x: " + ((transform.position.x - 16) / 32) + " y: " + (transform.position.y - 16) / 32);

        if (!display)
            moves.Remove(moves[0]);
    }


}
