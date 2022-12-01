//using System;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    static System.Random random = new System.Random();
//    int num = 0;
//    string[] players = new string[4] { "Player 1", "Player 2", "Player 3", "Player 4" };
//    int posicion = 0;

//    GameObject[] play = new GameObject[] { GameObject.Find("Player 1"), GameObject.Find("Player 2"), GameObject.Find("Player 3"), GameObject.Find("Player 4") };
//    int[] sectorPlayer = new int[] { 0, 0, 0, 0 };

//    void Update()
//    {
//        if (Input.GetKey(KeyCode.Space))
//        {
//            sectorPlayer[1] += random.Next(1, 6);
//            if (sectorPlayer[1] > 40)
//                sectorPlayer[1] -= 40;
//            play[1].transform.position = GameObject.Find(Convert.ToString(sectorPlayer[1])).transform.position;
//        }


//        //6 анимаций кубика
//        //постройка зданий
//        //модели зданий
//        //проработать стоймость
//        //придумать локальные события

//    }  
//}