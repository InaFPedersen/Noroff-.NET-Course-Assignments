const isAPrime = (n) => {
    if(n == 1){return false;}
    let sqrtN = Math.floor(Math.sqrt(n));
    for(let i = 2; i <= sqrtN; i++) {
        if(n % i == 0){return false;}
    }
    return true;
}

const listPrimes = (num) => {
    let primes = [];

    for(let i = 2; i <= num; i++){
        if(isAPrime(i)) {
            primes.push(i);
        }
    }
    return primes;
}

let maxNumber = 105000;
let allprimes = listPrimes(maxNumber);

console.log(allprimes);