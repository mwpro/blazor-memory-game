using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class CardsListExtensions // todo could be a class
{
    public static bool CanFlipNextCard(this IList<CardData> cards)
    {
        return cards.Count(x => !x.IsReveled && x.IsVisible) < 2;
    }

    public static IEnumerable<CardData> FlippedCards(this IList<CardData> cards)
    {
        return cards.Where(x => !x.IsReveled && x.IsVisible);
    }

    public static IEnumerable<CardData> CardsWithSymbol(this IList<CardData> cards, string symbol) => cards.Where(x => x.Value == symbol);
    public static bool AreAllCardsFlipped(this IEnumerable<CardData> cards) => cards.All(x => x.IsVisible);

    public static bool IsGameWon(this IList<CardData> cards) => cards.All(x => x.IsReveled);
}

public class CardData
{
    public CardData(string value)
    {
        Value = value;
        IsVisible = false;
        IsReveled = false;
    }

    public bool Flip()
    {
        if (IsVisible || IsReveled)
        {
            return false;
        }

        IsVisible = true;
        return true;
    }

    public bool Reveal()
    {
        IsReveled = true;
        return true;
    }

    public bool Hide()
    {
        if (!IsVisible || IsReveled)
        {
            return false;
        }

        IsVisible = false;
        return true;
    }

    public bool IsVisible { get; private set; }
    public bool IsReveled { get; private set; }
    public string Value { get; } 

    
}