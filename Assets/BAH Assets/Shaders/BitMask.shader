 Shader "Custom/Bitmask"
{
   Properties
   {
	  //_MainTex ("Base", 2D) = "black" {}
      _Mask ("Culling Mask", 2D) = "" {}
      _Cutoff ("Alpha Cutoff", Range(0,1)) = 0
   }
 
   SubShader
   {
		Lighting Off
		ZWrite On
        Tags {"Queue" = "Geometry"} 
	
        //Blend OneMinusSrcAlpha DstAlpha
		blend srcalpha dstalpha
		
		Pass {
			AlphaTest LEqual [_Cutoff]
			//SetTexture [_Mask] { combine texture }
			SetTexture [_Mask] { combine texture alpha } //Uncomment to see white
		}
	}
}