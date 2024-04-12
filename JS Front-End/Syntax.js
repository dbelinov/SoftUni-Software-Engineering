let a = 10;
let b = 20;

console.log(a + b);

if (a <= 10) {
    console.log(true);
}

console.log(add(a,b));

function add(a, b) {
    return a + b;
}

const c = 10.54224;
console.log(c.toFixed(2));

console.log(1 == "1"); //equality
console.log(1 === "1"); //identity
console.log(3 != '3');
console.log(3 !== '3');

const numbers = [1, 2, 3, 4, 5, 6];
numbers[0] = 10;
numbers.push(30);
console.log(numbers);
let empty = [];

const names = ['Gosho', 'Ivan', 'Pencho'];

for (const name of names) {
    console.log(name);
}

const reversedNames = names.reverse();
console.log(reversedNames);

console.log('10' .padStart(10, 'x'));