using System;
using UnityEngine;
using RimWorld;
using Verse;

namespace RimWorld
{
    class CompProperties_PoweredFireOverlay : CompProperties_FireOverlay
    {
        public CompProperties_PoweredFireOverlay()
        {
            this.compClass = typeof(CompPoweredFireOverlay);
        }
    }
}
