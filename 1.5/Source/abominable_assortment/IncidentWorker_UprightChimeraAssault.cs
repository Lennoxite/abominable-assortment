using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using Verse.AI.Group;
namespace ABM_ASS
{
	public class IncidentWorker_UprightChimeraAssault : IncidentWorker
	{
		// Token: 0x060064BB RID: 25787 RVA: 0x0021ABE8 File Offset: 0x00218DE8
		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			parms.faction = Faction.OfEntities;
			parms.raidArrivalMode = PawnsArrivalModeDefOf.EdgeWalkIn;
			PawnGroupMakerParms defaultPawnGroupMakerParms = IncidentParmsUtility.GetDefaultPawnGroupMakerParms(AbAss_PawnGroupKindDefOf.AbomAss_UprightChimeras, parms, false);
			float num = Faction.OfEntities.def.MinPointsToGeneratePawnGroup(AbAss_PawnGroupKindDefOf.AbomAss_UprightChimeras, null);
			if (parms.points < num)
			{
				parms.points = (defaultPawnGroupMakerParms.points = num * 2f);
			}
			List<Pawn> list = PawnGroupMakerUtility.GeneratePawns(defaultPawnGroupMakerParms, true).ToList<Pawn>();
			if (!parms.raidArrivalMode.Worker.TryResolveRaidSpawnCenter(parms))
			{
				return false;
			}
			parms.raidArrivalMode.Worker.Arrive(list, parms);
			if (AnomalyIncidentUtility.IncidentShardChance(parms.points))
			{
				AnomalyIncidentUtility.PawnShardOnDeath(list.RandomElement<Pawn>());
			}
			LordMaker.MakeNewLord(Faction.OfEntities, new LordJob_ChimeraAssault(), parms.target as Map, list);
			base.SendStandardLetter("Upright Chimeras", "A group of upright chimeras are stalking your colony! They will watch your colonists carefully before striking without mercy and vanishing back into the shadows.", LetterDefOf.ThreatSmall, parms, list, Array.Empty<NamedArgument>());
			return true;
		}
	}
}
