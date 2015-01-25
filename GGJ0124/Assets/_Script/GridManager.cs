using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	public Transform aUpperRight;
	public ArrayList grids;

	private float gridLength;

	// Use this for initialization
	void Start () {
		GridCtrl firstGrid;
		firstGrid.originPos = new Vector2(aUpperRight.position.x, aUpperRight.position.y);
		grids.Add(firstGrid);

		float setX = aUpperRight.position.x;
		float setY = aUpperRight.position.y;

		for (int i=1; i < Const.COL*Const.ROW; i++) {

			setX += gridLength;
			if (i % Const.COL == 0) {
				setX = aUpperRight.position.x;
				setY += gridLength;
			}

			GridCtrl newGrid;
			newGrid.originPos = new Vector2();
			grids.Add(newGrid);
		}
	}

}
