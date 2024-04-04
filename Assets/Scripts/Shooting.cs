using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    private LineRenderer lineRenderer;

    [SerializeField] private GameObject cowboyClone;
    private bool display;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private TurnManager turnManager;

    private Vector2 clonePosition;
    private Vector2 enemyPosition;
    private Vector2 fromCloneToCrosshair;
    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        display = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(display)
        {
            lineRenderer.enabled = true;

            if (!cowboyClone.activeSelf && display)
                lineRenderer.SetPositions(new Vector3[] { transform.position, crosshair.transform.position });


            if (Input.GetKeyDown(KeyCode.E) && !cowboyClone.activeSelf) 
            {
                //GameObject bulletTemp = Instantiate(bullet);
                //bulletTemp.transform.position = playerPosition;
                //bulletTemp.GetComponent<Rigidbody2D>().velocity = velocity;

                cowboyClone.SetActive(true);
                cowboyClone.transform.position = transform.position;
                lineRenderer.SetPositions(new Vector3[] { cowboyClone.transform.position, crosshair.transform.position });

                clonePosition = cowboyClone.transform.position;
                enemyPosition = crosshair.transform.position;
                fromCloneToCrosshair = enemyPosition - clonePosition;

                // Normalize it to length 1
                fromCloneToCrosshair.Normalize();

                velocity = fromCloneToCrosshair * bulletSpeed;


                turnManager.AddShooting();
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    public void ResetShooting()
    {
        cowboyClone.SetActive(false);
    }

    public void Shoot()
    {
        GameObject bulletTemp = Instantiate(bullet);
        bulletTemp.transform.position = clonePosition;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        bulletTemp.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        Debug.Log(velocity.x);

        bulletTemp.GetComponent<Rigidbody2D>().velocity = velocity;    
    }

    public void ToggleDisplay(bool toggle) => display = toggle;
}
