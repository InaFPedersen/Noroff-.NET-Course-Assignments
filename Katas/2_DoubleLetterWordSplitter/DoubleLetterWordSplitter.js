

const arrayOfWords = ['Letter', 'Really', 'Happy', 'Shall', 'Tool', 'Mississippi', 'Easy'];
const resultWordsArray = [];



function splitOnDoubleLetter(givenWord) {
    
    let previousChar = null;
    let newWord = ""

    for(nextChar of givenWord) {
        if(previousChar === nextChar) newWord += " ";
        newWord += nextChar;
        previousChar = nextChar;
    }
    const words = newWord.split(" ");
    if(words.length > 1) {
        return words;
    }
    else {
        return [];
    }

}
console.log("Letter turns into: " + splitOnDoubleLetter('Letter'));
console.log("Really turns into: " + splitOnDoubleLetter('Really'));
console.log("Happy turns into: " + splitOnDoubleLetter('Happy'));
console.log("Shall turns into: " + splitOnDoubleLetter('Shall'));
console.log("Tool turns into: " + splitOnDoubleLetter('Tool'));
console.log("Mississippi turns into: " + splitOnDoubleLetter('Mississippi'));
console.log("Easy turns into: " + splitOnDoubleLetter('Easy'));


