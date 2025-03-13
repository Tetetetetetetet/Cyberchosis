using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManagerForScene2 : GameManager
{
    //public int currScene=0;
    // Start is called before the first frame update


 
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
