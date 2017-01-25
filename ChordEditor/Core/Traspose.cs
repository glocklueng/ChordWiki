﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{
    public enum ChordNotation
	{ Unknown, Italian, American }

	public class Chord
	{
		public Chord(string note, string variant, ChordNotation notation)
		{
			mNotation = notation;
			mNote = note;
			mVariant = variant;
		}

		private ChordNotation mNotation;
 		private string mNote;
		private string mVariant;
	}

    public class NotationInfo
    {
        public NotationInfo(ChordNotation notation, List<string> notes, Dictionary<string, string> replacement, string desc)
        {
            mNotation = notation;
            mNotes = notes;
            mUpperNotes = notes.ConvertAll(s => s.ToUpper());
            mReplacement = replacement;
            mDescription = desc;
        }

        private readonly ChordNotation mNotation;
        private readonly List<string> mNotes;
        private readonly List<string> mUpperNotes;
        private readonly Dictionary<string, string> mReplacement;
        private readonly string mDescription;

        public string Description
        { get { return mDescription; } }

		//public string Ord2Chord(int index)
		//{ return mNotes[index]; }

		//public int Chord2Ord(string chord)
		//{ return mUpperNotes.IndexOf(chord.ToUpper()); }

		public bool MatchAnyChordNote(string chord)
		{return mUpperNotes.Any(n => chord.ToUpper().StartsWith(n));}

		internal string NormalizeChord(string text)
		{
			string matchtext = text.ToUpper();
			foreach (string un in mUpperNotes)
				if (matchtext.StartsWith(un))
					return mNotes[mUpperNotes.IndexOf(un)] + text.Substring(un.Length); //if match

			return text; //if no match
		}

	}

    public class Traspose
    {
        private static Dictionary<ChordNotation, NotationInfo> mNotations;

        static Traspose()
        {
            mNotations = new Dictionary<ChordNotation, NotationInfo>();
			mNotations.Add(ChordNotation.Italian, new NotationInfo(ChordNotation.Italian, new List<string> { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si" }, new Dictionary<string, string> { { "maj7", "7+" }, { "sus4", "4" }, { "m", "-" } }, "Italiano (Do Re Mi... Si)"));
			mNotations.Add(ChordNotation.American, new NotationInfo(ChordNotation.American, new List<string> { "C", "D", "E", "F", "G", "A", "B" }, new Dictionary<string, string> { }, "American (C D E... B)"));
        }

        public static ChordNotation WhatNotation(string chord)
        {
			foreach (KeyValuePair<ChordNotation, NotationInfo> kvp in mNotations)
				if (kvp.Value.MatchAnyChordNote(chord))
					return kvp.Key;

			return ChordNotation.Unknown;
		}

        public static string ChangeNotation(string text, ChordNotation dstN)
        {
			ChordNotation srcN = WhatNotation(text);
			if (srcN == ChordNotation.Unknown) //skip unknown chords
				return text;

			string rv = mNotations[srcN].NormalizeChord(text); //normalize source

			if (dstN != srcN) //translate
				;

            return rv;
        }

    }
}