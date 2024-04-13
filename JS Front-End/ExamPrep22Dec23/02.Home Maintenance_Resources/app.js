window.addEventListener("load", solve);

function solve() {
    const addButtonElement = document.getElementById('add-btn');
    const placeInputElement = document.getElementById('place');
    const actionInputElement = document.getElementById('action');
    const personInputElement = document.getElementById('person');
    const taskListElement = document.getElementById('task-list');
    const doneListElement = document.getElementById('done-list');

    addButtonElement.addEventListener('click', () => {
        const place = placeInputElement.value;
        const action = actionInputElement.value;
        const person = personInputElement.value;

        if(!place || !action || !person) {
            return;
        }
        
        const placePElement = document.createElement('p');
        placePElement.textContent = `Place: ${place}`;
        const actionPElement = document.createElement('p');
        actionPElement.textContent = `Action: ${action}`;
        const personPElement = document.createElement('p');
        personPElement.textContent = `Person: ${person}`;

        const articleElement = document.createElement('article');
        articleElement.appendChild(placePElement);
        articleElement.appendChild(actionPElement);
        articleElement.appendChild(personPElement);

        const editButtonElement = document.createElement('button');
        editButtonElement.textContent = 'Edit';
        editButtonElement.classList.add('edit');
        const doneButtonElement = document.createElement('button');
        doneButtonElement.textContent = 'Done';
        doneButtonElement.classList.add('done');

        const buttonsDivElement = document.createElement('div');
        buttonsDivElement.classList.add('buttons');
        buttonsDivElement.appendChild(editButtonElement);
        buttonsDivElement.appendChild(doneButtonElement);

        const taskLiElement = document.createElement('li');
        taskLiElement.classList.add('clean-task');
        taskLiElement.appendChild(articleElement);
        taskLiElement.appendChild(buttonsDivElement);

        taskListElement.appendChild(taskLiElement);

        placeInputElement.value = '';
        actionInputElement.value = '';
        personInputElement.value = '';

        //Edit Button
        editButtonElement.addEventListener('click', () => {
            placeInputElement.value = place;
            actionInputElement.value = action;
            personInputElement.value = person;

            taskLiElement.remove();
        })

        //Done Button
        doneButtonElement.addEventListener('click', () => {
            taskLiElement.remove();
            buttonsDivElement.remove()
            doneListElement.appendChild(taskLiElement);
            taskLiElement.classList.remove('clean-task');

            const deleteButtonElement = document.createElement('button');
            deleteButtonElement.textContent = 'Delete';
            deleteButtonElement.classList.add('delete');

            taskLiElement.appendChild(deleteButtonElement);

            deleteButtonElement.addEventListener('click', () => {
                taskLiElement.remove();
            })
        })
    })
}