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
    public class AbAss_PawnGroupKindDefOf
    {

        static AbAss_PawnGroupKindDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(AbAss_PawnGroupKindDefOf));
        }

        public static PawnGroupKindDef AbomAss_UprightChimeras;
    }
}
