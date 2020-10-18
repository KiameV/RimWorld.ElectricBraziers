using System;
using System.Collections.Generic;
using RimWorld;
using Verse;

namespace RimWorld
{
	/// <summary>Class <c>RoomRequirement_ThingCountAnyOf</c> extends <c>RoomRequirement_ThingAnyOf</c>
	/// functionality by allowing multiple <c>ThingDef</c>s to satisfy the Room Requirement condition.
	/// </summary>
	public class RoomRequirement_ThingCountAnyOf : RoomRequirement_ThingAnyOf
    {
		/// <value>Property <c>count</c> refers to the <c>ThingDef</c> that needs to be in the room.</value>
		public int count;

		/// <summary>
		/// Describes configuration errors in the ThingDefs
		/// </summary>
		/// <returns>Configuration errors in the XML Defs</returns>
		public override IEnumerable<string> ConfigErrors()
		{
			foreach (string text in base.ConfigErrors())
			{
				yield return text;
			}

			if (this.count <= 0)
			{
				yield return "count must be larger than 0";
			}

			yield break;
		}

		/// <summary>
		/// Checks if the conditions are met within the room
		/// </summary>
		/// <param name="r"><c>Room</c> to be checked</param>
		/// <param name="p"><c>Pawn</c> to be checked (optional)</param>
		/// <returns>true if all conditions are met</returns>
		public override bool Met(Room r, Pawn p = null)
		{
			return this.Count(r) >= count;
		}

		/// <summary>
		/// Checks the total count of items specified in <c>things</c>
		/// </summary>
		/// <param name="r"><c>Room</c> to be checked</param>
		/// <returns>The number of total specified items in the room.</returns>
		public int Count(Room r)
		{
			int current = 0;

			foreach (ThingDef def in this.things)
			{
				current += r.ThingCount(def);
			}

			return current;
		}

		/// <summary>
		/// Helper method that returns translated labels of the ThingDefs
		/// </summary>
		/// <returns>Translated labels of the ThingDefs</returns>
		private string ThingLabels()
		{
			List<string> labels = new List<string>();

			foreach (ThingDef def in this.things)
			{
				labels.Add(def.label);
			}

			return String.Join(" or ".Translate(), labels.ToArray());
		}

		/// <summary>
		/// Helper method that returns GenLabel of the ThingDefs
		/// </summary>
		/// <returns>GenLabel of the ThingDefs</returns>
		private string GenLabels()
		{
			List<string> labels = new List<string>();

			foreach (ThingDef def in this.things)
			{
				labels.Add(GenLabel.ThingLabel(def, null, this.count));
			}

			return String.Join(" or ".Translate(), labels.ToArray());
		}

		/// <summary>
		/// Label to be displayed for the room requirements
		/// </summary>
		/// <param name="r"><c>Room</c> to be checked</param>
		/// <returns>Label for room requirements</returns>
		public override string Label(Room r = null)
		{
			bool flag = !this.labelKey.NullOrEmpty();
			
			string text = this.ThingLabels();

			if (flag)
			{
				text = this.labelKey.Translate().ToString();
			}
			
			if (r != null)
			{
				return string.Concat(new object[]
				{
					text,
					" ",
					this.Count(r),
					"/",
					this.count
				});
			}

			if (!flag)
			{
				return this.GenLabels();
			}

			return text + " x" + this.count;
		}

	}
}
