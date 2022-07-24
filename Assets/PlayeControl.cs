using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeControl : MonoBehaviour
{
    Rigidbody rb;
    private float Speed = 0.01f;//横移動の速さの変数
    private float JmupPow = 1;　//ジャンプパワー
    private float moveX;　//横移動に使うときの変数
    private float Gravity = 0.3f;　//空中に居る時に掛かる重力
    private float time;


    private float distance = 1f;　//Rayの長さ
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Rayを使って地面に接触しているかの判定
        Vector3 rayPos = transform.position + new Vector3(0, 0, 0);
        Ray ray = new Ray(rayPos, Vector3.down);
        bool Ground = Physics.Raycast(ray, distance);

        //横移動
        moveX = Input.GetAxis("Horizontal") * Speed;
        rb.AddForce(transform.right * moveX, ForceMode.Impulse);
    
        //ジャンプ
        if (Ground)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * JmupPow, ForceMode.Impulse);
            }
        }

        //空中に一定時間居ると重力が掛かる。
        if (!Ground)
        {
            time += Time.deltaTime;
            if (time < 1) return;
            time = 0;
            {
                rb.AddForce(transform.up * -Gravity, ForceMode.Impulse);
            }
        }
    }
    public void MaterialA()
    {
        GetComponent<Renderer>().material.color = Color.red;

    }
    public void MaterialB()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
