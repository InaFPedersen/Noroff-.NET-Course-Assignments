//Function to count how many times
//the deck has to shuffle before it is the same
const shuffleCount = (num) => {
    const deck = createDeck(num);
    let shuffledDeck = faroShuffle(deck);
    let count = 1;

    while (!equalArrayCheck(deck, shuffledDeck)) {
        shuffledDeck = faroShuffle(shuffledDeck);
        count++;
    }
    return count;
};

//Function to create deck
const createDeck = (size) => {
    let deck = [];
    for (let i = 1; i <= size; i++) {
        deck.push(i);
    }
    return deck;
};

//Function to shuffle the card decks
const faroShuffle = (deck) => {
    let firstHalf = deck.slice(0, deck.length / 2); // [1, 2, 3, 4]
    let secondHalf = deck.slice(deck.length / 2);   // [5, 6, 7, 8]
    let shuffledDeck = [];

    for (let i = 0; i < firstHalf.length; i++) {
        shuffledDeck.push(firstHalf[i], secondHalf[i]); // [1, 5, 2, 6, 3, 7, 4, 8]
    }

    return shuffledDeck;
};
//Function to check if both arrays are the same or not
const equalArrayCheck = (array1, array2) => {
    if (array1.length !== array2.length) {
        return false;
    }

    // Checks if all items exist and are in the same order
    for (let i = 0; i < array1.length; i++) {
        if (array1[i] !== array2[i]) {
            return false;
        }
    }

    return true;
};


console.log("shuffleCount(8) has: " + shuffleCount(8) + " shuffles");
console.log("shuffleCount(14) has: " + shuffleCount(14) + " shuffles");
console.log("shuffleCount(52) has: " + shuffleCount(52) + " shuffles");