using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{


    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {

        position = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
 
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AddMovement("left");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AddMovement("right");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AddMovement("down");
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AddMovement("up");
            }
        




    }

    public void AddMovement(string move)
    {

            if (CheckPossibleMove(move))
            {

                ExecuteMove(move);
            }
        
    }

    private bool CheckPossibleMove(string move)
    {
        switch (move)
        {
            case "left":
                return ((transform.position.x - 48) / 32 >= 0);
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



    private void ExecuteMove(string move)
    {

        switch (move)
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


    }

}
