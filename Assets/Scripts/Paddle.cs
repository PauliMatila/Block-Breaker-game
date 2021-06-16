using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config paramaters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    GameSession gameSession;
    Ball ball;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

    //private float GetXPos()
    //{
    //    if (gameSession.IsAutoPlayEnabled())
    //    {
    //        return NearestBall(balls);
    //    }
    //    else
    //    {
    //        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    //    }
    //}

    //private float NearestBall(Ball[] balls)
    //{
    //    SortedDictionary<float, float> ballPositions = SortBallPositions(balls);
    //    return RetrieveNearestBall(ballPositions);
    //}

    //private static float RetrieveNearestBall(SortedDictionary<float, float> ballPositions)
    //{
    //    IEnumerator enumerator = ballPositions.Values.GetEnumerator();
    //    enumerator.MoveNext();

    //    return (float)enumerator.Current;
    //}

    //private SortedDictionary<float, float> SortBallPositions(Ball[] balls)
    //{
    //    float paddleY = gameObject.transform.position.y;

    //    SortedDictionary<float, float> ballPositions = new SortedDictionary<float, float>();
    //    foreach (Ball ball in balls)
    //    {
    //        ballPositions.Add(Math.Abs(ball.transform.position.y - paddleY), ball.transform.position.x);
    //    }

    //    return ballPositions;
    //}
}
