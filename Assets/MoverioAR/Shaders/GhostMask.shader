// Copyright (c) SEIKO EPSON CORPORATION 2016 - 2017. All rights reserved.

Shader "GhostMask" {

	SubShader{

		Tags{ "Queue" = "Geometry-1" }

		ZTest LEqual
		ZWrite On
		
		Lighting Off

		ColorMask 0

		Pass{}
	}
}
