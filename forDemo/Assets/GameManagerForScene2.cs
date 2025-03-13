using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManagerForScene2 : MonoBehaviour
{
    //public int currScene=0;
    public bool gameStart;
    public static bool isGameOver;
    public int sceneId;
 
    public TextMeshProUGUI bossName;
    public TextMeshProUGUI statusText=null;
    public static bool changedScene=false;
    public Vector3 setPos;
    //public Camera mCamera;
    public GameObject mHero;
    public static GameManagerForScene2 mGM=null;
    public GameObject Boss;//需要手动拖拽
    public bool isBoss;//according to scene
    public bool isEnterAnim;
    public CameraForScene2 mcamera; //自动挂"Main Camera"
    public TextMeshProUGUI ForBoss;
    public TextMeshProUGUI ForEnemy;
    public TextMeshProUGUI Abillity;
    
    public int enemyNumber=10;
    // Start is called before the first frame update
    void Awake() 
    {
        isGameOver=false;
        if(mGM==null)
        {
            mGM = this;
            //DontDestroyOnLoad(mGameManager);
        }
        //else Destroy(gameObject);
        mHero=GameObject.FindWithTag("Player");
        mcamera=util.findGameObject("Main Camera").GetComponent<CameraForScene2>();
        if(isBoss)
        {
            Boss=util.findGameObject("Boss");
            bossName=GameObject.Find("BossName").GetComponent<TextMeshProUGUI>();
        }
    }

    public void loseGame()
    {
        float num=Random.Range(0,1);
        Debug.Log("quit game");
        isGameOver=true;
        if(num>0.5)SceneManager.LoadScene("Lose1");
        else
        {
            SceneManager.LoadScene("Lose2");
        }
    }


    public void win()
    {
        SceneManager.LoadScene("Start Scene");
    }
    public void changeScene(int id)
    {
        Debug.Log($"change Scene{id}");
        if(id==2)
        {
            SceneManager.LoadScene("LifeFog");
        }
        if(id==3)
        {
            SceneManager.LoadScene("testScene");
        }
    }
    void Start()
    {
        Debug.Assert(mHero!=null);
        Debug.Assert(mcamera!=null);
        setPos=mHero.transform.localPosition;
        if(isEnterAnim)gameStart=false;
        else gameStart=true;
        //if(isBoss)bossName.text="JiaYin.king";
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        if(isBoss&&Boss.GetComponent<Boss1>().currHealth<=0f)
        {
            win();
        }
    }

}
