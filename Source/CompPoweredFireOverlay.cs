using System;
using UnityEngine;
using RimWorld;
using Verse;

namespace RimWorld
{
	[StaticConstructorOnStartup]
	public class CompPoweredFireOverlay : CompFireOverlay
	{
		public override void PostDraw()
		{
			if (this.poweredComp != null && !this.poweredComp.PowerOn)
			{
				return;
			}

			base.PostDraw();
		}

		// Token: 0x06005137 RID: 20791 RVA: 0x001B3FB8 File Offset: 0x001B21B8
		public override void PostSpawnSetup(bool respawningAfterLoad)
		{
			base.PostSpawnSetup(respawningAfterLoad);
			this.poweredComp = this.parent.GetComp<CompPowerTrader>();
		}

		protected CompPowerTrader poweredComp;
	}
}
