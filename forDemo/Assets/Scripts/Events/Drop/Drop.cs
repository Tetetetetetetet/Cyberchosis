using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public float Rskill1;
    public float Rskill2;
    public PlayerBehavior player;

    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.Find("Hero").GetComponent<PlayerBehavior
        >();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropSkills(){
        float r=Random.value;
        Debug.Log(r+"Rskill"+player.canSkill1+Rskill1);
        if(!player.canSkill1&&r<Rskill1){
            Debug.Log("drop skill1");
            GameObject p=Resources.Load<GameObject>("Prefabs/DropThings/Magician");
            Vector3 position=gameObject.transform.position;
            Instantiate(p,position,Quaternion.identity);
            player.canSkill1=true;
        }
        if(!player.canSkill2&&r<Rskill2&&r>=Rskill1){
            GameObject p=Resources.Load<GameObject>("Prefabs/DropThings/MagicRing");
            Vector3 position=gameObject.transform.position;
            Instantiate(p,position,Quaternion.identity);
            player.canSkill2=true;
        }
        
    }
}
