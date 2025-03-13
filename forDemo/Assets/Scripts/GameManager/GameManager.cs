using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //public int currScene=0;
    public bool gameStart;
    public static bool isGameOver;
    public int sceneId;
 
    public TextMeshProUGUI bossName;
    public static GameManager mGM=null;
    public TextMeshProUGUI statusText=null;
    public static bool changedScene=false;
    public Vector3 setPos;
    //public Camera mCamera;
    public GameObject mHero;
    public GameObject Boss;//需要手动拖拽
    public bool isBoss;//according to scene
    public bool isEnterAnim;
    public GameObject mcamera; //自动挂"Main Camera"
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
        mcamera=util.findGameObject("Main Camera");
        if(isBoss)Boss=util.findGameObject("Boss");
        //ForBoss.text="Straight up for Boss, turn left";
        //ForEnemy.text="For Practice and train, turn right";
        //Abillity.text="You get Random Abillity: Gravity Trap";
        //bossName=GameObject.Find("BossName").GetComponent<TextMeshProUGUI>;
    }

    public void loseGame()
    {
        float num=Random.Range(0,1);
        Debug.Log("quit game");
        isGameOver=true;
        //Application.Quit();
        if(num>0.5)SceneManager.LoadScene("Lose1");
        else
        {
            SceneManager.LoadScene("Lose2");
        }
    }
    void Start()
    {
        Debug.Assert(mHero!=null);
        if(isEnterAnim)
        {
            mcamera.GetComponent<CameraSupport>().enterAnim();
            if(isBoss)Boss.GetComponent<Boss1>().setPos();
        }
        setPos=mHero.transform.localPosition;
        gameStart=false;
        if(isBoss)bossName.text="JiaYin.king";
    }

    public virtual void win()
    {
        SceneManager.LoadScene("Start Scene");
    }

/// <summary>
/// id  Scene
/// <list type="bullet">
/// <item>1   TheWorld</item>
/// <item>2   LifeLog</item>
/// <item>3   BossWJY</item>
/// </list>
/// </summary>

    public virtual void changeScene(int id)
    {
        Debug.Log($"change Scene{id}");
        if(id==1)
        {
            SceneManager.LoadScene("TheWord");
        }
        if(id==2)
        {
            SceneManager.LoadScene("LifeFog");
        }
        if(id==3)
        {
            SceneManager.LoadScene("BossWJY");
        }
        if(id==4)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>5)
        {
            Destroy(Abillity);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("LifeFog");
        }
        if(isBoss&&Boss.GetComponent<Boss1>().currHealth<=0f)
        {
            win();
        }
    }

}
