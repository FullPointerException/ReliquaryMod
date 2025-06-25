using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Reliquary.GoldSplits
{
    public class StaticDischargeCardController : MomentumCardController
    {
        public StaticDischargeCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
            // "Whenever you discard this card, ..."
            AddTrigger<DiscardCardAction>(d => d.WasCardDiscarded && d.CardToDiscard == Card, DealDamageResponse, TriggerType.DealDamage, TriggerTiming.After);
        }

        public override IEnumerator Play()
        {
            // "{GoldSplits} deals all non-hero targets 1 lightning damage."            
            IEnumerator coroutine = DealDamage(CharacterCard, card => !IsHero(card) && card.IsInPlay, amount: 1, DamageType.Lightning);
            if (UseUnityCoroutines)
            {
                yield return GameController.StartCoroutine(coroutine);
            }
            else
            {
                GameController.ExhaustCoroutine(coroutine);
            }

            yield break;
        }

        // TODO This makes this discard part work, however it's unclear what the effect is or where the effect is coming from. Possibly a custom decision?
        private IEnumerator DealDamageResponse(DiscardCardAction dca)
        {
            // "...  you may have {GoldSplits} deal up to X targets 1 lightning damage, where X is the number of cards you have discarded this turn."
            int x = CardsDiscardedThisTurn();
            IEnumerator coroutine = GameController.SelectTargetsAndDealDamage(
                DecisionMaker, new DamageSource(GameController, CharacterCard), amount: 1, DamageType.Lightning, numberOfTargets: x, optional: false, requiredTargets: 0, cardSource: new CardSource(CharacterCardController));

            if(UseUnityCoroutines)
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
