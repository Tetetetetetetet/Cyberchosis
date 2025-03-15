using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerForScene3: GameManager
{
    public GameObject bossBloodBar;
    public GameObject bossBloodBarSlot;
    public TextMeshProUGUI bossName;
    //public static GameManager mGM=null;
    public TextMeshProUGUI statusText=null;
    public TextMeshProUGUI heroBloodBarValue;
    public GameObject heroBloodBar;
    public GameObject heroBloodBarSlot;
    public int pigNum;
    public override void Awake() 
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
        pigNum=0;
        //ForBoss.text="Straight up for Boss, turn left";
        //ForEnemy.text="For Practice and train, turn right";
        //Abillity.text="You get Random Abillity: Gravity Trap";
        //bossName=GameObject.Find("BossName").GetComponent<TextMeshProUGUI>;
    }
    public override void Start()
    {
        base.Start();
        Debug.Assert(mHero!=null);
        if(isEnterAnim)
        {
            mcamera.GetComponent<CameraSupport>().enterAnim();
            if(isBoss)Boss.GetComponent<Boss1>().setPos();
        }
        setPos=mHero.transform.localPosition;
        gameStart=false;
        if(isBoss)bossName.text="JiaYin.king";
        Debug.Assert(bossBloodBar!=null);
        Debug.Assert(bossBloodBarSlot!=null);
    }
    void Update()
    {
//        if(Time.time>5)
        //{
            //Destroy(Abillity);
        //}
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
       // if(Input.GetKeyDown(KeyCode.Y))
        //{
            //SceneManager.LoadScene("LifeFog");
        //}
        if(isBoss&&Boss.GetComponent<Boss1>().currHealth<=0f)
        {
            //win();
        }
        updateHeroBlood();
        updateBossBloodBar();
    }

    public void updateBossBloodBar()
    {        
        float currh=Boss.GetComponent<Boss1>().currHealth;
        float maxh=Boss.GetComponent<Boss1>().maxHealth;
        Vector3 bs=bossBloodBar.transform.localScale;
        float currs=10/maxh*currh;
        bs.x=currs;
        bossBloodBar.transform.localScale=bs;
    }
    void turnOnBossBloodBar()
    {
        bossBloodBar.GetComponent<RawImage>().enabled=true;
        bossBloodBarSlot.GetComponent<RawImage>().enabled=true;
    }
    public override void startGame()
    {
        base.startGame();
        turnOnBossBloodBar();
        turnHeroBloodBar();
        bossName.enabled=true;
    }
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

}
