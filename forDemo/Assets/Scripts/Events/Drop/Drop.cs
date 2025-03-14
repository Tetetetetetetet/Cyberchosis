using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public float Rskill1=2;
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
        if(!player.canSkill1&&r<Rskill1){
            GameObject p=Resources.Load<GameObject>("Prefabs/DropThings/Magician");
            Vector3 position=gameObject.transform.position;
            Instantiate(p,position,Quaternion.identity);
            player.canSkill1=true;
        }
        if(!player.canSkill2&&r<Rskill1&&r>=Rskill2){
            GameObject p=Resources.Load<GameObject>("Prefabs/DropThings/MagicRing");
            Vector3 position=gameObject.transform.position;
            Instantiate(p,position,Quaternion.identity);
            player.canSkill2=true;
        }
        
    }
}
