using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;
using System.Text;
using TMPro;

public class ProfilerStats : MonoBehaviour
{

    ProfilerRecorder triangleRecorder;
    ProfilerRecorder drawCallsRecorder;
    ProfilerRecorder verticesRecorder;
    ProfilerRecorder systemMemoryRecorder;
    ProfilerRecorder gcMemoryRecorder;
    ProfilerRecorder totalReservedMemoryRecorder;
    public TextMeshProUGUI statOverlay;

    private int framesCount;
    private float framesTime, lastFPS;
    private const float bToKb = 1 / 1024;
    private const float bToMb = 1 / (1024 * 1024);

    // Start is called  before the first frame update
    void Start()
    {
        if (statOverlay == null)
            statOverlay = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void OnEnable()
    {
        triangleRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Triangles Count");
        drawCallsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Draw Calls Count");
        verticesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertices Count");
        totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
        systemMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        gcMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");

    }

    void OnDisable()
    {
        triangleRecorder.Dispose();
        drawCallsRecorder.Dispose();
        verticesRecorder.Dispose();
        totalReservedMemoryRecorder.Dispose();
        systemMemoryRecorder.Dispose();
        gcMemoryRecorder.Dispose();
    }


    // Update is called once per frame
    void Update()
    {
        var sb = new StringBuilder(500);

        framesCount++;
        framesTime += Time.unscaledDeltaTime;
        if (framesTime > 0.5f)
        {
            float fps = framesCount / framesTime;
            lastFPS = fps;
            framesCount = 0;
            framesTime = 0;
        }
        sb.AppendLine($"FPS: {lastFPS}");
        sb.AppendLine($"Verts: {verticesRecorder.LastValue / 1000}k");
        sb.AppendLine($"Tris: {triangleRecorder.LastValue / 1000}k");
        sb.AppendLine($"DrawCalls: {drawCallsRecorder.LastValue}");
        sb.AppendLine($"Total Reserved Memory: {totalReservedMemoryRecorder.LastValue / 1048576}MB");
        sb.AppendLine($"System Memory: {systemMemoryRecorder.LastValue / 1048576}MB");
        sb.AppendLine($"GC Memory: {gcMemoryRecorder.LastValue / 1048576}MB");

        statOverlay.text = sb.ToString();
    }
    public int GetterValueVerts()
    {
        return (int)verticesRecorder.LastValue / 1000;
    }
    public int GetterValueDrawCalls()
    {
        return (int)drawCallsRecorder.LastValue;
    }

}
