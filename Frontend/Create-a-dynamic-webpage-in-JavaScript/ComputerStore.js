//Global variables
//Part 1: The Bank variables:
let bankBalanceNr = document.getElementById("yourBankBalance");
const loanBalanceText = document.getElementById("loanBalance");
let loanBalanceNr = document.getElementById("loanBalanceNr");
const getLoanBtn = document.getElementById("getLoan");
//Part 2: The workplace:
let payBalanceNr = document.getElementById("payBalance");
const workBtn = document.getElementById("workButton");
const transfertoBankBtn = document.getElementById("transferToBank");
const repayLoanBtn = document.getElementById("repayLoanButton");
//Part 1 & 2:
loanBalanceNr = 0;
//This if checks if it is a active loan or not
if (loanBalanceNr === 0){
    activeLoan = false; //this set active loan to false
}
else if(loanBalanceNr !== 0){
    activeLoan = true; //This set active loan to true if loan balance is any number than 0
}
//Part 3
//Part 3a: The computer store, laptop selection:
const computersAvailable = document.getElementById("availableComputers");
const computerFeatures = document.getElementById("features");
//Part 3b: The computer store, info section:
const computerName = document.getElementById("computerName");
const computerDescription = document.getElementById("computerDescription");
let computerPrice = document.getElementById("computerPrice");
const buyComputerBtn = document.getElementById("buyComputer");
const pcImagePlace = document.getElementById("pcImagePlace");
let computers = [];

//Part 1 & 2
//This function runs when page is loaded in.
const start = () => {
    //The .style.visibility = "hidden" hides the text until it is made visible.
    document.getElementById("loanBalance").style.visibility = "hidden";
    document.getElementById("loanBalanceNr").style.visibility = "hidden";
    document.getElementById("repayLoanButton").style.visibility = "hidden";
    bankBalanceNr = 0; //this set the bank balance to 0 from start
    payBalanceNr = 0; //This set the pay balance to 0 from start
    updateNumbers(); //Runs the function updateNumbers
}
//This function: runs when the button 'Get Loan' is clicked
const recieveLoan = () => {
    //This is checks if active loan is false. 
    if (activeLoan === false) {
        //This prompt ask for user input of how much the user want to take in loan
        const loanAmount = prompt("Please enter the amount you wish to loan from the bank!");

        //This if checks if the amount written is more than double than you have.
        if(loanAmount <= bankBalanceNr * 2) {
            bankBalanceNr = bankBalanceNr + parseFloat(loanAmount); //This adds the loan to the bank balance
            loanBalanceNr = loanAmount; //This set the loan balance to the amount written in the prompt.
            
            //The .style.visibility = "visible" unhide the text until it is made hidden.
            document.getElementById("loanBalance").style.visibility = "visible";
            document.getElementById("loanBalanceNr").style.visibility = "visible";
            document.getElementById("repayLoanButton").style.visibility = "visible";
            activeLoan = true; //This set the active loan true.
            updateNumbers(); //Runs the function updateNumbers
        } 
        else{
            alert("You do not have enough in your bank balance, in order to loan this amount!");
        }
    }
    else {
        alert("You already have a loan in this bank, please pay back that loan before taking another!");
    }
}
//This function: runs when the button 'Work' is clicked
const work = () => {
    payBalanceNr += 100;
    document.getElementById("payBalance").innerHTML = payBalanceNr;
}
//This function: runs when the button 'transfer to bank' is clicked
const transferPayToBank = () => {
    //This if statement check if there  is a active loan or not.
    if(activeLoan === false) {
        //If it is not a active bank balance the entire pay balance is added to the bank balance
        bankBalanceNr = bankBalanceNr + payBalanceNr;
        updateNumbers() //Runs the function updateNumbers
    }
    else if (activeLoan === true) {
        //If there is a active loan 10% goes to the loan balance and the rest to bank balance
        let transferAmountToLoan = payBalanceNr * 0.1; //Takes 10% of the paybalance number
        loanBalanceNr = parseInt(loanBalanceNr - transferAmountToLoan); //Removes the 10% amount from the loan
        newpayBalanceNr = parseInt(payBalanceNr - transferAmountToLoan); //removes the 10% taken allready from paybalance
        bankBalanceNr = bankBalanceNr + newpayBalanceNr; //Takes the rest of pay and add it to bank balance
        updateNumbers(); //Runs the function updateNumbers
    }
}
//This function: runs when the button repay loan is clicked
const repayLoan = () => {
    //It takes subtracts the pay balance from the loan balance
    loanBalanceNr = loanBalanceNr - payBalanceNr;
    updateNumbers(); //Runs the function updateNumbers
}
//This function: updates the numbers after function has made changes.
const updateNumbers = () => {
    //document.getElementById("id_name").innerText connects to the html object
    document.getElementById("yourBankBalance").innerText = bankBalanceNr;
    payBalanceNr = 0; //set the bank balance to 0
    document.getElementById("payBalance").innerText = payBalanceNr;
    document.getElementById("loanBalanceNr").innerText = loanBalanceNr;
    //Checks if the loan balance is less or equal to 0
    if(loanBalanceNr <= 0){
        //.style.visibility = "hidden" hides the html element again if loan balance is 0
        document.getElementById("loanBalance").style.visibility = "hidden";
        document.getElementById("loanBalanceNr").style.visibility = "hidden";
        activeLoan = false; //This set the loan to false
    }
}

