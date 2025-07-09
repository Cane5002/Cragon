using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public abstract class Condition
{
    public int Size;

    public abstract bool Eval(List<Dice> dice, Condition[] next);
    public abstract List<int[]> Eval(int[] frequencyMap);
}

[System.Serializable]
public class Straight : Condition
{
    public Element[] ContainedElements = new Element[0];
    public int[] ContainedNumbers = new int[0];

    public override bool Eval(List<Dice> dice, Condition[] next) {
        throw new System.NotImplementedException();
    }

    public override List<int[]> Eval(int[] frequencyMap) {
        List<int[]> maps = new List<int[]>();
        //Contains elements
        int[] elementMap = new int[DiceFaceData.MAX_DICE_VALUE * 2 + 1 + DiceFaceData.ELEMENT_COUNT];
        bool containsElements = true;
        foreach (Element e in ContainedElements) {
            //Is there enough?
            if (frequencyMap[(int)e] == 0) { containsElements = false; break; }
            //Record cost
            ++elementMap[(int)e];
        }
        if (!containsElements) return maps;

        for (int start = DiceFaceData.ELEMENT_COUNT; start < frequencyMap.Length - Size; start++) {
            int[] costMap = (int[])elementMap.Clone();
            // Check if contains necessary numbers
            bool containsNumbers = true;
            foreach (int i in ContainedNumbers) {
                int number = i + DiceFaceData.MAX_DICE_VALUE + DiceFaceData.ELEMENT_COUNT;
                if (start + Size <= number || start > number) { containsNumbers = false; break; }
            }
            if (!containsNumbers) continue;

            // Check if there is an unbroken consecutive sequence
            bool consecutive = true;
            for (int i = start; i < Size; i++) {
                if (frequencyMap[i] == 0) { consecutive = false; break; }
                ++costMap[i];
            }
            if (!consecutive) continue;
            maps.Add(costMap);
        }
        return maps;
    }
}

[System.Serializable]
public class Match : Condition
{
    public bool MustMatchNumber = false;
    public int MatchNumber;
    public bool MustMatchElement = false;
    public Element MatchElement;
    public bool MustMatchParity = false;
    public bool EvenParity;

    public override bool Eval(List<Dice> dice, Condition[] next) {
        throw new NotImplementedException();
    }
    public override List<int[]> Eval(int[] frequencyMap) {
        // Basic match
        if (!MustMatchParity && !MustMatchNumber & !MustMatchElement) return GetCombinations(frequencyMap);

        // Match Parity
        if (MustMatchParity) return GetCombinationsWithParity(frequencyMap);

        List<int[]> maps = new List<int[]>();
        int[] map = new int[DiceFaceData.MAX_DICE_VALUE * 2 + 1 + DiceFaceData.ELEMENT_COUNT];
        // Match number
        if (MustMatchNumber) {
            if (frequencyMap[DiceFaceData.MAX_DICE_VALUE + DiceFaceData.ELEMENT_COUNT + MatchNumber] < Size) return maps;
            map[DiceFaceData.MAX_DICE_VALUE + DiceFaceData.ELEMENT_COUNT + MatchNumber] = Size;
        }
        // Match element
        if (MustMatchElement) {
            if (frequencyMap[(int)MatchElement] < Size) return maps;
            map[(int)MatchElement] = Size;
        }

        maps.Add(map);
        return maps;
    }

    private List<int[]> GetCombinations(int[] frequencyMap) {
        List<int[]> maps = new List<int[]>();
        // Select <Size> from frequency map -> Combinations (Dynamic programming)
        // 2 rows containing set of combinations stored as string
        // List index corresponds to number selecting
        List<HashSet<string>>[] dp = { new List<HashSet<string>>(), new List<HashSet<string>>() };
        int step = 1;
        // Iterate through each number in frequency list
        for (int i = DiceFaceData.ELEMENT_COUNT; i < frequencyMap.Length; i++) {
            // Convert number
            int number = i - DiceFaceData.ELEMENT_COUNT - DiceFaceData.MAX_DICE_VALUE;
            for (int cnt = 0; cnt < frequencyMap[number]; cnt++) {
                // Select 0 -> step
                for (int selectSize = 0; selectSize <= step; selectSize++) {
                    if (selectSize == 0) {
                        // Init Set
                        dp[step % 2].Add(new HashSet<string>());
                        dp[step % 2][0].Add("");
                        continue;
                    }
                    // Append number to each string in left set
                    foreach (string s in dp[step % 2][selectSize - 1]) s.Concat(number.ToString());

                    //init first row
                    if (step == 0) dp[step % 2][selectSize] = dp[step % 2][selectSize - 1];
                    else {
                        dp[step % 2][selectSize - 1].Union(dp[(step - 1) % 2][selectSize]);
                        dp[step % 2][selectSize] = dp[step % 2][selectSize - 1];
                    }
                }
                ++step;
            }
        }
        // Turn final set into frequency maps
        foreach (string s in dp[(step - 1) % 2][Size - 1]) {
            int[] map = new int[DiceFaceData.MAX_DICE_VALUE * 2 + 1 + DiceFaceData.ELEMENT_COUNT];
            foreach (char c in s) { ++map[c - '0']; }
            maps.Add(map);
        }

        return maps;
    }
    private List<int[]> GetCombinationsWithParity(int[] frequencyMap) {
        List<int[]> maps = new List<int[]>();
        // Select <Size> from frequency map -> Combinations
        for (int i = DiceFaceData.ELEMENT_COUNT; i < frequencyMap.Length; i++) {
            // Convert number
            int number = i - DiceFaceData.ELEMENT_COUNT - DiceFaceData.MAX_DICE_VALUE;
            // Check Parity
            if (number % 2 == (EvenParity ? 1 : 0)) continue;
            // Add to list
            for (int j = 0; j < frequencyMap[i]; j++) {

            }
        }
        return maps;
    }
}
