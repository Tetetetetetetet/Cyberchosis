using System.Reflection;
using UnityEngine;

public partial class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorManager doorm=DoorManager.tDoorManager;
    public bool placeMagicSignal;
    public Vector3 mousePos;
    public KeyCode KeyFire;
    public KeyCode KeyJump;
    public KeyCode KeySword;
    public KeyCode KeyTurnMagic;
    public KeyCode KeyPlaceMagic;
    public KeyCode KeyThrow;
    public KeyCode KeySit;
    public KeyCode KeyCrouch;
    public KeyCode KeyCombo;
    public KeyCode KeyRoll;
    public KeyCode KeyDefen;

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
        GameObject _trap=util.findGameObject("SkillGravity");
        if(_trap==null||canSkill2==false)
        {
            return;
        }
        else
        {
            SkillGravity trap=_trap.GetComponent<SkillGravity>();
            Debug.Log("GravityTrap Loaded");
            if(Input.GetKeyDown(KeyTurnMagic))
            {
                trap.turn();
            }
            if(placeMagicSignal)
            {
                trap.setPos(p.x);
                placeMagicSignal=false;
            }
        }
    }
    public void turnOnMagicSignal()
    {
        placeMagicSignal=true;
    }
}
