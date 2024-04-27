using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using Verse.Sound;
namespace ABM_ASS
{
    public class CompTargetEffect_TameChimera : CompTargetEffect
	{
        public override bool CanApplyOn(Thing target)
		{
			Pawn pawn;
			if ((pawn = (target as Pawn)) != null)
			{
				if (pawn.kindDef != AbAss_PawnKindDefOf.AbomAss_Chimera)
					return false;
			} else {
				return false;
			}
            return base.CanApplyOn(target);
        }
        // Token: 0x06009CBC RID: 40124 RVA: 0x0034EF14 File Offset: 0x0034D114
        public override void DoEffectOn(Pawn user, Thing target)
		{
			Pawn pawn;
			if ((pawn = (target as Pawn)) != null)
			{
				if (pawn.kindDef != AbAss_PawnKindDefOf.AbomAss_Chimera)
                {
					return;
                }
				IntVec3 pos = pawn.PositionHeld;
				Map mp = pawn.MapHeld;
				int indx = PawnGraphicUtils.GetGraphicIndex(pawn);
				
				pawn.Destroy(DestroyMode.Vanish);

				PawnKindDef kind;
				switch (indx)
                {
					default:
					case -1:
						kind = AbAss_PawnKindDefOf.AbomAss_ChimeraTamed;
						break;
                }

				Pawn pawn2 = PawnGenerator.GeneratePawn(new PawnGenerationRequest(kind, Faction.OfPlayer, PawnGenerationContext.NonPlayer,
					-1, false, false, false, false, true, 0f, false, false, false, false, false, false, false, false, false, 0f, 0f, null, 0f, null, null, null, null, null,
					null, null, null, null, null, null, null, false));

				Pawn pawn3 = (Pawn)GenSpawn.Spawn(pawn2, pos, mp, WipeMode.Vanish);
				SoundDefOf.Designate_Tame.PlayOneShot(new TargetInfo(pawn3.PositionHeld, pawn3.MapHeld));
				EffecterDefOf.ChimeraRage.Spawn(pawn3.Position, pawn3.Map, 1f).Cleanup();
			}

		}
		}
	}
}
