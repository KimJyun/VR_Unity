using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Control : MonoBehaviour
{
    public GameObject ball;

    float speed = 10;
    float rot_speed = 50;
    void Update()
    {
        // 앞뒤 이동
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(this.transform.forward * Time.deltaTime * speed, Space.World);
        } //translate -> 이동 , Space World -> 전체 좌표

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(this.transform.forward * -Time.deltaTime * speed, Space.World);
        }

        // 좌우 회전
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(this.transform.up, Time.deltaTime * rot_speed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(this.transform.up, -Time.deltaTime * rot_speed, Space.World);
        }

        //피치 회전
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Rotate(this.transform.right, Time.deltaTime * rot_speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Rotate(this.transform.right, -Time.deltaTime * rot_speed, Space.World);
        }

        //롤 회전
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(this.transform.forward, Time.deltaTime * rot_speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(this.transform.forward, -Time.deltaTime * rot_speed, Space.World);
        }

        /*
         * 지금쓰는 모델은 추가되어있음. 
         * 프로펠러 회전시키기
         * public class plane_control : MonoBehaviour
           {
           public GameObject propellor;
           float speed = 10;
           float rot_speed = 50;
           void Update()
           {
                propellor.transform.Rotate(0, 10, 0);
                ...
                ...
           }
           }
         */

        // 슈팅 기능
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //생성
            Vector3 start_pos = this.transform.position;
            GameObject new_ball = Instantiate<GameObject>(ball, start_pos, Quaternion.identity);
            //발사
            Rigidbody rb = new_ball.GetComponent<Rigidbody>();
            rb.AddForce(this.transform.forward * 10000, ForceMode.Force);
            //사운드 추가
            AudioSource audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }

    }
}
