# Game
## idea1
跑酷对战

## idea2
跑酷，很多关
通过整个游戏的条件是通过某一关
机关是关卡之间的传送门

## idea3
boss战为主，解密/跑酷/战斗/射击都可以插入boss战中，这样融合的很丰富而且不会觉得游戏体验割裂

# idea4
加入道具，buff等，丰富战斗过程，游戏体验

*不要忘记LLM之神的恩惠*

# Material
- [course website](https://myuwbclasses.github.io/IntroGameDev-XJTU/)
- [assetStore](https://assetstore.unity.com/zh-CN) [free](https://assetstore.unity.com/?category=2d%2Fcharacters&price=0-0&orderBy=1)
- [openGameArt(免费/开源)](https://opengameart.org/)
- [**itch.io**（免费/付费)](https://itch.io/game-assets)
- [**CGTrader**（3D 资源)](https://www.cgtrader.com/)
- [**Kenney.nl**（免费 2D/3D 资源)](https://www.kenney.nl/assets)

# Share proj
Project->right mouse click -> export packages->import package->costom package

# C\# cheat sheet

## class: Vector3
- `.Distance`

## btw
`[SerializeField]` 使得private variable 可见

## class: Camara
- `Camara.main.aspect`: aspect是主相机的宽高比
- `Camera.main.gameObject`: 返回MainCamera对象 (相比之下`Camera.main`是一个component)
- `orthographicSize`: 垂直可视范围/2

## some GameObjects
- `Camera.main.orthographicSize`: main camera size
- 

## Input
```c#
GetKey
GetKeyDown
mousePosition
```
`KeyCode.a/b/c/d/...`

## transform
- transform.position
- `localposition`: always localposition *(relateive to the parent)*
- 每个GameObject都自带transform
- `transform.Translate`() -> to move object 或者 position+=(v\* time)\* transform.up\/down\/...
- `transform.up`: *vector*, 总是指向物体的y轴正方向（随着rotate会转）
- `transform.Rotate()`: 使用度数制
- *about 旋转*：`.Rotate()`或者`.rotation=Quaternion.xxx`
- **folders organize**: *assets*: script, textures, scenes, resources(/Prefabs)
- `Destroy(transform.gameObject)`: *delete entity*
- **prefab**: 生成object template, 拖出来就可以生成不同的entity*但是behavior the same*
- `GameObject e=Instantiate(Resources.Load("Prefabs/Egg") as GameObject);`: 生成entity(按照Resources/Prefabs/Eggs作为模板)

## collsion
一般的碰撞检测：一个碰所有$O(n)$, 所有相碰：$O(n^2)$
### collider
- `Is Trigger`: whether to trigger a collision

## UI
- child of Canvas
- UI & GameObject在两个不同系统里，GameObject(小白框) moves / UI stays(大白框), 在Layers里可以设置显示
- *types:* button(true/false) | slider bar(number)
- *create UI instance -> Canvas, UI inst, EventSystem all created*
## slider bar
要实现slider bar变化时触发事件可以
1. `onValueChanged`将对应对象和函数拖到框里，从而实现值变化时触发某个函数, *no code*
2. *coding approach* 例：控制音量
```c#
public class VolumeControl : MonoBehaviour 
{ 
	public Slider volumeSlider; 
	void Start() { // Set the initial value 
		volumeSlider.value = AudioListener.volume; //AudioListener是一个static property, 控制整个游戏/Scene的音量
		volumeSlider.onValueChanged.AddListener(ChangeVolume); 
	} 
	void ChangeVolume(float volume) { AudioListener.volume = volume; // Adjust the global volume 
		Debug.Log("Volume changed to: " + volume); 
	} 
}
```


## GOB connection
- 代码里申明类型作为借口，Unity里拖进去来连接
记录每个egg的生成GreenArrow, 从而调用对应GreenArrow的oneLessEgg(), *plus: 只有一个GreenArrow, 就在GameManeger中记录mHero, 然后直接将static eggBehavior.theGreenArrow设为mHero就行*

**Confused about UI/Game Manager? go to 2.4**

## Lerp & GradualRotation
*用来做弹幕？*
```c#
private void PointAtPosition(Vector3 p,float r)
{
	Vector v=p-transform.localPostion;
	transform.up=Vector3.LerpUnclamped(transform.up,v,r);
}
```
lerp: 线性插值

## class: Bounds
- `.center`
- from: `GameManager.GetTargetBound()`
- `.size`: Vector3(width,height,depth)
- `.extents`: size/2

## partial class
只用`partial class`定义的类可以在多个文件中分别定义不同部分

***how to orbit***
## `Quaternion`: 四维向量(x,y,z,w)，用于表示3D旋转，避免*万向锁问题*
```c#
Quaternion rotation = Quaternion.Euler(0, 90, 0);  // 绕 Y 轴旋转 90 度
transform.rotation = rotation;
```
这是将欧拉角（度数）转化为四元数，还可以（*上课用法*）：
```c#
Quaternion rotation = Quaternion.AngleAxis(45, Vector3.up);  // 绕 Y 轴旋转 45 度
transform.rotation = rotation;
```
> 万向锁问题：使用欧拉角旋转导致轴重合，旋转自由度丢失

*使用Quaternion平滑旋转*
```c#
Quaternion targetRotation = Quaternion.Euler(90,90,0)
transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,Time.deltaTime);
```

- *to follow*: `transform.position= Host.position+OrbitRadius \* transform.right`


