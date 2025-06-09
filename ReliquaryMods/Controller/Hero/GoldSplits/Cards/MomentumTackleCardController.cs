using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;
using System;
using System.Linq;

namespace Reliquary.GoldSplits
{
    public class MomentumTackleCardController : MomentumCardController
    {
        public MomentumTackleCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }

        public override IEnumerator Play()
        {
            // "{GoldSplits} deals 1 target X melee damage, where X is 1 + the number of cards you have discarded this turn."
            IEnumerator coroutine = GameController.SelectTargetsAndDealDamage(DecisionMaker, new DamageSource(GameController, CharacterCard), amount: 1 + CardsDiscardedThisTurn(), DamageType.Melee, numberOfTargets: 1, optional: false, requiredTargets: 1, cardSource: GetCardSource());
            if (UseUnityCoroutines)
            {
                yield return GameController.StartCoroutine(coroutine);
            }
            else
            {
                GameController.ExhaustCoroutine(coroutine);
            }
        }
    }
}
