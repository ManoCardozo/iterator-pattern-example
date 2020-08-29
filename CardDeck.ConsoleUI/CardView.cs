using System;
using System.Text;
using CardDeck.Domain.Entities;
using CardDeck.Domain.Enums;

namespace CardDeck.ConsoleUI
{
    public static class CardView
    {
        private static readonly string verticalBorder = "|";
        private static readonly string horizontalBorder = "-";
        private static readonly int height = 16;
        private static readonly int width = 22;

        public static void Render(Card card)
        {
            var builder = new StringBuilder();

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    if (IsHorizontalBorder(h))
                    {
                        builder.Append(horizontalBorder);
                    }
                    else if (IsVerticalBorder(w))
                    {
                        builder.Append(verticalBorder);
                    }
                    else if (IsRankPosition(h, w))
                    {
                        builder.Append(card.Rank);
                    }
                    else if (IsSuitPosition(h, w))
                    {
                        var suit = GetCardSuitCode(card.Suit);
                        builder.Append(suit);
                    }
                    else
                    {
                        builder.Append(" ");
                    }
                }
                builder.Append(Environment.NewLine);
            }
            Console.Write(builder);
        }

        private static object GetCardSuitCode(CardSuit suit)
        {
            return suit switch
            {
                CardSuit.Clubs => Constants.CardSuitSymbol.Clubs,
                CardSuit.Diamonds => Constants.CardSuitSymbol.Diamonds,
                CardSuit.Hearts => Constants.CardSuitSymbol.Hearts,
                CardSuit.Spades => Constants.CardSuitSymbol.Spades,
                _ => Constants.CardSuitSymbol.Unknown,
            };
        }

        private static bool IsSuitPosition(int h, int w)
        {
            return (h == height / 2) && (w == width / 2);
        }

        private static bool IsRankPosition(int h, int w)
        {
            return (h == 1 && w == 1) || (h == height - 2 && w == width - 2);
        }

        private static bool IsVerticalBorder(int w)
        {
            return w == 0 || w == width - 1;
        }

        private static bool IsHorizontalBorder(int h)
        {
            return h == 0 || h == height - 1;
        }
    }
}
