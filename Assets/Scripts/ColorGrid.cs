using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGrid : MonoBehaviour
{
    [SerializeField] private Color color;
    private List<SpriteRenderer> tilesLit;
    private bool display;


    // Start is called before the first frame update
    void Start()
    {
        tilesLit = new List<SpriteRenderer>();
        display = true;
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        if (display)
        {
            //Debug.Log(collision);
            tilesLit.Add(collision.GetComponent<SpriteRenderer>());

            collision.GetComponent<SpriteRenderer>().color = color;
        }
    }

    public void ClearTiles()
    {
        
        foreach (SpriteRenderer tile in tilesLit) 
        {
            tile.color = Color.white;
        }
        tilesLit = new List<SpriteRenderer>();
    }

    public void ToggleDisplay(bool toggle) => display = toggle;
}
