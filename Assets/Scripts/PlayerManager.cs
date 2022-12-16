using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    static System.Random random = new System.Random();

    public bool _startFame = false;

    GamePlayer player1 = new GamePlayer("Player 1");
    GamePlayer player2 = new GamePlayer("Player 2");

    [SerializeField] Material colorRed;
    [SerializeField] Material colorBlue;

    [SerializeField] Text balancePlayer1;
    [SerializeField] Text balancePlayer2;

    [SerializeField] GameObject Basis;
    [SerializeField] GameObject Background;
    [SerializeField] GameObject Square;
    [SerializeField] GameObject Rect;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Plus;
    [SerializeField] GameObject Cube;

    GameObject createObject;

    private void Start()
    {
        Create();
    }

    private void FixedUpdate()
    {
        player1.gameObject = GameObject.Find(player1.goName);
        player2.gameObject = GameObject.Find(player2.goName);
        if (player2.gameObject != null)
            player2.gameObject.GetComponent<Renderer>().material = colorBlue;

        //var playerList = PhotonNetwork.PlayerList;
        //string a = "";
        //foreach (var item in playerList)
        //{
        //    a = a + item;
        //}
        //Debug.Log(a);
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
    private void Create()
    {
        //Создание основы
        createObject = Instantiate(Basis, new UnityEngine.Vector3(0, 0, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Basis";
        //Создание фона
        createObject = Instantiate(Background, new UnityEngine.Vector3(0, 0.05f, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Background";
        //Создание игроков
        //createObject = Instantiate(Player, new UnityEngine.Vector3(-9f, 0f, 4f), new UnityEngine.Quaternion(0, 0, 0, 0));
        //createObject.name = "Player 1";
        //createObject = Instantiate(Player, new UnityEngine.Vector3(-9f, 0f, 4f), new UnityEngine.Quaternion(0, 0, 0, 0));
        //createObject.name = "Player 2";
        //Создание секторов
        for (float i = 1, Qy = 0f, Ox = 0f, r = -1; i <= 52f; i++)
        {
            if (i == 1)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-9.25f, 0f, 4.25f);
                CreateSector(i, vector3);
                r++;
                Ox = 0;
                continue;
            }
            if (i <= 18)
            {
                UnityEngine.Vector3 vector3 = new UnityEngine.Vector3(-8f + Ox, 0f, 4.25f);
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
        //Создание дополнительных внутрених секторов
        createObject = Instantiate(Plus, new UnityEngine.Vector3(-6.75f, 0.1f, 2.5f), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Plus 1";
        createObject = Instantiate(Plus, new UnityEngine.Vector3(0f, 0.1f, 2.5f), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Plus 2";
        createObject = Instantiate(Plus, new UnityEngine.Vector3(6.75f, 0.1f, 2.5f), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Plus 3";
        createObject = Instantiate(Plus, new UnityEngine.Vector3(-6.75f, 0.1f, -2.5f), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Plus 4";
        createObject = Instantiate(Plus, new UnityEngine.Vector3(0f, 0.1f, -2.5f), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Plus 5";
        createObject = Instantiate(Plus, new UnityEngine.Vector3(6.75f, 0.1f, -2.5f), new UnityEngine.Quaternion(0, 0, 0, 0));
        createObject.name = "Plus 6";
        //Создание кубика
        createObject = Instantiate(Cube, new UnityEngine.Vector3(0f, 1.4f, 0f), new UnityEngine.Quaternion(0, 0, 0, 0));
    }
    private void CreateSector(float i, float Qy, Vector3 vector3, float r)
    {
        createObject = Instantiate(Rect, vector3, new UnityEngine.Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name-{i} Vector-{createObject.transform.position} Quaternion: {createObject.transform.rotation}");
        createObject.transform.Rotate(0f, 90f * r, 0f);
        createObject.name = i.ToString();
    }
    private void CreateSector(float i, Vector3 vector3)
    {
        createObject = Instantiate(Square, vector3, new UnityEngine.Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name: {i} Vector: {createObject.transform.position} Quaternion: {createObject.transform.rotation}");
        createObject.name = i.ToString();
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
}