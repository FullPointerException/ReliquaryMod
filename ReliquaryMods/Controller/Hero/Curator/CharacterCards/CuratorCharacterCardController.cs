using Handelabra;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Reliquary.Curator
{
    public class CuratorCharacterCardController : HeroCharacterCardController
    {
        public CuratorCharacterCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {

        }

        public override IEnumerator UseIncapacitatedAbility(int index)
        {
            yield break;
        }

        public override IEnumerator UsePower(int index = 0)
        {
            yield break;
        }
    }
}