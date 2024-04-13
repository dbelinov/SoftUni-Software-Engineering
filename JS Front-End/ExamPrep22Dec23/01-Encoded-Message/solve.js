function solve(input) {
    let message = input.shift();

    let line = input.shift();
    while(line !== 'Buy') {
        const arguments = line.split('?');
        const command = arguments[0];

        switch(command) {
            case 'TakeEven':
                let newMessage = '';
                for(let i = 0; i < message.length; i+=2) {
                    newMessage += message[i];
                }
                message = newMessage;
                console.log(message);
                break;
            case 'ChangeAll':
                const substring = arguments[1];
                const replacement = arguments[2];

                message = message.split(substring).join(replacement);
                console.log(message);
                break;
            case 'Reverse':
                let substr = arguments[1];

                if(message.includes(substr)) {
                    message = message.replace(substr, '');
                    let substrArr = Array.from(substr);
                    substrArr.reverse();
                    substr = substrArr.join('');
                    message += substr;
                    console.log(message);
                }
                else {
                    console.log('error');
                }

                break;
        }

        line = input.shift();
    }

    console.log(`The cryptocurrency is: ${message}`);
}

solve((["PZDfA2PkAsakhnefZ7aZ", 
"TakeEven",
"TakeEven",
"TakeEven",
"ChangeAll?Z?X",
"ChangeAll?A?R",
"Reverse?PRX",
"Buy"])
);