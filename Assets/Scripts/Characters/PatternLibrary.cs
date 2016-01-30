using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PatternLibrary {

	public const int TOTAL_PATTERNS = 6;

	public static SeduceData GetPatternByIndex(int patternConst){
		List<string> listMoves = new List<string> ();
		int indexSound = 0;
		SeduceData data = new SeduceData ();
		switch (patternConst) {
		case 0:
			listMoves.Add(Tags.MOVE_PART_A);
			listMoves.Add(Tags.MOVE_PART_C);
			indexSound = 1;
			break;
		case 1:
			listMoves.Add(Tags.MOVE_PART_D);
			listMoves.Add(Tags.MOVE_PART_C);
			indexSound = 3;
			break;
		case 2:
			listMoves.Add(Tags.MOVE_PART_A);
			indexSound = 2;
			break;
		case 3:
			listMoves.Add(Tags.MOVE_PART_A);
			listMoves.Add(Tags.MOVE_PART_B);
			break;
		case 4:
			listMoves.Add(Tags.MOVE_PART_D);
			listMoves.Add(Tags.MOVE_PART_B);
			indexSound = 1;
			break;
		case 5:
			listMoves.Add(Tags.MOVE_PART_C);
			listMoves.Add(Tags.MOVE_PART_B);
			indexSound = 2;
			break;
		}
		data.partsWantMoving = listMoves;
		data.audioIndex = indexSound;
		return data;
	}

}
