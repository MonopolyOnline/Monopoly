using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static System.Random random = new System.Random();
    //Player player = new Player();
    //int num = 0;
    //string[] players = new string[4] { "Player 1", "Player 2", "Player 3", "Player 4" };
    //int posicion = 0; 

    GameObject[] player = new GameObject[] { GameObject.Find("Player 1"), GameObject.Find("Player 2"), GameObject.Find("Player 3"), GameObject.Find("Player 4") };
    int[] moneyPlayer = new int[] { 1000000, 1000000, 1000000, 1000000 };
    int[] sectorPlayer = new int[] { 0, 0, 0, 0 };
    Dictionary<GameObject, List<string>> play = new Dictionary<GameObject, List<string>>();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sectorPlayer[1] += random.Next(1, 6);
            if (sectorPlayer[1] > 40)
                sectorPlayer[1] -= 40;
            player[1].transform.position = GameObject.Find(Convert.ToString(sectorPlayer[1])).transform.position;
        }


        //6 анимаций кубика
        //постройка зданий
        //модели зданий
        //проработать стоймость
        //придумать локальные события

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


}