using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairColorGrid : MonoBehaviour
{
    [SerializeField] private Color color;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = color;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = Color.white;
    }


}
