using System;
using System.Text;
using CardDeck.ConsoleUI.Constants;
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
                    else if (IsTopRankPosition(h, w))
                    {
                        var rank = GetCardRank(card.Rank);
                        builder.Append(rank);
                        w += (rank.Length - 1);
                    }
                    else if (IsBottomRankPosition(h, w))
                    {
                        var rank = GetCardRank(card.Rank);
                        var lengthToRemove = rank.Length - 1;
                        builder.Remove(builder.Length - lengthToRemove, lengthToRemove);
                        builder.Append(rank);
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

        private static string GetCardRank(CardRank rank)
        {
            return rank switch
            {
                CardRank.Ace => CardRankSymbol.Ace,
                CardRank.Two => CardRankSymbol.Two,
                CardRank.Three => CardRankSymbol.Three,
                CardRank.Four => CardRankSymbol.Four,
                CardRank.Five => CardRankSymbol.Five,
                CardRank.Six => CardRankSymbol.Six,
                CardRank.Seven => CardRankSymbol.Seven,
                CardRank.Eight => CardRankSymbol.Eight,
                CardRank.Nine => CardRankSymbol.Nine,
                CardRank.Ten => CardRankSymbol.Ten,
                CardRank.Jack => CardRankSymbol.Jack,
                CardRank.Queen => CardRankSymbol.Queen,
                CardRank.King => CardRankSymbol.King,
                _ => CardRankSymbol.Unknown
            };
        }

        private static char GetCardSuitCode(CardSuit suit)
        {
            return suit switch
            {
                CardSuit.Clubs => CardSuitSymbol.Clubs,
                CardSuit.Diamonds => CardSuitSymbol.Diamonds,
                CardSuit.Hearts => CardSuitSymbol.Hearts,
                CardSuit.Spades => CardSuitSymbol.Spades,
                _ => CardSuitSymbol.Unknown,
            };
        }

        private static bool IsSuitPosition(int h, int w)
        {
            return (h == height / 2) && (w == width / 2);
        }

        private static bool IsTopRankPosition(int h, int w)
        {
            return (h == 1 && w == 1);
        }

        private static bool IsBottomRankPosition(int h, int w)
        {
            return (h == height - 2 && w == width - 2);
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
