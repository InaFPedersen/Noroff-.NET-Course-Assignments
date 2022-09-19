//Number of Boomerangs
const countBoomerangs = (boomerang) => {
    let arrayOne = [];
    let arrayTwo = [];

    for (let i = 0; i < boomerang.length; i++) {

        if(boomerang[i] === boomerang[i + 2] && boomerang[i + 1] !== boomerang[i]){
            (arrayOne.push(boomerang[i]));
            (arrayOne.push(boomerang[i + 1]));
            (arrayOne.push(boomerang[i + 2]));
            //console.log(arrayOne);
            arrayTwo.push(arrayOne);
            //console.log(arrayTwo);
            arrayOne = [];
        }
        
    }
    let result = arrayTwo.length;
        return result;
}

    console.log("[9, 5, 9, 5, 1, 1, 1] contains: " + countBoomerangs([9, 5, 9, 5, 1, 1, 1]) + " boomerangs");
    console.log("[9, 5, 9, 5, 1, 1, 1] contains: " + countBoomerangs([5, 6, 6, 7, 6, 3, 9]) + " boomerangs");
    console.log("[9, 5, 9, 5, 1, 1, 1] contains: " + countBoomerangs([4, 4, 4, 9, 9, 9, 9]) + " boomerangs");
    console.log("[9, 5, 9, 5, 1, 1, 1] contains: " + countBoomerangs([1, 7, 1, 7, 1, 7, 1]) + " boomerangs");