
const hiddenAnagram = (str1, str2) => {
    console.log(str1 + " + " + str2 + ", would become the anagram:");
    
    //makes the sentence in string 1 & 2 lower case 
    //aswell as removing special symbols and spaces
    str1 = str1.toLowerCase().replace(/[^a-z]/g, "");
    str2 = [...str2.toLowerCase().replace(/[^a-z]/g, "")].sort().join("");
    
    for(i = 0; i <= str1.length - str2.length; i++) {
        let anagram = str1.substr(i, str2.length);
        if([...anagram].sort().join("") === str2) {
            return anagram;
            
        }
    }
    return "noutfond";
};

console.log(hiddenAnagram("An old west action hero actor", "Clint Eastwood"));
console.log(hiddenAnagram("Mr. Mojo Rising could be a song title", "Jim Morrison"));
console.log(hiddenAnagram("Banana? margaritas", "ANAGRAM"));
console.log(hiddenAnagram("D e b90it->?$ (c)a r...d,,#~", "bad credit"));
console.log(hiddenAnagram("Bright is the moon", "Bongo mirth"));
