using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //public int currScene=0;
    public bool gameStart;
    public static bool isGameOver;
    public TextMeshProUGUI bossName;
    public static GameManager mGM=null;
    public TextMeshProUGUI statusText=null;
    public static bool changedScene=false;
    public Vector3 setPos;
    //public Camera mCamera;
    public GameObject mHero;
    public GameObject Boss;//需要手动拖拽
    public bool enterEnim;
    public Camera mcamera; //自动挂"Main Camera"
    
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
        mcamera=util.findGameObject("Main Camera").GetComponent<Camera>();
        Boss=util.findGameObject("Boss");
        //bossName=GameObject.Find("BossName").GetComponent<TextMeshProUGUI>;
    }

    public void loseGame()
    {
        Debug.Log("quit game");
        isGameOver=true;
        //Application.Quit();
    }
    void Start()
    {
        Debug.Assert(mHero!=null);
        if(enterEnim)
        {
            mcamera.GetComponent<CameraSupport>().enterAnim();
            Boss.GetComponent<Boss1>().setPos();
        }
        setPos=mHero.transform.localPosition;
        gameStart=false;
        bossName.text="JiaYin.king";
    }

    public void win()
    {
        SceneManager.LoadScene("StartScene");
    }

    // Update is called once per frame
    void Update()
    {
    }

}
