using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using static DominacionStart.Players;

public class DominacionStart : MonoBehaviour
{
    static System.Random random = new System.Random();
    Player1 player1 = new Player1();
    Player2 player2 = new Player2();



    void Start()
    {
        Create();
    }
    private void FixedUpdate()
    {
        if (player1.move)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player1.sector += Random.Range(1, 6);
                if (player1.sector > 60)
                    player1.sector -= 60;
                player1.gameObject.transform.position = GameObject.Find(player1.sector.ToString()).transform.position;
                player1.move = false;
                player2.move= true;
            }
            return;
        }

        if (player2.move)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player2.sector += Random.Range(1, 6);
                if (player2.sector > 60)
                    player2.sector -= 60;
                player2.gameObject.transform.position = GameObject.Find(player2.sector.ToString()).transform.position;
                player2.move = false;
                player1.move = true;
            }
        }
    }


    void Create()
    {
        //Создание основы
        GameObject basis = Instantiate(GameObject.Find("BasisCopy"), new UnityEngine.Vector3(0,0,0), new UnityEngine.Quaternion(0, 0, 0, 0));
        basis.name = "Basis";
        //Создание фона
        GameObject backgroundCopy = Instantiate(GameObject.Find("BackgroundCopy"), new UnityEngine.Vector3(0, 0.05f, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        backgroundCopy.name = "Background";
        //Создание игроков
        GameObject play = Instantiate(GameObject.Find("Play"), new UnityEngine.Vector3(-9f, 0f, 4f), new UnityEngine.Quaternion(0, 0, 0, 0));
        play.name = "Play 1";
        play = Instantiate(GameObject.Find("Play"), new UnityEngine.Vector3(-9f, 0f, 4f), new UnityEngine.Quaternion(0, 0, 0, 0));
        play.name = "Play 2";
        //Создание секторов
        for (float i = 1, Qy = 0f, Ox = 0f, r = -1; i <= 52f; i++)
        {
            if (i == 1)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3 (-9.25f, 0f, 4.25f);
                CreateSector(i, vector3);
                r++;
                Ox = 0;
                continue;
            }
            if (i <= 18)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3 (-8f + Ox, 0f, 4.25f);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
            if (i == 19)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(9.25f, 0, 4.25f);
                CreateSector(i, vector3);
                Qy += 90;
                Ox = 0;
                r++;
                continue;
            }
            if (i <= 26)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(9.25f, 0f, 3f - Ox);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
            if (i == 27)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(9.25f, 0f, -4.25f);
                CreateSector(i, vector3);
                Qy += 90;
                Ox = 0;
                r++;
                continue;
            }
            if (i <= 44)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(8f - Ox, 0f, -4.25f);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
            if (i == 45)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-9.25f, 0f, -4.25f);
                CreateSector(i, vector3);
                Qy += 90;
                Ox = 0;
                r++;
                continue;
            }
            if (i <= 52)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-9.25f, 0f, -3f + Ox);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
        }
    }
    void CreateSector(float i, float Qy, UnityEngine.Vector3 vector3, float r)
    {
        GameObject obgectName = Instantiate(GameObject.Find("RectCopy"), vector3, new UnityEngine.Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name-{i} Vector-{obgectName.transform.position} Quaternion-{obgectName.transform.rotation}");
        obgectName.transform.Rotate(0f, 90f * r, 0f);
        obgectName.name = i.ToString();
    }
    void CreateSector(float i, UnityEngine.Vector3 vector3)
    {
        GameObject obgectName = Instantiate(GameObject.Find("SquareCopy"), vector3, new UnityEngine.Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name: {i} Vector: {obgectName.transform.position} Quaternion: {obgectName.transform.rotation}");
        obgectName.name = i.ToString();
    }

    public class Players
    {
        public class Player1
        {
            public GameObject gameObject = GameObject.Find("Play 1");
            public int money = 10000000;
            public int sector = 0;
            public bool move = true;
        }

        public class Player2
        {
            public GameObject gameObject = GameObject.Find("Play 2");
            public int money = 10000000;
            public int sector = 0;
            public bool move = true;
        }
    }


    /*
     using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class DominacionStart : MonoBehaviour
{
    void Start()
    {
        //Создание квадратных секторов
        Instantiate(GameObject.Find("Square"), new Vector3(9.25f, 0, 4.25f), new Quaternion(0, 0, 0, 0));
        Instantiate(GameObject.Find("Square"), new Vector3(9.25f, 0, -4.25f), new Quaternion(0, 0, 0, 0));
        Instantiate(GameObject.Find("Square"), new Vector3(-9.25f, 0, -4.25f), new Quaternion(0, 0, 0, 0));



        //Создание обычных секторов
        for (float i = 1, Ox = -8f, Oy = 0, Oz = 4.25f, Qy = 0f; i <= 53f; i++, Ox++)
        {
            GameObject obgectName;
            Vector3 vector3;
            if ( i == 1)
            {
                obgectName = Instantiate(GameObject.Find("Square"), new Vector3(-9.25f, 0, 4.25f), new Quaternion(0, 0, 0, 0));
                Debug.Log($"Create: Name-{obgectName.name} Vector-{obgectName.transform.position} Quaternion-{obgectName.transform.rotation}");
                obgectName.name = i.ToString();
                continue;
            }
            if (i <= 15)
            {
                vector3 = (-9.25f, 0, 4.25f);
                CreateSector(i, Qy, vector3);
                continue;
            }
            if (i == 16)
            {
                obgectName = Instantiate(GameObject.Find("Square"), new Vector3(-9.25f, 0, 4.25f), new Quaternion(0, 0, 0, 0));
                Debug.Log($"Create: Name-{obgectName.name} Vector-{obgectName.transform.position} Quaternion-{obgectName.transform.rotation}");
                obgectName.name = i.ToString();
                Qy += 90;
                continue;
            }
            if (i <= 23)
            {
                vector3 = (9.25f, 0, 4.25f);
                CreateSector(i, Qy, vector3);
                continue;
            }
            if (i == 24)
            {
                obgectName = Instantiate(GameObject.Find("Square"), new Vector3(-9.25f, 0, 4.25f), new Quaternion(0, 0, 0, 0));
                Debug.Log($"Create: Name-{obgectName.name} Vector-{obgectName.transform.position} Quaternion-{obgectName.transform.rotation}");
                obgectName.name = i.ToString();
                Qy += 90;
                continue;
            }
            if (i <= 38)
            {
                vector3 = (9.25f, 0, -4.25f);
                CreateSector(i, Qy, vector3);
                continue;
            }
            if (i == 39)
            {
                obgectName = Instantiate(GameObject.Find("Square"), new Vector3(-9.25f, 0, 4.25f), new Quaternion(0, 0, 0, 0));
                Debug.Log($"Create: Name-{obgectName.name} Vector-{obgectName.transform.position} Quaternion-{obgectName.transform.rotation}");
                obgectName.name = i.ToString();
                Qy += 90;
                continue;
            }
            if (i <= 46)
            {
                vector3 = (-9.25f, 0, -4.25f);
                CreateSector(i, Qy, vector3);
                continue;
            }
        }

        void CreateSector(float i, float Qy, Vector3 vector3)
        {
            GameObject obgectName = Instantiate(GameObject.Find("Rect"), vector3, (0, 0, 0, 0));
            Debug.Log($"Create: Name-{obgectName.name} Vector-{obgectName.transform.position} Quaternion-{obgectName.transform.rotation}");
            obgectName.name = i.ToString();
        }
    }

}

     */
}
