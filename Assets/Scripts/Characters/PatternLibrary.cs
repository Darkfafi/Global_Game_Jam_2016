using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PatternLibrary {

	public const int TOTAL_PATTERNS = 6;

	public static SeduceData GetPatternByIndex(int patternConst,int difficulty = 999){
		List<string> listMoves = new List<string> ();
		int indexSound = 0;
		SeduceData data = new SeduceData ();
		if (difficulty != 999) {
			if (difficulty == 0) {
				switch (patternConst) {
				case 0:
					listMoves.Add (Tags.MOVE_PART_A);
					break;
				case 1:
					listMoves.Add (Tags.MOVE_PART_B);
					break;
				case 2:
					listMoves.Add (Tags.MOVE_PART_C);
					break;
				case 3:
					listMoves.Add (Tags.MOVE_PART_D);
					break;
				case 4:
					indexSound = 1;
					break;
				case 5:
					indexSound = 2;
					break;
				}
			}
			if (difficulty == 3) {
				switch (patternConst) {
				case 0:
					listMoves.Add (Tags.MOVE_PART_A);
					listMoves.Add (Tags.MOVE_PART_C);
					indexSound = 1;
					break;
				case 1:
					listMoves.Add (Tags.MOVE_PART_D);
					listMoves.Add (Tags.MOVE_PART_C);
					indexSound = 3;
					break;
				case 2:
					listMoves.Add (Tags.MOVE_PART_A);
					indexSound = 2;
					break;
				case 3:
					listMoves.Add (Tags.MOVE_PART_A);
					listMoves.Add (Tags.MOVE_PART_B);
					break;
				case 4:
					listMoves.Add (Tags.MOVE_PART_D);
					listMoves.Add (Tags.MOVE_PART_B);
					indexSound = 1;
					break;
				case 5:
					listMoves.Add (Tags.MOVE_PART_C);
					listMoves.Add (Tags.MOVE_PART_B);
					indexSound = 2;
					break;
				}
			}
			if (difficulty == 1) {
				switch (patternConst) {
				case 0:
					listMoves.Add (Tags.MOVE_PART_A);
					listMoves.Add (Tags.MOVE_PART_C);
					break;
				case 1:
					listMoves.Add (Tags.MOVE_PART_D);
					listMoves.Add (Tags.MOVE_PART_C);
					break;
				case 2:
					listMoves.Add (Tags.MOVE_PART_A);
					indexSound = 2;
					break;
				case 3:
					listMoves.Add (Tags.MOVE_PART_A);
					listMoves.Add (Tags.MOVE_PART_B);
					break;
				case 4:
					listMoves.Add (Tags.MOVE_PART_D);
					listMoves.Add (Tags.MOVE_PART_B);
					break;
				case 5:
					listMoves.Add (Tags.MOVE_PART_C);
					indexSound = 3;
					break;
				}
			}
			if (difficulty == 2) {
				switch (patternConst) {
				case 0:
					listMoves.Add (Tags.MOVE_PART_A);
					listMoves.Add (Tags.MOVE_PART_C);
					indexSound = 3;
					break;
				case 1:
					listMoves.Add (Tags.MOVE_PART_D);
					listMoves.Add (Tags.MOVE_PART_C);
					indexSound = 1;
					break;
				case 2:
					listMoves.Add (Tags.MOVE_PART_A);
					listMoves.Add (Tags.MOVE_PART_B);
					indexSound = 2;
					break;
				case 3:
					listMoves.Add (Tags.MOVE_PART_C);
					listMoves.Add (Tags.MOVE_PART_B);
					indexSound = 4;
					break;
				case 4:
					listMoves.Add (Tags.MOVE_PART_D);
					listMoves.Add (Tags.MOVE_PART_B);
					indexSound = 1;
					break;
				case 5:
					listMoves.Add (Tags.MOVE_PART_C);
					listMoves.Add (Tags.MOVE_PART_D);
					indexSound = 3;
					break;
				}
			}
			data.partsWantMoving = listMoves;
			data.audioIndex = indexSound;
		} else {
			data = GetPatternByIndex (patternConst, Random.Range (0, 3));
		}

		return data;
	}

}
