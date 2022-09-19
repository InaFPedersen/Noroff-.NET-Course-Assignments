
const getNonNested = arrayList => arrayList.flat(Infinity).length;
console.log("[1, [2, 3]] has " + getNonNested([1, [2, 3]]) + " non-nested items");
console.log("[1, [2, [3, 4]]] has " + getNonNested([1, [2, [3, 4]]]) + " non-nested items");
console.log("[1, [2], 1, [2], 1] has " + getNonNested([1, [2], 1, [2], 1]) + " non-nested items");
console.log("[1, [2, [3, [4, [5, 6]]]]] has " + getNonNested([1, [2, [3, [4, [5, 6]]]]]) + " non-nested items");
console.log("[1, [2, [3, [4, [5, 6, 78, [82, 5]]]]]] has " + getNonNested([1, [2, [3, [4, [5, 6, 78, [82, 5]]]]]]) + " non-nested items");
console.log("[] has " + getNonNested([]) + " non-nested items");
console.log("[This is text, 6, [15, 92]] has " + getNonNested(["This is text", 6, [15, 92]]) + " non-nested items");