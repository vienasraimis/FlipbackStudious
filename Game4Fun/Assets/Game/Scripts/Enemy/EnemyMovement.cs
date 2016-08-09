using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{

    public float Speed = 10f;
    public Transform[] WayPoints;

    private Rigidbody2D rigi;
    private int wp = 0;

    void Start()
    {
        if(WayPoints.Length < 2)
        {
            Destroy(gameObject);
            Debug.LogError("There were not enough waypoints");
            return;
        }

        rigi = GetComponent<Rigidbody2D>();

        transform.position = WayPoints[0].position;
        transform.rotation = WayPoints[0].rotation;

        wp = 1;
    }

    void Update()
    {
        RotateToWaypoint();

        Vector3 dir = WayPoints[wp].position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * Speed, Space.World);


        if(Vector3.Distance(transform.position,WayPoints[wp].position) <= 0.2f)
        {
            wp++;
            if (wp == WayPoints.Length) wp = 0;
        }

    }

    private void RotateToWaypoint()
    {

    }
}
