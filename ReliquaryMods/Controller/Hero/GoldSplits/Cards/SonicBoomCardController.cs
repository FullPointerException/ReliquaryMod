using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;
using System;
using System.Linq;

namespace Reliquary.GoldSplits
{
    public class SonicBoomCardController : CardController
    {
        public SonicBoomCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
        }

        public override void AddTriggers()
        {
            // "Whenever you discard a card, ..."
            AddTrigger<DiscardCardAction>(d => d.WasCardDiscarded && d.Origin == HeroTurnTaker.Hand, DealDamageResponse, TriggerType.DealDamage, TriggerTiming.After);
        }

        private IEnumerator DealDamageResponse(DiscardCardAction dca)
        {
            // "... {GoldSplits} deals 1 target 1 sonic damage."
            IEnumerator coroutine = GameController.SelectTargetsAndDealDamage(
                DecisionMaker, new DamageSource(GameController, CharacterCard), amount: 1, DamageType.Sonic, numberOfTargets: 1, optional: false, requiredTargets: 1, cardSource: GetCardSource());
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
