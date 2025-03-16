using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerForScene1 : GameManager
{
    public float changeSceneX;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        turnHeroBloodBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(mHero.transform.localPosition.x>changeSceneX)
        {
            nextScene();
        }
        updateHeroBlood();
    }
}
