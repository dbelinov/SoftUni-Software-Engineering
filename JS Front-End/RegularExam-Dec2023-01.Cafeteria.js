function solve(input) {
    const baristaCount = input.shift();
    const baristas = [];

    for (let i = 0; i < baristaCount; i++) {
        const line = input.shift();
        const [name, shift, coffees] = line.split(' ');
        const coffeeList = coffees.split(',');
        baristas.push({name, shift, coffeeList});
    }

    let commandLine = input.shift();

    while(commandLine !== 'Closed') {
        const arguments = commandLine.split(' / ')
        const command = arguments[0];
        const baristaName = arguments[1];
        const barista = baristas.find(barista => barista.name === baristaName);

        if (command === 'Prepare') {
            const shift = arguments[2];
            const coffeeType = arguments[3];

            if (barista.shift === shift && barista.coffeeList.includes(coffeeType)) {
                console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
            }
            else {
                console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
            }
        }
        else if (command === 'Change Shift') {
            const newShift = arguments[2];
            barista.shift = newShift;
            console.log(`${baristaName} has updated his shift to: ${newShift}`)
        }
        else if(command === 'Learn') {
            const newCoffee = arguments[2];
            if (barista.coffeeList.includes(newCoffee)) {
                console.log(`${baristaName} knows how to make ${newCoffee}.`);
            }
            else {
                barista.coffeeList.push(newCoffee);
                console.log(`${baristaName} has learned a new coffee type: ${newCoffee}.`);
            }
        }

        commandLine = input.shift();
    }

    for (const barista of baristas) {
        console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${barista.coffeeList.join(', ')}`);
    }
}

solve(['4',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'David night Espresso',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / day',
    'Learn / Carol / Latte',
    'Prepare / Bob / night / Latte',
    'Learn / David / Cappuccino',
    'Prepare / Carol / day / Cappuccino',
    'Change Shift / Alice / night',
    'Learn / Bob / Mocha',
    'Prepare / David / night / Espresso',
    'Closed']
);