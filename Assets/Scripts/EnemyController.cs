using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 directionToMove;

    private Rigidbody2D _rigidbody;
    private bool isMoving;

    [Tooltip("Time the enemy takes between successive steps")]
    [SerializeField] private float timeBetweenSteps;
    //Time since the last steps taken by the enemy
    private float timeBetweenStepsCounter;

    [Tooltip("Time it takes for the enemy to take a step")]
    [SerializeField] private float timeToMakeStep;
    //Time the enemy has been taking a step
    private float timeToMakeStepCounter;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep; 

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody.velocity = speed * directionToMove;
            if (timeToMakeStepCounter< 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMove = new Vector2(Random.Range(-1,2), Random.Range(-1, 2));
            }
        }
        
    }
}
