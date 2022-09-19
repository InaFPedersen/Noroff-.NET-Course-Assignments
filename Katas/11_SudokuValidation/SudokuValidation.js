//This function filter out empty spaces by using filter()
const validateArrayElements = (arrayElements) => {
    const arrayDigits = arrayElements.filter((character) => character !== '.');
    return arrayDigits.length === [...new Set(arrayDigits)].length;
};

//This function looks at rows, column and grids to see if they contains 1-9 only once
const sudokuValidator = (sudokuBoard) => {
    const [validatedElements, grids] = [[], []];

    sudokuBoard.forEach((row, rowIndex) => {
        //Validating the rows
        validatedElements.push(validateArrayElements(row));

        //then validate the colums
        const column = [];
        for (let columnIndex = 0; columnIndex < sudokuBoard.length; columnIndex++) {
            column.push(sudokuBoard[columnIndex][rowIndex]);
        }
        validatedElements.push(validateArrayElements(column));

        // then push the grids
        grids.push([]);
    });

    //then validate the Grids
    sudokuBoard.forEach((row, rowIndex) => {
        row.forEach((character, characterIndex) => {
            let gridRow = 0;
            if (rowIndex >= 3 && rowIndex <= 5) {
                gridRow = 1;
            } else if(rowIndex >= 6 && rowIndex <= 8){
                gridRow = 2;
            }

            if(characterIndex >= 3 && characterIndex <= 5){
                gridRow += 3;
            } else if(characterIndex >= 6 && characterIndex <= 8){
                gridRow += 6;
            }

            grids[gridRow].push(character);
        });
    });

    grids.forEach((grid) => {
        validatedElements.push(validateArrayElements(grid));
    });

    return validatedElements.every((value) => value === true);
}

console.log("The first sudoku is: " + sudokuValidator([
    [ 1, 5, 2, 4, 8, 9, 3, 7, 6 ],
    [ 7, 3, 9, 2, 5, 6, 8, 4, 1 ],
    [ 4, 6, 8, 3, 7, 1, 2, 9, 5 ],
    [ 3, 8, 7, 1, 2, 4, 6, 5, 9 ],
    [ 5, 9, 1, 7, 6, 3, 4, 2, 8 ],
    [ 2, 4, 6, 8, 9, 5, 7, 1, 3 ],
    [ 9, 1, 4, 6, 3, 7, 5, 8, 2 ],
    [ 6, 2, 5, 9, 4, 8, 1, 3, 7 ],
    [ 8, 7, 3, 5, 1, 2, 9, 6, 4 ]
  ]) );
  console.log("The second sudoku is: " + sudokuValidator([
    [ 1, 1, 2, 4, 8, 9, 3, 7, 6 ],
    [ 7, 3, 9, 2, 5, 6, 8, 4, 1 ],
    [ 4, 6, 8, 3, 7, 1, 2, 9, 5 ],
    [ 3, 8, 7, 1, 2, 4, 6, 5, 9 ],
    [ 5, 9, 1, 7, 6, 3, 4, 2, 8 ],
    [ 2, 4, 6, 8, 9, 5, 7, 1, 3 ],
    [ 9, 1, 4, 6, 3, 7, 5, 8, 2 ],
    [ 6, 2, 5, 9, 4, 8, 1, 3, 7 ],
    [ 8, 7, 3, 5, 1, 2, 9, 6, 4 ]
  ]) );
  
  
