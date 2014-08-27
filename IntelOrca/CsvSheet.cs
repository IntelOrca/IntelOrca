#region Copyright (c) Ted John. 2014. All rights reserved.

// Copyright (c) Ted John. 2014. All rights reserved.
//
// This source is subject to a License.
// Please see the license.txt file for more information.
// All other rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntelOrca
{
	/// <summary>
	/// Class for reading and writing CSV files.
	/// </summary>
	public class CsvSheet
	{
		private List<List<string>> mRows = new List<List<string>>();
		private int mColumns = 0;

		public CsvSheet()
		{
		}

		public CsvSheet(string filename)
		{
			using (FileStream fs = new FileStream(filename, FileMode.Open))
				Load(fs);
		}

		public CsvSheet(Stream stream)
		{
			Load(stream);
		}

		private void Load(Stream stream)
		{
			mRows = new List<List<string>>();
			using (StreamReader streamReader = new StreamReader(stream)) {
				string line;
				while ((line = streamReader.ReadLine()) != null)
					mRows.Add(new List<string>(ProcessLine(line)));
			}

			CalculateColumns();
		}

		public void Save(string filename)
		{
			using (FileStream fs = new FileStream(filename, FileMode.Create))
				Save(fs);
		}

		public void Save(Stream stream)
		{
			using (StreamWriter streamWriter = new StreamWriter(stream)) {
				foreach (List<string> row in mRows) {
					for (int i = 0; i < row.Count - 1; i++)
						streamWriter.Write("{0},", FormatAsCSV(row[i]));
					if (row.Count > 0)
						streamWriter.Write(FormatAsCSV(row[row.Count - 1]));

					streamWriter.WriteLine();
				}
			}
		}

		private string FormatAsCSV(string cell)
		{
			if (cell.Contains('"'))
				cell = cell.Replace("\"", "\"\"");
			if (cell.Contains(",") || cell.StartsWith("\"") || cell.EndsWith("\""))
				cell = String.Format("\"{0}\"", cell);
			return cell;
		}

		private string Get(int x, int y)
		{
			if (x < 0 || y < 0)
				throw new ArgumentOutOfRangeException();

			if (y >= mRows.Count)
				return String.Empty;

			List<string> row = mRows[y];
			if (x >= row.Count)
				return String.Empty;

			return row[x];
		}

		private void Set(int x, int y, string value)
		{
			if (x < 0 || y < 0)
				throw new ArgumentOutOfRangeException();

			// Create rows until y is on the list
			while (y >= mRows.Count)
				mRows.Add(new List<string>());

			List<string> row = mRows[y];

			// Create cells until x is on the list
			while (x >= row.Count)
				row.Add(String.Empty);

			// Set the cell
			row[x] = value;

			// Recalculate the columns
			CalculateColumns();
		}

		private void CalculateColumns()
		{
			mColumns = mRows.Max(row => row.Count);
		}

		private string[] ProcessLine(string line)
		{
			List<string> cells = new List<string>();
			using (StringReader sr = new StringReader(line)) {
				string cell;
				while ((cell = GetNextCell(sr)) != null)
					cells.Add(cell);
			}

			return cells.ToArray();
		}

		private string GetNextCell(StringReader sr)
		{
			// Check if at end of the line
			if (sr.Peek() == -1)
				return null;

			int spacesToAdd = 0;
			bool inQuotes = false;
			StringBuilder cellsb = new StringBuilder();
			while (sr.Peek() != -1) {
				char c = (char)sr.Read();

				// Ignore whitespace at start
				if (Char.IsWhiteSpace(c) && !inQuotes && String.IsNullOrEmpty(cellsb.ToString()))
					continue;

				// Check if comma and not in double quotes
				if (c == ',' && !inQuotes)
					break;

				// Check if space and not in quotes, for trimming
				if (c == ' ' && !inQuotes) {
					spacesToAdd++;
					continue;
				} else {
					cellsb.Append(new String(' ', spacesToAdd));
					spacesToAdd = 0;
				}

				// Check if two double quotes in succession
				if (c == '"' && (char)sr.Peek() == '"') {
					sr.Read();
					cellsb.Append('"');
					continue;
				}

				// Check if double quotes
				if (c == '"') {
					inQuotes = !inQuotes;
					continue;
				}

				// Append character
				cellsb.Append(c);
			}

			// Return the cell
			return cellsb.ToString();
		}

		public string this[int x, int y]
		{
			get
			{
				return Get(x, y);
			}
			set
			{
				Set(x, y, value);
			}
		}

		public int Rows
		{
			get
			{
				return mRows.Count;
			}
		}

		public int Columns
		{
			get
			{
				return mColumns;
			}
		}
	}
}
