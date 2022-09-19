

const points = () => {
    let twopoint = document.getElementById("twoPoint").value;
    let threepoint = document.getElementById("threePoint").value;
    
    let totalTwoPoints =  twopoint * 2;
    let totalThreePoints =  threepoint * 3;
    
    let sum = parseFloat( totalTwoPoints + totalThreePoints);

    document.getElementById("score").innerHTML = sum;
    
}

const predictedNumbers = () => {
    const threePoints = 3;
    const twoPoints = 2;

    let threePointGoals = Math.floor(Math.random() * 100);
    let twoPointGoals = Math.floor(Math.random() * 100);

    let twoPointAchieved = twoPointGoals * twoPoints;
    document.getElementById("twoPointPredict").innerText = twoPointAchieved;
    let threePointsAchieved = threePointGoals * threePoints;
    document.getElementById("threePointPredict").innerText = threePointsAchieved;

    let sum = threePointsAchieved + twoPointAchieved;
    document.getElementById("sumPredict").innerText = sum;
    
    

    console.log("3Point goals = " + threePointGoals + ", 2Point goals = " + twoPointGoals + ", Total score " + sum);
}
/*

*/
//Videre arbeid: 
//Få hvor mange 2 point og 
//3 point til å vise i HTMl filen.

/*let twoPoints = document.getElementById("twoPoint");
console.log(twoPoints);
let threePoints = document.getElementById("threePoint");
console.log(threePoints);
//let twoPointsValue = twoPoints.value;
//let threePointsValue = threePoints.value;
let totalTwoPoints = twoPoints * 2;
let totalThreePoints = threePoints * 3;
function gameScore() {
    let score = document.getElementById("score");
    score.innerHTML = totalTwoPoints + totalThreePoints;
    return score;
}*/

//let show = "3Point goals = " + threePointGoals + ", 2Point goals = " + twoPointGoals + ", Total score " + sum;
//return document.getElementById("score").innerHTML = show;
