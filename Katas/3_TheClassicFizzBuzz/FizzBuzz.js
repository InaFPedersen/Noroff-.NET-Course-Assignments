//This function runs when page is loaded
function printNumbers() {
    const myNumber = 31;

        for(let i = 1; i < myNumber; i++) 
        {
            if(i % 3 === 0 && i % 5 === 0)
            {
                console.log("FizzBuzz");

            }
            else if( i % 3 === 0) 
            {
                console.log("Fizz");
            }
            else if( i % 5 === 0) 
            {
                console.log("Buzz");
            }
            else 
            {
                console.log(i);
            }
        }
    }


