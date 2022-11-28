using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }


    private void OnPreCull()
    {
        //for (int i = 1; i < 5; i++)
        //{
        //    if (player[GameObject.Find($"Player {i}")] > 40)
        //    {
        //        player[GameObject.Find($"Player {i}")] -= 40;
        //    }
        //}
    }

    class player
    {
        private GameObject[] gameObjects = new GameObject[]
        {
            GameObject.Find("Player 1"),
            GameObject.Find("Player 2"),
            GameObject.Find("Player 3"),
            GameObject.Find("Player 4"),
        };

        private int[] sector = new int[] { 0, 0, 0, 0 };

        private int[] money = new int[] { 0, 0, 0, 0 };


    }
}
