using Handelabra.Sentinels.Engine.Controller;
using Handelabra.Sentinels.Engine.Model;
using System.Collections;
using System;
using System.Linq;
using System.Security.Cryptography;

/**
 * Gold splits has a seriels of "momentum" cards that all care about how many cards have been discarded so far this turn
 */
namespace Reliquary.GoldSplits
{
    public class MomentumCardController : CardController
    {
        public MomentumCardController(Card card, TurnTakerController turnTakerController) : base(card, turnTakerController)
        {
            Func<string> output = () => {
                return CardsDiscardedThisTurn() + " cards have been discarded this turn.";
            };
            SpecialStringMaker.ShowSpecialString(output);
        }

        protected int CardsDiscardedThisTurn()
        {
            return this.Journal.DiscardCardEntriesThisTurn().Where(dce => dce.FromLocation == HeroTurnTaker.Hand).Count();
        }
    }
}
