using System;
using Cards2;

class Program    // create class
{
    static void Main()
    { 
        string input = Console.ReadLine();
        

        // declare a deck variable and create a deck object
        // DON'T SHUFFLE THE DECK
        Deck deck = new Deck(); // Ensure Deck() initializes itself with cards

        // Ensure deck is not empty before dealing
        if (deck == null)
        {
            Console.WriteLine("Error: Deck could not be initialized.");
            return;
        }

        // Create arrays to hold player hands
        Card[] player1 = new Card[2];
        Card[] player2 = new Card[3]; // Players 2 and 3 will get an extra card
        Card[] player3 = new Card[3];
        Card[] player4 = new Card[2];

        // Function to deal a card safely
        Card DealSafely()
        {
            if (deck.CardsRemaining() > 0) // Assuming Deck has a CardsRemaining() method
                return deck.DealCard();
            else
            {
                Console.WriteLine("Error: Not enough cards in the deck.");
                return null; // Prevents crashing if there aren't enough cards
            }
        }

        // deal 2 cards each to 4 players
        player1[0] = DealSafely();
        player2[0] = DealSafely();
        player3[0] = DealSafely();
        player4[0] = DealSafely();

        player1[1] = DealSafely();
        player2[1] = DealSafely();
        player3[1] = DealSafely();
        player4[1] = DealSafely();

        // deal 1 more card to players 2 and 3
        player2[2] = DealSafely();
        player3[2] = DealSafely();

        // flip all the cards over
        void FlipCards(Card[] playerCards)
        {
            foreach (var card in playerCards)
            {
                if (card != null) // Prevents null reference errors
                    card.Flip();
            }
        }

        FlipCards(player1);
        FlipCards(player2);
        FlipCards(player3);
        FlipCards(player4);

        // Function to print a player's cards safely
        void PrintPlayerCards(string playerName, Card[] playerCards)
        {
            Console.WriteLine($"\n{playerName}'s cards:");
            foreach (var card in playerCards)
            {
                if (card != null)
                    Console.WriteLine(card);
                else
                    Console.WriteLine("[No card available]");
            }
        }

        // print the cards for each player
        PrintPlayerCards("Player 1", player1);
        PrintPlayerCards("Player 2", player2);
        PrintPlayerCards("Player 3", player3);
        PrintPlayerCards("Player 4", player4);
    }
}
