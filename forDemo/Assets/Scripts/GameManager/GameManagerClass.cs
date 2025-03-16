using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //public int currScene=0;
    public TextMeshProUGUI heroBloodBarValue;
    public GameObject heroBloodBar;
    public GameObject heroBloodBarSlot;
    public bool gameStart;
    public static bool isGameOver;
    public int sceneId;
    public static bool changedScene=false;
    public Vector3 setPos;
    //public Camera mCamera;
    public GameObject mHero;
    public GameObject Boss;//需要手动拖拽
    public bool isBoss;//according to scene
    public bool isEnterAnim;
    public GameObject mcamera; //自动挂"Main Camera"
   // public TextMeshProUGUI ForBoss;
    //public TextMeshProUGUI ForEnemy;
    //public TextMeshProUGUI Abillity;
    public int enemyNumber=10;
    public static GameManager mGM;
    public string nextSceneName;
    // Start is called before the first frame update

    public virtual void Awake()
    {
        mGM=this;
        mHero=util.findGameObject("Hero");
        mcamera=util.findGameObject("Main Camera");
    }
    public virtual void Start()
    {
        Debug.Assert(mGM!=null);
        Debug.Assert(mHero!=null);
        Debug.Assert(mcamera!=null);
        isGameOver=false;
        gameStart=false;
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

    public virtual void startGame()
    {
        gameStart=true;
    }
    // Update is called once per frame
    public void updateHeroBlood()
    {
        float currh=mHero.GetComponent<PlayerBehavior>().currHealth;
        float maxh=mHero.GetComponent<PlayerBehavior>().maxHealth;
        heroBloodBarValue.text=$"{currh}/{maxh}";
        Vector3 bs=heroBloodBar.transform.localScale;
        float currs=5/maxh*currh;
        bs.x=currs;
        heroBloodBar.transform.localScale=bs;
    }
    public void turnHeroBloodBar()
    {
        heroBloodBar.GetComponent<RawImage>().enabled=true;
        heroBloodBarSlot.GetComponent<RawImage>().enabled=true;
        heroBloodBarValue.enabled=true;
    }    
    public void nextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
