﻿using RimWorld;
using System;
using System.Collections.Generic;
using Verse;
namespace AvaliMod
{
    public class IlluminateAirdrop : IncidentWorker
    {
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            List<Thing> thingList = new List<Thing>();
            thingList.Add(ThingMaker.MakeThing(AvaliDefs.AvaliNanoForge));
         ///             (ThingMaker.MakeThing(AvaliDefs.AvaliNanoForge.minfiedDef)); //Suggest replacing above code with this, prevents the placement of the ThingDef with a MinifiedThing def, preventing destruction of property and other Things
            Map target = (Map)parms.target;
            IntVec3 intVec3 = DropCellFinder.TradeDropSpot(target);
            if (RimValiUtility.PawnOfRaceCount(Faction.OfPlayer, AvaliDefs.RimVali) >= 5)
            {
                DropPodUtility.DropThingsNear(intVec3, target, (IEnumerable<Thing>)thingList);
                this.SendStandardLetter("Illuminate Airdrop", "Illuminate Airdrop", AvaliDefs.IlluminateAirdrop,parms, (LookTargets)new TargetInfo(intVec3, target, false), (NamedArgument[])Array.Empty<NamedArgument>());
            }
            return true;
        }
    }
}