//Part 3 The computer store
//This fetches from the url API
fetch("https://noroff-komputer-store-api.herokuapp.com/computers")
.then(response => response.json())
.then(data => computers = data)
.then(computers => addComputersToList(computers));

//This function takes in all the computers from the API
const addComputersToList = (computers) => {
    computers.forEach(x => addComputerToList(x));
    computerFeatures.innerText = computers[0].description;
    computerName.innerText = computers[0].title;
    computerDescription.innerText = computers[0].specs;
    computerPrice.innerText = computers[0].price;
    addImage(computers[0]);
}

//This function takes in 1 computer
const addComputerToList = (computer) => {
    const computerElement = document.createElement("option");
    computerElement.value = computer.id;
    computerElement.appendChild(document.createTextNode(computer.title));
    computersAvailable.appendChild(computerElement);
}

//This function creates a image element and fetches information from the API
const addImage = (selectedComputer) => {
    pcImagePlace.innerHTML = "";
    console.log(selectedComputer);
    const computerImage = document.createElement('img');
    computerImage.style.height = '150px';
    computerImage.style.width = '150px';
    const url = `https://noroff-komputer-store-api.herokuapp.com/${selectedComputer.image}`;
    fetchImage(url, computerImage);
    pcImagePlace.appendChild(computerImage);
}

//This function checks the ending of the different images and sends correct back 
const fetchImage = (url, computerImage) => {
    fetch(url)
    .then(response => {
        if(!response.ok) {
            throw new Error('Network is not responding ok');
        }
        return response.blob();
    })
    .then(imageBlob => {
        const imgElementURL = URL.createObjectURL(imageBlob);
        computerImage.src = imgElementURL;
    })
    .catch(error => {
        console.error('There has been a problem with fetch', error);
        if(url.match('.jpg')) {
            fetchImage(url.replace(/.jpg$/, '.png'), computerImage)
        }
    })
}

//This function runs when the user chooses another element
const handleComputerListChange = e => {
    const selectedComputer = computers[e.target.selectedIndex];
    computerFeatures.innerText = selectedComputer.description;
    computerName.innerText = selectedComputer.title;
    computerDescription.innerText = selectedComputer.specs;
    computerPrice.innerText = selectedComputer.price;
    console.log(selectedComputer);
    addImage(selectedComputer);
}

//This function runs when user click on the button 'Buy Now'
const buyNow = () => {
    const selectedComputer = computers[computersAvailable.selectedIndex];
    console.log(selectedComputer.price);
    //This checks if the bank balance is more or equal to the computer's price or not
    if(bankBalanceNr >= selectedComputer.price){
        bankBalanceNr = bankBalanceNr - selectedComputer.price;
        alert("Congratulation you are now the owner of this computer");
        updateNumbers();
    }
    else {
        alert("You can not afford this computer yet, you should save more money!");
    }
}

//The eventlistener("click", functionName) react when the button is clicked and takes you to the function
getLoanBtn.addEventListener("click", recieveLoan);
workBtn.addEventListener("click", work);
transfertoBankBtn.addEventListener("click", transferPayToBank);
repayLoanBtn.addEventListener("click", repayLoan);
computersAvailable.addEventListener("change", handleComputerListChange);
buyComputerBtn.addEventListener("click", buyNow);

//This project is created by Ina F. Pedersen