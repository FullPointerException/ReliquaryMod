using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Reliquary.GoldSplits
{
    public class RunningStartCardController : CardController
    {
        public RunningStartCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
            Func<string> output = () => {
                return HeroTurnTakerController.NumberOfCardsInHand + " cards in hand.";
            };
            SpecialStringMaker.ShowSpecialString(output);
        }

        public override IEnumerator Play()
        {
            // "Draw cards until you have at least 5 cards in your hand.",
            int cardsToDraw = 5 - HeroTurnTakerController.NumberOfCardsInHand;
            if(cardsToDraw <= 0)
            {
                yield break;
            }

            IEnumerator coroutine = GameController.DrawCards(HeroTurnTakerController, cardsToDraw);
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
