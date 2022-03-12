using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Transform tr;
    public float distance;
    public Vector3 dir = Vector3.forward;
    public float minspeed;
    public float maxspeed;
    public bool doMove;

    Vector3 move;
    private void Awake()
    {
        tr = GetComponent<Transform>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doMove)
          Move();
    }
    private void Move()
    {
        float movespeed=Random.Range(minspeed, maxspeed);
        move = dir * movespeed * Time.fixedDeltaTime;
        tr.Translate(move);
        distance+=move.magnitude;
    }
}
