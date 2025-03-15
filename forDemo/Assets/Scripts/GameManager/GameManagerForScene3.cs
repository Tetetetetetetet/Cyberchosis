using UnityEngine;
using UnityEngine.UI;

public class GameManagerForScene3: GameManager
{
    public GameObject bossBloodBar;
    public GameObject bossBloodBarSlot;
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
            win();
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
        bossName.enabled=true;
    }
}
