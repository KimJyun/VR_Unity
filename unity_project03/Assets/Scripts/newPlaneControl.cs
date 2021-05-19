using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlaneControl : MonoBehaviour
{
    public Transform LookTarget;

    public float Speed = 10;

    AndroidNativeVolumeService _android_volume = null;
    public GameObject ball;

    void Start()
    {
        _android_volume = new AndroidNativeVolumeService();
        _android_volume.SetSystemVolume(0.5f); // 0~1사이
    }

    void Update()
    {
        this.transform.Translate(this.transform.forward * Time.deltaTime * Speed, Space.World);
        this.transform.LookAt(LookTarget);

        float cur_volume = _android_volume.GetSystemVolume();
        if (cur_volume > 0.5f)
        {
            _android_volume.SetSystemVolume(0.5f);
            //생성
            Vector3 start_pos = this.transform.position;
            GameObject new_ball = Instantiate<GameObject>(ball, start_pos, Quaternion.identity);
            //발사
            Rigidbody rb = new_ball.GetComponent<Rigidbody>();
            rb.AddForce(this.transform.forward * 10000, ForceMode.Force);
            //사운드
            AudioSource audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }
    }

}
