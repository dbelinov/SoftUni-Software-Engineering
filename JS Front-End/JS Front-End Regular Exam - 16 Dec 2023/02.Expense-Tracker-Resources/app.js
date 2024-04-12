window.addEventListener("load", solve);

function solve() {
    const expenseTypeInputElement = document.getElementById('expense');
    const amountInputElement = document.getElementById('amount');
    const dateInputElement = document.getElementById('date');
    const addButtonElement = document.getElementById('add-btn');
    const previewListElement = document.getElementById('preview-list');

    

    addButtonElement.addEventListener('click', () => {
        const expenseType = expenseTypeInputElement.value;
        const amount = amountInputElement.value;
        const date = dateInputElement.value;    

        if(!expenseType || !amount || !date) {
            return;
        }

        const pTypeElement = document.createElement('p');
        pTypeElement.textContent = `Type: ${expenseType}`;
        const pAmountElement = document.createElement('p');
        pAmountElement.textContent = `Amount: ${amount}$`;
        const pDateElement = document.createElement('p');
        pDateElement.textContent = `Date: ${date}`

        const articleElement = document.createElement('article');
        const expenseItemListElement = document.createElement('li');
        expenseItemListElement.classList.add('expense-item');

        articleElement.appendChild(pTypeElement);
        articleElement.appendChild(pAmountElement);
        articleElement.appendChild(pDateElement);

        expenseItemListElement.appendChild(articleElement);
        previewListElement.appendChild(expenseItemListElement);

        const editButtonElement = document.createElement('button');
        editButtonElement.textContent = 'edit';
        editButtonElement.classList.add('btn', 'edit');
        const okButtonElement = document.createElement('button');
        okButtonElement.textContent = 'ok';
        okButtonElement.classList.add('btn', 'ok');

        const buttonsDivElement = document.createElement('div');
        buttonsDivElement.classList.add('buttons');
        
        buttonsDivElement.appendChild(editButtonElement);
        buttonsDivElement.appendChild(okButtonElement);

        previewListElement.appendChild(buttonsDivElement);

        addButtonElement.setAttribute('disabled', 'disabled');
        expenseTypeInputElement.value = '';
        amountInputElement.value = '';
        dateInputElement.value = '';

        //Edit Button
        editButtonElement.addEventListener('click', () => {
            expenseTypeInputElement.value = expenseType;
            amountInputElement.value = amount;
            dateInputElement.value = date;

            previewListElement.innerHTML = '';
            addButtonElement.removeAttribute('disabled');
        })

        //Ok Button
        okButtonElement.addEventListener('click', () => {
            previewListElement.innerHTML = '';

            const expensesListElement = document.getElementById('expenses-list');
            const liExpenseItemElement = document.createElement('li');
            liExpenseItemElement.classList.add('expense-item');
            liExpenseItemElement.appendChild(articleElement);

            expensesListElement.appendChild(liExpenseItemElement);

            addButtonElement.removeAttribute('disabled');

            //Delete Button
            const expensesElement = document.getElementById('expenses');
            const deleteButtonElement = expensesElement.querySelector('.btn.delete')

            deleteButtonElement.addEventListener('click', () => {
            expensesListElement.innerHTML = '';
        })
        })
    })
}