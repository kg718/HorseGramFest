using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private bool constantDirection = true;

    [Space]
    [SerializeField] private float Speed;
    [Header("Constant Direction")]
    [SerializeField] private Vector3 direction;

    [Header("Listed Positions")]
    [SerializeField] private List<Vector3> Positions;
    private int CurrentPosition;

    [SerializeField] private float Delay;
    private float CurrentDelay;
    private bool Moving;
    private bool HasWaited = false;

    void Start()
    {
        CurrentPosition = 0;
        Moving = false;
        CurrentDelay = Delay;
        if (constantDirection)
        {
            Moving = true;
        }
    }

    void Update()
    {
        if (constantDirection)
        {

        }
        else
        {
            if (DelayMove())
            {
                if (Vector3.Distance(transform.position, Positions[CurrentPosition]) < 1)
                {
                    if (CurrentPosition >= Positions.Count - 1)
                    {
                        CurrentPosition = 0;
                    }
                    else
                    {
                        CurrentPosition += 1;
                    }
                    if (!HasWaited)
                    {
                        HasWaited = true;
                        Halt();
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (Moving && !constantDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, Positions[CurrentPosition], Speed);
            HasWaited = false;
        }
        if (constantDirection)
        {
            transform.position += new Vector3(direction.x * Speed, direction.y * Speed, direction.z * Speed);
        }
    }

    private bool DelayMove()
    {
        if (CurrentDelay <= 0)
        {
            Moving = true;
            return true;
        }
        else
        {
            CurrentDelay -= Time.deltaTime;
            return false;
        }
    }

    private void Halt()
    {
        Moving = false;
        CurrentDelay = Delay;
    }
}
