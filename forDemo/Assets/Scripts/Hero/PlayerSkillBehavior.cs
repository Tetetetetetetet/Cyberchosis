using UnityEngine;

public partial class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorManager doorm=DoorManager.tDoorManager;
    public Vector3 mousePos;

    /*
    访问各个技能，是否装载，能否发动
    */
    void skill()
    {
        chooseSkill();
        //transformDoor();
        gravityTrap();
    }
    public enum SkillStatus{
        skillGravity=0,
        skillDoor=1
    }
    public SkillStatus currSkill;
    void chooseSkill()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("get alpha1");
            currSkill=SkillStatus.skillGravity;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("get alpha2");
            currSkill=SkillStatus.skillDoor;
        }
    }
    void transformDoor()
    {
        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(doorm.enabled==true&&Input.GetKeyDown(KeyCode.Mouse2))
        {
            doorm.called(mousePos.x,mousePos.x+10);
        }
    }
    void gravityTrap()
    {
        GameObject _trap=GameObject.Find("SkillGravity");
        Debug.Assert(_trap!=null);
        if(_trap==null)
        {
            return;
        }
        else
        {
            SkillGravity trap=_trap.GetComponent<SkillGravity>();
            Debug.Log("GravityTrap Loaded");
            if(Input.GetKeyDown(KeyCode.Mouse3))
            {
                trap.turn();
            }
            if(Input.GetKeyDown(KeyCode.Mouse2))
            {
                trap.setPos(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
            }
        }
    }
}
