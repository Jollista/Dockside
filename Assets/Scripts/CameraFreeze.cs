using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeze : MonoBehaviour
{
    public GameObject followObject; //target object to follow
    public float speed = 10f; //How fast camera will chase after followObject
    public Vector2 bordersBL; //negative, bottom and left
    public Vector2 bordersUR; //positive, up and right

    // Start is called before the first frame update
    void Start()
    {
        Vector2 follow = followObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //sets target position to move camera to position of followObject
        Vector2 follow = followObject.transform.position;
        Vector3 moveTo = transform.position;

        //guarantee target position is within borders
        moveTo.x = Mathf.Clamp(follow.x, bordersBL.x, bordersUR.x);
        moveTo.y = Mathf.Clamp(follow.y, bordersBL.y, bordersUR.y);
        transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
    }

    // Draws a box to represent location of camera borders
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Vector2 pos = new Vector2(transform.position.x+(bordersUR.x+bordersBL.x)/2, transform.position.y+bordersUR.y+bordersBL.y);
        Gizmos.DrawWireCube(pos, new Vector3(Mathf.Abs(bordersUR.x) + Mathf.Abs(bordersBL.x), Mathf.Abs(bordersUR.y) + Mathf.Abs(bordersBL.y), 1));
    }
}