using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DominacionStart : MonoBehaviour
{
    void Start()
    {
        //Создание секторов
        for (float i = 1, Qy = 0f, Ox=0, r=-1; i <= 60f; i++)
        {
            if (i == 1)
            {
                Vector3 vector3 = new Vector3(-9.25f, 0, 4.25f);
                CreateSector(i, vector3);
                r++;
                Ox = 0;
                continue;
            }
            if (i <= 18)
            {
                Vector3 vector3 = new Vector3 (-8f+Ox, 0f, 4.25f);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
            if (i == 19)
            {
                Vector3 vector3 = new Vector3(9.25f, 0, 4.25f);
                CreateSector(i, vector3);
                Qy += 90;
                Ox = 0;
                r++;
                continue;
            }
            if (i <= 27)
            {
                Vector3 vector3 = new Vector3(9.25f, 0f, 3f-Ox);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
            if (i == 28)
            {
                Vector3 vector3 = new Vector3(9.25f, 0, -4.25f);
                CreateSector(i, vector3);
                Qy += 90;
                Ox = 0;
                r++;
                continue;
            }
            if (i <= 45)
            {
                Vector3 vector3 = new Vector3(8f-Ox, 0f, -4.25f);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
            if (i == 52)
            {
                Vector3 vector3 = new Vector3(-9.25f, 0, -4.25f);
                CreateSector(i, vector3);
                Qy += 90;
                Ox = 0;
                r++;
                continue;
            }
            if (i <= 60)
            {
                Vector3 vector3 = new Vector3(-9.25f, 0f, -3f+Ox);
                CreateSector(i, Qy, vector3, r);
                Ox++;
                continue;
            }
        }
    }


    void CreateSector(float i, float Qy, Vector3 vector3, float r)
    {
        GameObject obgectName = Instantiate(GameObject.Find("Rect"), vector3, new Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name-{i} Vector-{obgectName.transform.position} Quaternion-{obgectName.transform.rotation}");
        obgectName.transform.Rotate(0f, 90f*r, 0f);
        obgectName.name = i.ToString();
    }
    void CreateSector(float i, Vector3 vector3)
    {
        GameObject obgectName = Instantiate(GameObject.Find("Square"), vector3, new Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name: {i} Vector: {obgectName.transform.position} Quaternion: {obgectName.transform.rotation}");
        obgectName.name = i.ToString();
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
