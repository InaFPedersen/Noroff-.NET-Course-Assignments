//let alphabet = "abcdefghijklmnopqrstuvwxyz";
//let newAlphabet = "";

//This function has a algorithm that looks ahead n characters!
//It also wraps around back to the begining.
/*const shift = (n) => {
    for(let j = 0; j < alphabet.length; j++) {
        let offset = (j + n) % alphabet.length;
        newAlphabet += alphabet[offset];
        
    }
}

const caesarCipher = (message, n) => {
    n = shift();
    let result = "";
    message = message.toLowerCase();
    for(let i = 0; i < message.length; i++) {
        let index = alphabet.indexOf(message[i]);
        result += newAlphabet[index];
    }
    return result;
}*/

const lowerCaseAlphabet = "abcdefghijklmnopqrstuvwxyz";
const upperCaseAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
const characterChange = (sentence, shiftPositions) => {
    let reult;
    let changed = false;

    for(let i = 0; i < upperCaseAlphabet.length; i++) {
        if(sentence === upperCaseAlphabet[i]) {
            reult = upperCaseAlphabet[(i + shiftPositions) % 26]
            changed = true;
        }
    }

    if(!changed) {
        for(let i = 0; i < lowerCaseAlphabet.length; i++) {
            if(sentence === lowerCaseAlphabet[i]){
                reult = lowerCaseAlphabet[(i + shiftPositions) % 26]
                changed = true;
            }
        }
    

        if(!changed) {
            if(sentence === " ") {
            reult = " "
            }
            else if(sentence === "-"){
            reult = "-"
            }
        }
    }
    return reult
}

const caesarCipher = (string, times) => {
    let ciphered = ""
    for(let i = 0; i < string.length; i++) {
        ciphered += characterChange(string[i], times)
    }
    return ciphered
}

console.log(caesarCipher("Always-Look-on-the-Bright-Side-of-Life", 5));
console.log(caesarCipher("A friend in need is a friend indeed", 20));
console.log(caesarCipher("Everything happens for a reason", 10));
