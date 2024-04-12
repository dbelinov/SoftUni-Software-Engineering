let person = {name: 'Pesho', age: 20};

console.log(person);
console.log(person['age']);

let animal = {};
animal.name = 'Gosheto';
animal['Profesiq'] = 'It specialist';
console.log(animal)

const cat = {
    name: 'Navcho',
    breed: 'Persian',
    age: 9,
    grades: [5, 6, 5, 6, 5],
    owner: {
        name: 'Ivo',
        age: 24,
    },
    makeSound: function () {
        console.log('Meow...');
    }
}

cat.makeSound();

function solve(firstName, lastName, hairColor) {
    const info = {
        name: firstName,
        lastName,
        hairColor,
    };

    const jsonData = JSON.stringify(info);
    console.log(jsonData)
}

solve("George", "Jones", "Brown")

const phoneBook = {
    'Ginka': +359892843992,
    'Pencho' : +359784593002,
}

console.log(phoneBook['Ginka'])
console.log('Pencho' in phoneBook);

class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    greet(to) {
        console.log(`${this.firstName} says hi to ${this.lastName}`)
    }
}

function solve(input) {
    const phoneBook = {};

    for (const line of input) {
        const[name, phone] = line.split(' ')

        phoneBook[name] = phone;
    }


}