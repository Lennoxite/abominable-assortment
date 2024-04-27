using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
namespace ABM_ASS
{
    [DefOf]
    public class AbAss_PawnKindDefOf
    {

        static AbAss_PawnKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(AbAss_PawnKindDefOf));
        }

        public static PawnKindDef AbomAss_Chimera;
        public static PawnKindDef AbomAss_ChimeraTamed;
    }
}
