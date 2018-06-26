using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricUtils {

	public static Vector2 IsoFrom2D(Vector2 vec) {
		return new Vector2(vec.x - vec.y, (vec.x + vec.y) / 2f);
	}

}
