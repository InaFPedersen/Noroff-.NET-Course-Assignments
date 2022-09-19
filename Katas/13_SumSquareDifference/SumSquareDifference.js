const sumSquare = (n) => {
    let sumSquare = 0;
    let sum = 0;
    for(let i = 0; i <= n; i++){
        sumSquare += i**2, sum += i;
    }
    console.log(sum**2 - sumSquare);
}

sumSquare(100);
