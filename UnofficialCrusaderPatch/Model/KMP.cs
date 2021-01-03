using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCP
{
    public class KMP
    {
        const int R = 0x101;
        int[,] dfa;
        ByteOrWildCard[] pattern;

        ByteOrWildCard[] searchPattern;
        ByteOrWildCard[] precedingPattern;
        ByteOrWildCard[] followingPattern;

        public KMP(ByteOrWildCard[] pattern)
        {
            this.pattern = pattern;
            int length = pattern.Length;

            List<int> wildCardIndexes = new List<int>();
            for (var i = 0; i < length; i++)
            {
                if (pattern[i].IsWildCard)
                {
                    wildCardIndexes.Add(i);
                }
            }


            int wildCardCount = wildCardIndexes.Count;
            if (wildCardCount > 0)
            {
                if (wildCardCount == 1)
                {
                    if (length - wildCardIndexes[0] > wildCardIndexes[0])
                    {
                        searchPattern = pattern.Skip(wildCardIndexes[0] + 1).ToArray();
                        precedingPattern = pattern.Take(wildCardIndexes[0] + 1).ToArray();
                        followingPattern = null;
                    }
                    else
                    {
                        searchPattern = pattern.Take(wildCardIndexes[0] - 1).ToArray();
                        followingPattern = pattern.Skip(wildCardIndexes[0] - 1).ToArray();
                        precedingPattern = null;
                    }
                }
                else
                {
                    int start = wildCardIndexes[0];
                    int diff;
                    int maxDiff = -1;
                    int searchStartIndex = 0;
                    int searchStopIndex = length;
                    for (var i = 1; i < wildCardIndexes.Count; i++)
                    {
                        diff = wildCardIndexes[i] - start;
                        if (diff > maxDiff)
                        {
                            searchStartIndex = start + 1;
                            searchStopIndex = wildCardIndexes[i];
                            maxDiff = diff;
                        }
                        start = wildCardIndexes[i];
                    }

                    if (wildCardIndexes[0] > maxDiff)
                    {
                        searchStartIndex = 0;
                        searchStopIndex = wildCardIndexes[0];
                    }

                    if (length - wildCardIndexes[wildCardIndexes.Count - 1] > maxDiff)
                    {
                        searchStartIndex = wildCardIndexes[wildCardIndexes.Count - 1] + 1;
                        searchStopIndex = length;
                    }

                    precedingPattern = new ByteOrWildCard[searchStartIndex];
                    for (var i = 0; i < searchStartIndex; i++)
                    {
                        precedingPattern[i] = pattern[i];
                    }

                    searchPattern = new ByteOrWildCard[searchStopIndex - searchStartIndex];
                    for (var i = searchStartIndex; i < searchStopIndex; i++)
                    {
                        searchPattern[i - searchStartIndex] = pattern[i];
                    }

                    followingPattern = new ByteOrWildCard[length - searchStopIndex];
                    for (var i = searchStopIndex; i < length; i++)
                    {
                        followingPattern[i - searchStopIndex] = pattern[i];
                    }

                }
            }
            else
            {
                searchPattern = pattern;
                precedingPattern = null;
                followingPattern = null;
            }

            /* Build DFA */
            int M = searchPattern.Length;
            dfa = new int[R, M];
            dfa[searchPattern[0].IntValue, 0] = 1;

            var j = 1;
            for (var X = 0; j < M; j++)
            {
                for (var c = 0; c < R; c++)
                {
                    dfa[c, j] = dfa[c, X];
                }
                dfa[searchPattern[j].IntValue, j] = j + 1;
                X = dfa[searchPattern[j].IntValue, X];
            }
        }

        public int search(byte[] data, int startOffset)
        {
            int M = searchPattern.Length;
            int N = data.Length;
            int i = startOffset, j = 0; // change i to startOffset to start search at specified position of data?

            for (; i < N && j < M; i++)
            {
                j = dfa[data[i], j];
            }
            if (j == M) return i - M;
            return -1;
        }

        public int findFirstInstance(byte[] data)
        {
            int? address = null;
            bool match = false;

            while (address != -1 && match == false)
            {
                address = search(data, address == null ? 0 : address.Value + 1); // Need to add this in case pattern matches but regions split by wildcards do not
                if (address.Value != -1)
                {
                    match = true;
                    if (precedingPattern != null && precedingPattern.Length > 0)
                    {
                        int precedingLength = precedingPattern.Length;
                        if (address.Value < precedingLength)
                        {
                            match = false;
                        }
                        else
                        {
                            for (var i = 0; i < precedingLength; i++)
                            {
                                if (!precedingPattern[i].IsWildCard && data[address.Value - precedingLength + i] != precedingPattern[i].IntValue)
                                {
                                    match = false;
                                }
                            }
                        }
                    }
                    if (followingPattern != null && followingPattern.Length > 0)
                    {
                        int followingLength = followingPattern.Length;
                        if (followingLength > data.Length - address.Value - searchPattern.Length)
                        {
                            match = false;
                        }
                        else
                        {
                            for (var i = 0; i < followingLength; i++)
                            {
                                if (!followingPattern[i].IsWildCard && data[address.Value + searchPattern.Length + i] != followingPattern[i].IntValue)
                                {
                                    match = false;
                                }
                            }
                        }
                    }
                }
            }
            if (address == -1)
            {
                return -1;
            }

            if (precedingPattern != null)
            {
                return address.Value - precedingPattern.Length;
            }
            return address.Value;
        }
    }
}
