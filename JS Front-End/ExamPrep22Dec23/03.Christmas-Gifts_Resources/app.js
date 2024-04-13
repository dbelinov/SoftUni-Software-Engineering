const baseUrl = 'http://localhost:3030/jsonstore/gifts';

const loadPresentsButtonElement = document.getElementById('load-presents');
const giftListElement = document.getElementById('gift-list');
const editPresentButtonElement = document.getElementById('edit-present');
const addPresentButtonElement = document.getElementById('add-present');
const presentInputElement = document.getElementById('gift');
const forInputElement = document.getElementById('for');
const priceInputElement = document.getElementById('price');
const formElement = document.getElementById('form');

const loadPresents = async() => {
    const response = await fetch(baseUrl);
    const data = await response.json();

    giftListElement.innerHTML = '';

    for (const present of Object.values(data)) {
        const giftPElement = document.createElement('p');
        giftPElement.textContent = present.gift;
        const receiverPElement = document.createElement('p');
        receiverPElement.textContent = present.for;
        const pricePElement = document.createElement('p');
        pricePElement.textContent = present.price;

        const contentDivElement = document.createElement('div');
        contentDivElement.classList.add('content');
        contentDivElement.appendChild(giftPElement);
        contentDivElement.appendChild(receiverPElement);
        contentDivElement.appendChild(pricePElement);

        const changeButtonElement = document.createElement('button');
        changeButtonElement.classList.add('change-btn');
        changeButtonElement.textContent = 'Change';
        const deleteButtonElement = document.createElement('button');
        deleteButtonElement.classList.add('delete-btn');
        deleteButtonElement.textContent = 'Delete';

        const buttonsContainerDivElement = document.createElement('div');
        buttonsContainerDivElement.classList.add('buttons-container');
        buttonsContainerDivElement.appendChild(changeButtonElement);
        buttonsContainerDivElement.appendChild(deleteButtonElement);

        const giftSockElement = document.createElement('div');
        giftSockElement.classList.add('gift-sock');
        giftSockElement.appendChild(contentDivElement);
        giftSockElement.appendChild(buttonsContainerDivElement);

        giftListElement.appendChild(giftSockElement);

        changeButtonElement.addEventListener('click', () => {
            formElement.setAttribute('data-id', present._id);

            giftSockElement.remove();
            presentInputElement.value = present.gift;
            forInputElement.value = present.for;
            priceInputElement.value = present.price;

            addPresentButtonElement.setAttribute('disabled', 'disabled');
            editPresentButtonElement.removeAttribute('disabled');
        });

        deleteButtonElement.addEventListener('click', async () => {
            const response = await fetch(`${baseUrl}/${present._id}`, {
                method: 'DELETE'
            })

            if(!response.ok) {
                return;
            }

            loadPresents();
        })
    }
}

loadPresentsButtonElement.addEventListener('click', loadPresents);

addPresentButtonElement.addEventListener('click', async () => {
    const present = presentInputElement.value;
    const receiver = forInputElement.value;
    const price = priceInputElement.value;

    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            gift: present,
            for: receiver,
            price: price,
        }),
    });

    if(!response.ok) {
        return;
    }

    loadPresents();
    clearInputFields();
});

editPresentButtonElement.addEventListener('click', async() => {
    const present = getInputData();

    const dataID = formElement.getAttribute('data-id');
    const response = await fetch(`${baseUrl}/${dataID}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({...present, _id: dataID}),
    });

    if(!response.ok) {
        return;
    }

    formElement.removeAttribute('data-id');
    editPresentButtonElement.setAttribute('disabled', 'disabled');
    addPresentButtonElement.removeAttribute('disabled');

    loadPresents();
    clearInputFields();
})

function clearInputFields() {
    presentInputElement.value = '';
    forInputElement.value = '';
    priceInputElement.value = '';
}

function getInputData() {
    const gift = presentInputElement.value;
    const receiver = forInputElement.value;
    const price = priceInputElement.value;

    return {
        gift,
        for: receiver,
        price
    }
}