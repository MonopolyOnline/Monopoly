using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Video : MonoBehaviour
{
    static System.Random random = new System.Random();

    GamePlayer player1 = new GamePlayer("Player 1");
    GamePlayer player2 = new GamePlayer("Player 2");

    [SerializeField] Material colorRed;
    [SerializeField] Material colorBlue;

    [SerializeField] Text balancePlayer1;
    [SerializeField] Text balancePlayer2;

    //[SerializeField] GameObject Arena;
    //[SerializeField] GameObject Basis;
    //[SerializeField] GameObject Background;
    //[SerializeField] GameObject Square;
    //[SerializeField] GameObject Rect;
    [SerializeField] GameObject Player;
    //[SerializeField] GameObject Plus;
    //[SerializeField] GameObject Cube;

    GameObject createObject;

    private void Start()
    {
        Create();
        player1.gameObject = GameObject.Find(player1.goName);
        player1.gameObject.GetComponent<Renderer>().material = colorRed;
        player1.gameObject.transform.position += Offset(player1.goName, player1.sector);
        player2.gameObject = GameObject.Find(player2.goName);
        player2.gameObject.GetComponent<Renderer>().material = colorBlue;
        player2.gameObject.transform.position += Offset(player2.goName, player2.sector);
        //CreateTextureSector();
    }

    private void Update()
    {
        balancePlayer1.text = $"Баланс игрока 1: {player1.money}";
        balancePlayer2.text = $"Баланс игрока 2: {player2.money}";

        if (player1.move)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player1.sector += Random.Range(1, 6);
                Debug.Log(player1.sector);
                if (player1.sector > 52)
                {
                    player1.sector -= 52;
                    player1.circlesCount++;
                    player1.money += 500;
                }
                player1.gameObject.transform.position = GameObject.Find(player1.sector.ToString()).transform.position;
                if (player1.sector == player2.sector)
                {
                    player1.gameObject.transform.position += Offset(player1.goName, player1.sector);
                    player2.gameObject.transform.position += Offset(player2.goName, player2.sector);
                }
                player1.move = false;
                player2.move = true;
            }
            return;
        }

        if (player2.move)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player2.sector += Random.Range(1, 6);
                Debug.Log(player2.sector);
                if (player2.sector > 52)
                {
                    player2.sector -= 52;
                    player2.circlesCount++;
                    player2.money += 500;
                }
                player2.gameObject.transform.position = GameObject.Find(player2.sector.ToString()).transform.position;
                if (player1.sector == player2.sector)
                {
                    player1.gameObject.transform.position += Offset(player1.goName, player1.sector);
                    player2.gameObject.transform.position += Offset(player2.goName, player2.sector);
                }
                player2.move = false;
                player1.move = true;
            }
            return;
        }
    }

    UnityEngine.Vector3 Offset(string goName, int sector)
    {
        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(0, 0, 0);
        switch (goName)
        {
            case "Player 1":
                {
                    if (sector == 1)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0.65f);
                        return vector3;
                    }
                    if (sector <= 18)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0.4f);
                        return vector3;
                    }
                    if (sector == 19)
                    {
                        vector3 = new UnityEngine.Vector3(0.65f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 26)
                    {
                        vector3 = new UnityEngine.Vector3(0.4f, 0, 0);
                        return vector3;
                    }
                    if (sector == 27)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, -0.65f);
                        return vector3;
                    }
                    if (sector <= 44)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, -0.4f);
                        return vector3;
                    }
                    if (sector == 45)
                    {
                        vector3 = new UnityEngine.Vector3(-0.65f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 52)
                    {
                        vector3 = new UnityEngine.Vector3(-0.4f, 0, 0);
                        return vector3;
                    }
                    return vector3;
                }
            case "Player 2":
                {
                    if (sector == 1)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, -0.1f);
                        return vector3;
                    }
                    if (sector <= 18)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, -0.4f);
                        return vector3;
                    }
                    if (sector == 19)
                    {
                        vector3 = new UnityEngine.Vector3(-0.1f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 26)
                    {
                        vector3 = new UnityEngine.Vector3(-0.4f, 0, 0);
                        return vector3;
                    }
                    if (sector == 27)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0.1f);
                        return vector3;
                    }
                    if (sector <= 44)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0.4f);
                        return vector3;
                    }
                    if (sector == 45)
                    {
                        vector3 = new UnityEngine.Vector3(0.1f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 52)
                    {
                        vector3 = new UnityEngine.Vector3(0.4f, 0, 0);
                        return vector3;
                    }
                    return vector3;
                }
            default:
                return vector3;
        }
    }

    private void Create()
    {
        ////Создание основы
        //createObject = Instantiate(Basis, new UnityEngine.Vector3(0, 0, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        //createObject.name = "Basis";
        ////Создание фона
        //createObject = Instantiate(Background, new UnityEngine.Vector3(0, 0.05f, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        //createObject.name = "Background";
        ////Создание секторов
        //for (float i = 1, Qy = 0f, Ox = 0f, r = -1; i <= 52f; i++)
        //{
        //    if (i == 1)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-9.25f, 0f, 4.25f);
        //        CreateSector(i, vector3);
        //        r++;
        //        Ox = 0;
        //        continue;
        //    }
        //    if (i <= 18)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-8f + Ox, 0f, 4.25f);
        //        CreateSector(i, Qy, vector3, r);
        //        Ox++;
        //        continue;
        //    }
        //    if (i == 19)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(9.25f, 0, 4.25f);
        //        CreateSector(i, vector3);
        //        Qy += 90;
        //        Ox = 0;
        //        r++;
        //        continue;
        //    }
        //    if (i <= 26)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(9.25f, 0f, 3f - Ox);
        //        CreateSector(i, Qy, vector3, r);
        //        Ox++;
        //        continue;
        //    }
        //    if (i == 27)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(9.25f, 0f, -4.25f);
        //        CreateSector(i, vector3);
        //        Qy += 90;
        //        Ox = 0;
        //        r++;
        //        continue;
        //    }
        //    if (i <= 44)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(8f - Ox, 0f, -4.25f);
        //        CreateSector(i, Qy, vector3, r);
        //        Ox++;
        //        continue;
        //    }
        //    if (i == 45)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-9.25f, 0f, -4.25f);
        //        CreateSector(i, vector3);
        //        Qy += 90;
        //        Ox = 0;
        //        r++;
        //        continue;
        //    }
        //    if (i <= 52)
        //    {
        //        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-9.25f, 0f, -3f + Ox);
        //        CreateSector(i, Qy, vector3, r);
        //        Ox++;
        //        continue;
        //    }
        //}
        //Создание игроков
        for (int i = 1; i <= 2; i++)
        {
            createObject = Instantiate(Player, new UnityEngine.Vector3(-9f, 0f, 4f), new UnityEngine.Quaternion(0, 0, 0, 0));
            createObject.name = $"Player {i}";
        }
        ////Создание дополнительных внутрених секторов
        //UnityEngine.Vector3[] vector3Plus = new UnityEngine.Vector3[]
        //{
        //    new UnityEngine.Vector3(-6.75f, 0.1f, 2.5f),
        //    new UnityEngine.Vector3(0f, 0.1f, 2.5f),
        //    new UnityEngine.Vector3(6.75f, 0.1f, 2.5f),
        //    new UnityEngine.Vector3(-6.75f, 0.1f, -2.5f),
        //    new UnityEngine.Vector3(0f, 0.1f, -2.5f),
        //    new UnityEngine.Vector3(6.75f, 0.1f, -2.5f)
        //};
        //for (int i = 1; i <= 6; i++)
        //{
        //    createObject = Instantiate(Plus, vector3Plus[i - 1], new UnityEngine.Quaternion(0, 0, 0, 0));
        //    createObject.name = $"Plus {i}";
        //}
        ////Создание кубика
        //createObject = Instantiate(Cube, new UnityEngine.Vector3(0f, 1.4f, 0f), new UnityEngine.Quaternion(0, 0, 0, 0));
        //createObject.name = "Cube";
        ////Создание Арены
        //createObject = Instantiate(Arena, new UnityEngine.Vector3(6.75f, 0.1f, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        //createObject.name = "Plus Arena";
    }
    //private void CreateSector(float i, float Qy, UnityEngine.Vector3 vector3, float r)
    //{
    //    createObject = Instantiate(Rect, vector3, new UnityEngine.Quaternion(0, 0, 0, 0));
    //    Debug.Log($"Create: Name-{i} Vector-{createObject.transform.position} Quaternion: {createObject.transform.rotation}");
    //    createObject.transform.Rotate(0f, 90f * r + 180, 0f);
    //    createObject.name = i.ToString();
    //}
    //private void CreateSector(float i, UnityEngine.Vector3 vector3)
    //{
    //    createObject = Instantiate(Square, vector3, new UnityEngine.Quaternion(0, 180, 0, 0));
    //    Debug.Log($"Create: Name: {i} Vector: {createObject.transform.position} Quaternion: {createObject.transform.rotation}");
    //    createObject.name = i.ToString();
    //}
    //private void CreateTextureSector()
    //{
    //    ArrayTexturSector arrayTexturSector = new ArrayTexturSector();

    //    for (int i = 1; i <= 52; i++)
    //    {
    //        GameObject.Find($"{i}").transform.GetChild(1).GetComponent<MeshRenderer>().material = arrayTexturSector.sectors[i - 1];
    //        GameObject.Find($"{i}").transform.GetChild(1).GetComponent<MeshRenderer>().material = GameObject.Find("arrayTexturSector").GetComponent<ArrayTexturSector>().sectors[i - 1];
    //    }
    //}
}
