// JavaScript source code


let testWord = "Tesst";
const resultArray = [];
//let result = "";

function splitOnDoubleLetter(givenWord) {

    console.log(givenWord.length);

    let positionCounter = 0;

    for (i = givenWord.length - 1; i >= 0; i--) {

        console.log(i);
        console.log(givenWord[positionCounter]);

        let firstLetterToCheckPosition = positionCounter;
        let secondLetterToCheckPosition = positionCounter + 1;

        if (givenWord[firstLetterToCheckPosition] === givenWord[secondLetterToCheckPosition]) {

            console.log("double letter");
            return givenWord.split(givenWord[firstLetterToCheckPosition]);
        }

        positionCounter++;
    }
}

resultArray.push(splitOnDoubleLetter(testWord));
console.log(resultArray);
