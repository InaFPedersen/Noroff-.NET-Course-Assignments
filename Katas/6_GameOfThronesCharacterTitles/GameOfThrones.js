const correctTitle = (givenSentence) => {

    let givenSentenceArr = [...givenSentence.toLowerCase()];

    if(!(givenSentenceArr[givenSentenceArr.length -1] === ".")) {
        givenSentenceArr.push(".");
    }

    for(let i = 0; i < givenSentenceArr.length; i++) {
        if(givenSentenceArr[i] === "," && /[a-zA-z]/g.test(givenSentenceArr[i +1])) {
            givenSentenceArr.splice(i + 1, 0, " ");
            i++;
        }
    }
    return givenSentenceArr
    .join("")
    .split(" ")
    .map((word) =>
    word === "the" || word === "in" || word === "of"
    ? word: word.charAt(0).toUpperCase() + word.slice(1)
    )
    .join(" ");
}


console.log("jOn SnoW, kINg IN thE noRth correct sentence is: " + correctTitle("jOn SnoW, kINg IN thE noRth"));
console.log("sansa stark,lady of winterfell. correct sentence is: " + correctTitle("sansa stark,lady of winterfell."));
console.log("TYRION LANNISTER, HAND OF THE QUEEN. correct sentence is: " + correctTitle("TYRION LANNISTER, HAND OF THE QUEEN."));