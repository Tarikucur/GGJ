using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class TrailCollisions : MonoBehaviour
{
    TrailRenderer myTrail;
    EdgeCollider2D myCollider;
    // Start is called before the first frame update
    void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();
        myCollider = this.GetComponent<EdgeCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        SetColliderPointsFromTrail(myTrail, myCollider);
    }

    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        for(int position = 0; position>trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }
}


