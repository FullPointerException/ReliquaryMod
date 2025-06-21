using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Reliquary.GoldSplits
{
    public class SonicBoomCardController : MomentumCardController
    {
        public SonicBoomCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
            Func<string> output = () => {
                return HeroTurnTakerController.NumberOfCardsInHand + " cards in hand.";
            };
            SpecialStringMaker.ShowSpecialString(output);
        }

        public override IEnumerator Play()
        {
            // "Discard your hand. ..."
            IEnumerator coroutine = GameController.DiscardHand(HeroTurnTakerController, optional: false, storedResults: null, TurnTaker, GetCardSource());
            if (UseUnityCoroutines)
            {
                yield return GameController.StartCoroutine(coroutine);
            }
            else
            {
                GameController.ExhaustCoroutine(coroutine);
            }

            // "... {GoldSplits} deals X sonic damage to up to X targets, where X is the number of cards you have discarded this turn."
            // TODO figure out a way to let the player choose an order
            int x = CardsDiscardedThisTurn();
            coroutine = GameController.SelectTargetsAndDealDamage(
                DecisionMaker, new DamageSource(GameController, CharacterCard), amount: x, DamageType.Sonic, numberOfTargets: x, optional: false, requiredTargets: 0, cardSource: GetCardSource());
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
