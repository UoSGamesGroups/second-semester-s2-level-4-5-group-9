using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveController : MonoBehaviour {

    // Varibles for Wave Generation
    public float scale = 0.1f;
    public float speed = 1.0f;
    public float noiseStrength = 1f;
    public float noiseWalk = 1f;

    private Vector3[] baseHeight;

    // Varibles for scrolling texture
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Scrolls the texture
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

        // Creates the wave motion to the plane
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;

        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}