using RimWorld;

namespace EB
{
    class CompProperties_PoweredFireOverlay : CompProperties_FireOverlay
    {
        public CompProperties_PoweredFireOverlay()
        {
            this.compClass = typeof(CompPoweredFireOverlay);
        }
    }

	public class CompPoweredFireOverlay : CompFireOverlay
	{
		protected CompPowerTrader poweredComp;

		public override void PostDraw()
		{
			if (this.poweredComp?.PowerOn == true)
				base.PostDraw();
		}

		public override void PostSpawnSetup(bool respawningAfterLoad)
		{
			base.PostSpawnSetup(respawningAfterLoad);
			this.poweredComp = this.parent.GetComp<CompPowerTrader>();
		}
	}
}
