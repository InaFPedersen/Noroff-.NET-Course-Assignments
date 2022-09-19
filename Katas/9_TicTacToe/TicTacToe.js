const TicTacToe = () => {
    //Setting DOM to all input fields
    let r1 = document.getElementById("r1").value;
    let r2 = document.getElementById("r2").value;
    let r3 = document.getElementById("r3").value;
    let r4 = document.getElementById("r4").value;
    let r5 = document.getElementById("r5").value;
    let r6 = document.getElementById("r6").value;
    let r7 = document.getElementById("r7").value;
    let r8 = document.getElementById("r8").value;
    let r9 = document.getElementById("r9").value;

    //Checking if Player X won or not and after disable all other fields
    if( (r1 === 'X') && (r2 === 'X') && (r3 === 'X')) {
        document.getElementById("r4").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player X won'); 
    }
    else if ((r1 === 'X') && (r4 === 'X') && (r7 === 'X')) {
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player X won');
    }
    else if((r7 === 'X') && (r8 === 'X') && (r9 === 'X')){
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r6").disabled = true;
        window.alert('Player X won');
    }
    else if((r3 === 'X') && (r6 === 'X') && (r9 === 'X')){
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        window.alert('Player X won');
    }
    else if((r1 === 'X') && (r5 === 'X') && (r9 === 'X')){
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        window.alert('Player X won');
    }
    else if((r3 === 'X') && (r5 === 'X') && (r7 === 'X')){
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player X won');
    }
    else if((r2 === 'X') && (r5 === 'X') && (r8 === 'X')) {
        document.getElementById("r1").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player X won');
    }
    else if((r4 === 'X') && (r5 === 'X') && (r6 === 'X')) {
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player X won');
    }

    //Checking if Player O won or not and after disable all other fields
    if( (r1 === 'O') && (r2 === 'O') && (r3 === 'O')) {
        document.getElementById("r4").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player O won'); 
    }
    else if ((r1 === 'O') && (r4 === 'O') && (r7 === 'O')) {
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player O won');
    }
    else if((r7 === 'O') && (r8 === 'O') && (r9 === 'O')){
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r6").disabled = true;
        window.alert('Player O won');
    }
    else if((r3 === 'O') && (r6 === 'O') && (r9 === 'O')){
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r5").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        window.alert('Player O won');
    }
    else if((r1 === 'O') && (r5 === 'O') && (r9 === 'O')){
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        window.alert('Player O won');
    }
    else if((r3 === 'O') && (r5 === 'O') && (r7 === 'O')){
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player O won');
    }
    else if((r2 === 'O') && (r5 === 'O') && (r8 === 'XO')) {
        document.getElementById("r1").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r4").disabled = true;
        document.getElementById("r6").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player O won');
    }
    else if((r4 === 'O') && (r5 === 'O') && (r6 === 'XO')) {
        document.getElementById("r1").disabled = true;
        document.getElementById("r2").disabled = true;
        document.getElementById("r3").disabled = true;
        document.getElementById("r7").disabled = true;
        document.getElementById("r8").disabled = true;
        document.getElementById("r9").disabled = true;
        window.alert('Player O won');
    }
    // Here, Checking about Tie
    else if ((r1 == 'X' || r1 == 'O') && (r2 == 'X'
        || r2 == 'O') && (r3 == 'X' || r3 == 'O') &&
        (r4 == 'X' || r4 == 'O') && (r5 == 'X' ||
        r5 == 'O') && (r6 == 'X' || r6 == 'O') &&
        (r7 == 'X' || r7 == 'O') && (r8 == 'X' ||
        r8 == 'O') && (r9 == 'X' || r9 == 'O')) {
        window.alert('It is draw');
    }
}
// Function to reset game
const resetGame = () => {
    location.reload();
    document.getElementById('r1').value = '';
    document.getElementById("r2").value = '';
    document.getElementById("r3").value = '';
    document.getElementById("r4").value = '';
    document.getElementById("r5").value = '';
    document.getElementById("r6").value = '';
    document.getElementById("r7").value = '';
    document.getElementById("r8").value = '';
    document.getElementById("r9").value = '';
 
}
