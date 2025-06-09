using Handelabra;
using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;

namespace Reliquary.GoldSplits
{
    public class GoldSplitsCharacterCardController : HeroCharacterCardController
    {
        public GoldSplitsCharacterCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {

        }

        public override IEnumerator UseIncapacitatedAbility(int index)
        {
            yield break;
        }

        public override IEnumerator UsePower(int index = 0)
        {
            // "Draw a card. ..."
            IEnumerator coroutine = GameController.DrawCard(HeroTurnTaker);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(coroutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(coroutine);
            }

            // "... Discard a card."
            coroutine = GameController.SelectAndDiscardCard(HeroTurnTakerController);
            if (base.UseUnityCoroutines)
            {
                yield return base.GameController.StartCoroutine(coroutine);
            }
            else
            {
                base.GameController.ExhaustCoroutine(coroutine);
            }

            yield break;
        }
    }
}