using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private bool following;
    private Transform followTarget;
    private Vector3 defaultPosition;
    private float defaultSize;

    [SerializeField] private Transform testTarget;

    // Start is called before the first frame update
    void Start()
    {
        following = false;
        defaultPosition = transform.position;
        Debug.Log(defaultPosition);
        defaultSize = GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.X)))
        {
            if(!following) 
            {
                following = true;
                followTarget = testTarget;
                GetComponent<Camera>().orthographicSize = 50;
            }
            else
            {
                following = false;
                transform.position = defaultPosition;
                GetComponent<Camera>().orthographicSize = defaultSize;
            }
            
        }


        if (following)
        {
            transform.position = new Vector3(followTarget.position.x, followTarget.position.y, -10);
            
        }


    }

    public void FollowTarget(Transform target)
    {
        following = true;
        GetComponent<Camera>().orthographicSize = 50;
        followTarget = target;
    }

    public void StopFollowing()
    {
        following = false;
        GetComponent<Camera>().orthographicSize = defaultSize;
        transform.position = defaultPosition;
    }
}
