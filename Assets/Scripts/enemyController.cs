using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

    public Transform[] pathPoints;
    public float moveSpeed;
    public GameObject spriteHolder;
    public Sprite spriteRightMovement;
    public Sprite topMovement;

    private int currentPoint;
    private SpriteRenderer sprHoldRend;
    // Use this for initialization
    void Start()
    {

        transform.position = pathPoints[0].position;
        currentPoint = 0;
        sprHoldRend = spriteHolder.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 actualPos = pathPoints[currentPoint].position;
        if (transform.position == pathPoints[currentPoint].position)
        {
            currentPoint += 1;

        }

        if (currentPoint >= pathPoints.Length)
        {
            currentPoint = 0;

        }

        var heading =  pathPoints[currentPoint].position - actualPos;
        var direction = heading / heading.magnitude;

        if(direction.x >= 0)
        {
            sprHoldRend.sprite = spriteRightMovement;
            sprHoldRend.flipX = false;
        }else if(direction.x < 0)
        {
            sprHoldRend.sprite = spriteRightMovement;
            sprHoldRend.flipX = true;
        }else if(direction.y > 0)
        {
            sprHoldRend.sprite = topMovement;
        }
        else
        {
            sprHoldRend.sprite = spriteRightMovement;
        }


        //Moverse hasta tal punto
        transform.position = Vector2.MoveTowards(transform.position, pathPoints[currentPoint].position, moveSpeed * Time.deltaTime);

    }
}
