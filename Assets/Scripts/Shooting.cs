using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    private LineRenderer lineRenderer;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 playerPosition = transform.position;
        Vector2 enemyPosition = crosshair.transform.position;
        Vector2 fromPlayerToCrosshair = enemyPosition - playerPosition;

        // Normalize it to length 1
        fromPlayerToCrosshair.Normalize();

        // Set the speed to whatever you want:
        Vector2 velocity = fromPlayerToCrosshair * bulletSpeed;

        lineRenderer.SetPositions(new Vector3[] { transform.position, crosshair.transform.position });

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            GameObject bulletTemp = Instantiate(bullet);
            bulletTemp.transform.position = playerPosition;
            bulletTemp.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }
}
