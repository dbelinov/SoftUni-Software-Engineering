function solve (input) {
    const baristaCount = input.shift();
    const baristas = [];

    for(let i = 0; i < baristaCount; i++) {
      const baristaData = input.shift();
      const [name, shift, coffees] = baristaData.split(' ');
      const coffeeList = coffees.split(',');
      baristas[name] = { shift, coffeeList };
    }

    let line = input.shift();
    while(line !== 'Closed') {
      const arguments = line.split(' / ');
      const command = arguments[0];
      const baristaName = arguments[1];
      const currentBarista = baristas[baristaName];

      switch(command) {
        case 'Prepare':
          const shift = arguments[2];
          const coffeeType = arguments[3];

          if(currentBarista.shift === shift && currentBarista.coffeeList.includes(coffeeType)) {
            console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
          }
          else {
            console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
          }
          break;
        case 'Change Shift':
          const newShift = arguments[2];

          currentBarista.shift = newShift;
          console.log(`${baristaName} has updated his shift to: ${newShift}`);
          break;
        case 'Learn':
          const newCoffee = arguments[2];

          if(currentBarista.coffeeList.includes(newCoffee)) {
            console.log(`${baristaName} knows how to make ${newCoffee}.`);
          }
          else {
            currentBarista.coffeeList.push(newCoffee);
            console.log(`${baristaName} has learned a new coffee type: ${newCoffee}.`);
          }
          break;
      }

      line = input.shift();
    }

    for (const baristaName in baristas) {
      console.log(`Barista: ${baristaName}, Shift: ${baristas[baristaName].shift}, Drinks: ${baristas[baristaName].coffeeList.join(', ')}`);
    }
}

solve([
    '3',
      'Alice day Espresso,Cappuccino',
      'Bob night Latte,Mocha',
      'Carol day Americano,Mocha',
      'Prepare / Alice / day / Espresso',
      'Change Shift / Bob / night',
      'Learn / Carol / Latte',
      'Learn / Bob / Latte',
      'Prepare / Bob / night / Latte',
      'Closed']
    )