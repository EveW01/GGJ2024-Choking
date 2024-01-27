Shader "Unlit/AlwaysOnTop"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="Overlay" }
        Pass
        {
            ZTest Always
            Lighting Off
            SetTexture [_MainTex] { combine primary }
        }
    }
}
