using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHalo : MonoBehaviour
{
    private ParticleSystem parSys; 
    private ParticleSystem.Particle[] parArr; 
    private ParticleData[] parData;

    public int count = 10000; 
    public float size = 0.05f;
    public float minRadius = 5f;
    public float maxRadius = 12f;
    public bool clockwise = true;
    public float speed = 2f;
    public float maxRadiusChange = 0.02f;

    void Start()
    {   
        parArr = new ParticleSystem.Particle[count];
        parData = new ParticleData[count];

        parSys = this.GetComponent<ParticleSystem>();
        var main = parSys.main;
        main.startSpeed = 0;
        main.startSize = size;
        main.loop = false;
        main.maxParticles = count;
        parSys.Emit(count);
        parSys.GetParticles(parArr);

        RandomPlace();
    }

    private int tier = 12; 
    void Update()
    {
        for (int i = 0; i < count; i++)
        {
            if (clockwise)  
                parData[i].angle -= (i % tier + 1) * (speed / parData[i].radius / tier);
            else 
                parData[i].angle += (i % tier + 1) * (speed / parData[i].radius / tier);

            parData[i].angle = (360.0f + parData[i].angle) % 360.0f;
            float theta = parData[i].angle / 180 * Mathf.PI;
            parArr[i].position = new Vector3(parData[i].radius * Mathf.Cos(theta), 0f, parData[i].radius * Mathf.Sin(theta));  
            parData[i].time += Time.deltaTime;
            parData[i].radius += Mathf.PingPong(parData[i].time / minRadius / maxRadius, maxRadiusChange) - maxRadiusChange / 2.0f;
        }

        parSys.SetParticles(parArr, parArr.Length);
    }

    void RandomPlace()
    {
        for (int i = 0; i < count; ++i)
        {
            float midRadius = (maxRadius + minRadius) / 2;
            float radius = Random.Range(5f, 12f);
            if (radius % 3 == 1)
                radius = Random.Range(7f, 10f);
            else if (radius % 3 == 2)
                radius = Random.Range(8f, 9f);
            float angle = Random.Range(0.0f, 360.0f);
            float theta = angle / 180 * Mathf.PI;
            float time = Random.Range(0.0f, 360.0f);
            float radiusChange = Random.Range(0.0f, maxRadiusChange);
            parData[i] = new ParticleData(radius, angle, time);
            parArr[i].position = new Vector3(parData[i].radius * Mathf.Cos(theta), 0f, parData[i].radius * Mathf.Sin(theta));
        }

        parSys.SetParticles(parArr, parArr.Length);
    }
}

