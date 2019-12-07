using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public float Speed;
    public float Mousespeed;
    //private bool MoveF;
    //public Button btns;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float MouseScroll = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(new Vector3(h * Speed, MouseScroll * -1 * Mousespeed, v * Speed) * Time.deltaTime, Space.World);
        //space.world指的是世界坐标，如果使用此参数，相机只会拉近



        //以下为设定相机的位置和方向，让相机不出预定范围
        if (transform.position.x > 25)
        {
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

        if (transform.position.z > 6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 6);
        }
        if (transform.position.z < -45)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -45);
        }
        if (transform.position.y > 24)
        {
            transform.position = new Vector3(transform.position.x, 24, transform.position.z);
        }
        if (transform.position.y < 10)
        {
            transform.localPosition = new Vector3(transform.position.x, 10, transform.position.z);



            //}
            //if (MoveF==true)
            //{

            //}
            //btns.onClick.AddListener(ButtonForWord);




            //void Test()
            //{
            //    transform.Translate(new Vector3(transform.position.x, transform.position.y, Speed) * Time.deltaTime);
            //}

        }
        //public void ButtonForWord()
        //{
        //    transform.Translate(new Vector3(transform.position.x, transform.position.y, Speed) * Time.deltaTime);
        //    print("312321231321");
        //}
        //public void ButtonBack()
        //{
        //    transform.Translate(new Vector3(transform.position.x, transform.position.y, Speed * Speed  * -1) * Time.deltaTime);
        //}
        //public void ButtonLeft()
        //{
        //    transform.Translate(new Vector3(Speed , transform.position.y, transform.position.z) * Time.deltaTime);
        //}
        //public void ButtonRight()
        //{
        //    transform.Translate(new Vector3(Speed *  -1, transform.position.y, transform.position.z)*Time.deltaTime);
        //}
    }
}