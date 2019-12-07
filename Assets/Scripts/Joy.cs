using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joy : MonoBehaviour
{
    /// <summary>
	/// 摇杆背景
	/// </summary>
	private Transform _joyBg;
    /// <summary>
    /// 摇杆中心
    /// </summary>
    private Transform _joyCenter;
    /// <summary>
    /// 摇杆半径
    /// </summary>
    private float _radius;
    /// <summary>
    /// 移动中心
    /// </summary>
    private Vector2 _moveCenter;
    /// <summary>
    /// 鼠标到移动中心的向量
    /// </summary>
    private Vector2 _mouseToCenterVect;
    /// <summary>
    /// 鼠标到中心点的距离
    /// </summary>
    private float _mouseToCenterDistance;
    /// <summary>
    /// 水平获取值
    /// </summary>
    private float _hor;
    /// <summary>
    /// 垂直获取值
    /// </summary>
    private float _ver;
    /// <summary>
    /// 旋转角度
    /// </summary>
    private float _rotAngle;

    public GameObject GB;
    // Start is called before the first frame update
    void Start()
    {
        _joyBg = GameObject.Find("Canvas").transform.Find("JoyBg");
        _joyCenter = GameObject.Find("Canvas").transform.Find("JoyBg/JoyCenter");
        //GB = GameObject.Find("Player").transform.gameObject;
        _radius = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
	/// 开始拖动
	/// </summary>
	public void OnDragBegain()
    {
        //移动中心点赋值
        _moveCenter = Input.mousePosition;
        //显示摇杆
        _joyBg.gameObject.SetActive(true);
        //摇杆背景位置修正到点击位置
        _joyBg.position = _moveCenter;
        //摇杆中心位置修正到点击位置
        _joyCenter.position = _moveCenter;

    }

    /// <summary>
    /// 正在拖动
    /// </summary>
    public void OnDragMove()
    {
        //中心店到触摸点的向量赋值
        _mouseToCenterVect = (Vector2)Input.mousePosition - _moveCenter;
        //中心店到触摸点的距离计算
        _mouseToCenterDistance = Mathf.Clamp(_mouseToCenterVect.magnitude, 0, 100);
        //摇杆中心的X - 移动中心的x就是水平的变化值，这里 /100 控制_hor在（-1，,1）之间
        _hor = (_joyCenter.position.x - _moveCenter.x) / 100;
        //摇杆中心的Y - 移动中心的Y就是垂直的变化值，这里 /100 控制_hor在（-1，,1）之间
        _ver = (_joyCenter.position.y - _moveCenter.y) / 100;

        //角度就是 中心店到触摸点的向量 和 2D平面Y轴正方向的夹角，这里只能显示0——180度
        _rotAngle = Vector3.Angle(_mouseToCenterVect, Vector3.up);

        //这里根据_hor的正负来判断摇杆中心是位于移动中心左侧还是右侧，然后修改度数，显示在0——360之间
        if (_hor < 0)
        {
            _rotAngle = 360 - _rotAngle;
        }
        //Vector3.forward 以Vector3.up为中心旋转轴，旋转_rotAngle度，这里计算出主角的旋转度数
        //GB.transform.position = Quaternion.AngleAxis(_rotAngle, Vector3.up) * Vector3.forward;


    }

    /// <summary>
    /// 拖动结束
    /// </summary>
    public void OnDragEnd()
    {
        //水平移动值归零
        _hor = 0;
        //垂直移动值归零
        _ver = 0;
        //隐藏摇杆
        _joyBg.gameObject.SetActive(false);

    }


}
