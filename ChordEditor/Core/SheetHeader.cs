﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordEditor.Core
{



	[Serializable()]
	public class SheetHeader
	{
		public enum SheetProgress
		{ Deleted, Added, Verified, Reviewed, Locked }

		public delegate void SheetHeaderDelegate(SheetHeader sh);
		public static event SheetHeaderDelegate HeaderChanged;

		private string mFileName;
		private DateTime mFileDate;
		private long mFileSize;
		private Dictionary<string, string> mMetaData;

		[NonSerialized()]
		private Dictionary<string, string> mOMetaData;
		[NonSerialized()]
		private SharpSvn.SvnStatus mSvnStatus;
		[NonSerialized()]
		private bool mSvnDeletable;

		public SheetHeader()
			: this(Guid.NewGuid().ToString() + ".cpw")
		{
			SheetAuthor = SVN.Username;
		}

		public SheetHeader(string filename)
		{
			mMetaData = new Dictionary<string, string>();
			mOMetaData = new Dictionary<string, string>();
			mFileName = System.IO.Path.GetFileName(filename).ToLower();
			UpdateFileInfo();
		}

		public string FilePath
		{ get { return SVN.CurrentFolder + FileName; } }


		internal void LoadFromStream(System.IO.StreamReader sr)
		{
			mMetaData.Clear();
			string line = null;
			while (!sr.EndOfStream && (line = sr.ReadLine()) != "") //stringa vuota separa header dai dati
			{
				int index;
				if (line.StartsWith("{") && line.EndsWith("}") && (index = line.IndexOf(':')) >= 0)
					SetMeta(line.Substring(1, index - 1), line.Substring(index + 1, line.Length - index - 2));
			}
		}

		internal void BackupStatus()
		{
			mOMetaData = new Dictionary<string, string>();
			foreach (KeyValuePair<string, string> kvp in mMetaData)
				mOMetaData.Add(kvp.Key, kvp.Value);
		}

		public string FileName
		{ get { return mFileName; } }

		public string Title
		{
			get { return GetMeta("title"); }
			set { SetMeta("title", value); }
		}

		public string Artist
		{
			get { return GetMeta("subtitle"); }
			set { SetMeta("subtitle", value); }
		}

		public string SheetCategory
		{
			get { return GetMeta("sheetcategory"); }
			set { SetMeta("sheetcategory", value); }
		}

		public string SheetAuthor
		{
			get { return GetMeta("sheetauthor"); }
			set { SetMeta("sheetauthor", value); }
		}

		public string SheetRVName
		{ get { return Progress >= SheetProgress.Reviewed ? SheetRevisor : VerifiedBy; } }

		public string SheetRevisor
		{
			get { return GetMeta("sheetrevisor"); }
			set { SetMeta("sheetrevisor", value); }
		}

		public string LockedBy
		{
			get { return GetMeta("lockedby"); }
			set { SetMeta("lockedby", value); }
		}

		public string VerifiedBy
		{
			get { return GetMeta("verifiedby"); }
			set { SetMeta("verifiedby", value); }
		}

		public int Index
		{
			get
			{
				string idx = GetMeta("index");
				return idx == null ? -1 : int.Parse(idx);
			}
			set { SetMeta("index", value.ToString()); }
		}

		public SheetProgress Progress
		{
			get
			{
				if (Deletable)
					return SheetProgress.Deleted;
				else
					return GetMeta("sheetprogress") == null ? SheetProgress.Added : (SheetProgress)Enum.Parse(typeof(SheetProgress), GetMeta("sheetprogress"));
			}
			set { SetMeta("sheetprogress", value.ToString()); }
		}

		public List<string> Tags
		{
			get
			{
				string tags = GetMeta("tags");
				if (tags != null)
					return new List<string>(tags.Split(",".ToCharArray()));
				else
					return new List<string>();
			}
			set
			{
				StringBuilder sb = new StringBuilder();
				foreach (string tag in value)
				{
					sb.Append(tag);
					sb.Append(",");
				}
				if (sb.Length > 0)
					sb.Length = sb.Length - 1;

				SetMeta("tags", sb.ToString());
			}
		}

		private string GetMeta(string key)
		{
			if (key == null || key.Trim().Length == 0)
				throw new InvalidOperationException("Empty string not allowed in file metadata!");

			key = key.Trim().ToLower();

			if (mMetaData.ContainsKey(key))
				return mMetaData[key];
			else
				return null;
		}

		private void SetMeta(string key, string value)
		{
			if (key == null || key.Trim().Length == 0)
				throw new InvalidOperationException("Empty key not allowed in file metadata!");

			key = key.Trim().ToLower();

			if ((value == null || value.Trim().Length == 0))
			{
				if (mMetaData.ContainsKey(key))
					mMetaData.Remove(key);
				//else do not add it
			}
			else
			{
				value = value.Trim();
				if (mMetaData.ContainsKey(key))
					mMetaData[key] = value;
				else
					mMetaData.Add(key, value);
			}

			if (HeaderChanged != null)
				HeaderChanged(this);
		}

		internal void Write(System.IO.StreamWriter sw)
		{
			WriteNoNull(sw, "title");
			WriteNoNull(sw, "subtitle");
			WriteNoNull(sw, "sheetcategory");
			WriteNoNull(sw, "index");
			WriteNoNull(sw, "tags");
			WriteNoNull(sw, "sheetprogress");
			WriteNoNull(sw, "sheetauthor");
			WriteNoNull(sw, "sheetrevisor");
			WriteNoNull(sw, "lockedby");
			WriteNoNull(sw, "verifiedby");
		}

		private void WriteNoNull(System.IO.StreamWriter sw, string key)
		{
			string value = GetMeta(key);
			if (key != null && value != null && key.Length > 0 && value.Length > 0)
				sw.WriteLine("{{{0}:{1}}}", key, value);
		}

		public bool MemoryHasChanges
		{
			get
			{
				if (mMetaData.Count != mOMetaData.Count)
					return true;

				foreach (KeyValuePair<string, string> kvp in mMetaData)
					if (!mOMetaData.ContainsKey(kvp.Key) || mOMetaData[kvp.Key] != kvp.Value)
						return true;

				return false;
			}
		}

		private bool FileHasChanges()
		{
			if (GetFileDate() != mFileDate)
				return true;
			else if (GetFileSize() != mFileSize)
				return true;
			else
				return false;
		}

		private long GetFileSize()
		{
			if (System.IO.File.Exists(FilePath))
			{
				System.IO.FileInfo fi = new System.IO.FileInfo(FilePath);
				return fi.Length;
			}

			return 0;
		}

		private DateTime GetFileDate()
		{
			if (System.IO.File.Exists(FilePath))
				return System.IO.File.GetLastWriteTimeUtc(FilePath);
			else
				return DateTime.UtcNow;
		}

		public void UpdateFileInfo()
		{
			mFileDate = GetFileDate();
			mFileSize = GetFileSize();
		}



		public void ReloadChangedHeader()
		{
			if (FileHasChanges())
				ReloadHeader();
		}

		public void ReloadHeader()
		{
			using (System.IO.StreamReader sr = new System.IO.StreamReader(FilePath))
				LoadFromStream(sr);
			UpdateFileInfo();
		}

		public override bool Equals(object obj)
		{
			SheetHeader other = obj as SheetHeader;
			return other != null && other.FilePath == FilePath;
		}

		public override int GetHashCode()
		{
			return FilePath.GetHashCode();
		}

		public string StatusString
		{
			get
			{
				if (SVNStatus == SharpSvn.SvnStatus.Zero)
					return "";
				else if (SVNStatus == SharpSvn.SvnStatus.Added)
					return "Added";
				else if (SVNStatus == SharpSvn.SvnStatus.Modified)
					return "Modified";
				else if (SVNStatus == SharpSvn.SvnStatus.Normal)
					return "Updated";
				else
					return SVNStatus.ToString();
			}
		}

		public SharpSvn.SvnStatus SVNStatus
		{
			get { return mSvnStatus; }
			set { mSvnStatus = value; }
		}

		public bool Deletable
		{
			get { return mSvnDeletable; }
			set { mSvnDeletable = value; }
		}
	}
}
