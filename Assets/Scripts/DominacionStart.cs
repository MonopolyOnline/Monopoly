using System.Numerics;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DominacionStart : MonoBehaviour
{
    static System.Random random = new System.Random();

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

    void Start()
    {
        Create();
        player1.gameObject = GameObject.Find(player1.goName);
        player1.gameObject.GetComponent<Renderer>().material = colorRed;
        player1.gameObject.transform.position += Test(player1.goName, player1.sector); ;
        player2.gameObject = GameObject.Find(player2.goName);
        player2.gameObject.GetComponent<Renderer>().material = colorBlue;
        player2.gameObject.transform.position += Test(player1.goName, player1.sector); ;
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
                player1.gameObject.transform.position += Test(player1.goName, player1.sector);
                Debug.Log(Test(player1.goName, player1.sector));
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
                player2.gameObject.transform.position += Test(player2.goName, player2.sector);
                Debug.Log(Test(player2.goName, player2.sector));
                player2.move = false;
                player1.move = true;
            }
            return;
        }
    }


    UnityEngine.Vector3 Test(string goName, int sector)
    {
        UnityEngine.Vector3 vector3 = new UnityEngine.Vector3 (1f, 1f, 1f);
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
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
                        return vector3;
                    }
                    if (sector == 19)
                    {
                        vector3 = new UnityEngine.Vector3(0.65f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 26)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
                        return vector3;
                    }
                    if (sector == 27)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, -0.65f);
                        return vector3;
                    }
                    if (sector <= 44)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
                        return vector3;
                    }
                    if (sector == 45)
                    {
                        vector3 = new UnityEngine.Vector3(-0.65f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 52)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
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
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
                        return vector3;
                    }
                    if (sector == 19)
                    {
                        vector3 = new UnityEngine.Vector3(-0.1f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 26)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
                        return vector3;
                    }
                    if (sector == 27)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0.1f);
                        return vector3;
                    }
                    if (sector <= 44)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
                        return vector3;
                    }
                    if (sector == 45)
                    {
                        vector3 = new UnityEngine.Vector3(0.1f, 0, 0);
                        return vector3;
                    }
                    if (sector <= 52)
                    {
                        vector3 = new UnityEngine.Vector3(0, 0, 0);
                        return vector3;
                    }
                    return vector3;
                }
            default:
                return vector3;
        }
    }

    void Create()
    {
        //Создание основы
        GameObject basis = Instantiate(Basis, new UnityEngine.Vector3(0, 0, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        basis.name = "Basis";
        //Создание фона
        GameObject backgroundCopy = Instantiate(Background, new UnityEngine.Vector3(0, 0.05f, 0), new UnityEngine.Quaternion(0, 0, 0, 0));
        backgroundCopy.name = "Background";
        //Создание игроков
        GameObject player = Instantiate(Player, new UnityEngine.Vector3(-9f, 0f, 4f), new UnityEngine.Quaternion(0, 0, 0, 0));
        player.name = "Player 1";
        player = Instantiate(Player, new UnityEngine.Vector3(-9f, 0f, 4f), new UnityEngine.Quaternion(0, 0, 0, 0));
        player.name = "Player 2";
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
    }
    void CreateSector(float i, float Qy, UnityEngine.Vector3 vector3, float r)
    {
        GameObject obgectName = Instantiate(Rect, vector3, new UnityEngine.Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name-{i} Vector-{obgectName.transform.position} Quaternion: {obgectName.transform.rotation}");
        obgectName.transform.Rotate(0f, 90f * r, 0f);
        obgectName.name = i.ToString();
    }
    void CreateSector(float i, UnityEngine.Vector3 vector3)
    {
        GameObject obgectName = Instantiate(Square, vector3, new UnityEngine.Quaternion(0, 0, 0, 0));
        Debug.Log($"Create: Name: {i} Vector: {obgectName.transform.position} Quaternion: {obgectName.transform.rotation}");
        obgectName.name = i.ToString();
    }
}

public class GamePlayer
{
    public static string gameObjectName { get; set; } = "";
    public string goName = gameObjectName;
    public GameObject gameObject;

    public int money = 1000;

    public int sector = 1;

    public bool move = true;

    public int circlesCount = 0;

    public GamePlayer(string goName)
    {
        gameObjectName = goName;
    }
}
