const baseUrl = 'http://localhost:3030/jsonstore/tasks';
 
const loadButtonElement = document.getElementById('load-meals');
const addButtonElement = document.getElementById('add-meal');
const editButtonElement = document.getElementById('edit-meal');
const listDivElement = document.getElementById('list');
const foodInputElement = document.getElementById('food');
const timeInputElement = document.getElementById('time');
const caloriesInputElement = document.getElementById('calories');
const formElement = document.getElementById('form');
 
//Load Meals
const loadMeals = async() => {
    const response = await fetch(baseUrl);
    const data = await response.json();
 
    listDivElement.innerHTML = "";
 
    for (const meal of Object.values(data)) {
        const changeMealButton = document.createElement('button');
        changeMealButton.textContent = "Change";
        changeMealButton.classList.add('change-meal');
        const deleteMealButton = document.createElement('button');
        deleteMealButton.textContent = "Delete";
        deleteMealButton.classList.add('delete-meal');
        const mealButtonsDivElement = document.createElement('div');
        mealButtonsDivElement.setAttribute('id', 'meal-buttons');
 
        mealButtonsDivElement.appendChild(changeMealButton);
        mealButtonsDivElement.appendChild(deleteMealButton);
 
        const foodH2Element = document.createElement('h2');
        foodH2Element.textContent = meal.food;
        const timeH3Element = document.createElement('h3');
        timeH3Element.textContent = meal.time;
        const caloriesH3Element = document.createElement('h3');
        caloriesH3Element.textContent = meal.calories;
 
        const mealDivElement = document.createElement('div');
        mealDivElement.classList.add('meal');
 
        mealDivElement.appendChild(foodH2Element);
        mealDivElement.appendChild(timeH3Element);
        mealDivElement.appendChild(caloriesH3Element);
        mealDivElement.appendChild(mealButtonsDivElement);
 
        listDivElement.appendChild(mealDivElement);
 
        changeMealButton.addEventListener('click', () => {
            formElement.setAttribute('data-id', meal._id);
 
            foodInputElement.value = meal.food;
            timeInputElement.value = meal.time;
            caloriesInputElement.value = meal.calories;
 
            editButtonElement.removeAttribute('disabled');
            addButtonElement.setAttribute('disabled', 'disabled');
 
            mealDivElement.remove();
        });
 
        deleteMealButton.addEventListener('click', async () => {
            await fetch(`${baseUrl}/${meal._id}`, {
                method: 'DELETE',
            })
 
            await loadMeals();
        })
    }
}
 
loadButtonElement.addEventListener('click', loadMeals);
 
addButtonElement.addEventListener('click', async () => {
    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;
    const newMeal = {food, time, calories};
 
    const response = await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(newMeal),
    });
 
    if (!response.ok) {
        return;
    }
 
    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';
 
    await loadMeals();
});
 
editButtonElement.addEventListener('click', async () => {
    const food = foodInputElement.value;
    const time = timeInputElement.value;
    const calories = caloriesInputElement.value;
    const dataId = formElement.getAttribute('data-id');
 
    const response = await fetch(`${baseUrl}/${dataId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: dataId,
            food,
            time,
            calories,
        })
    })
 
    if(!response.ok) {
        return
    }
 
    editButtonElement.setAttribute('disabled', 'disabled');
    addButtonElement.removeAttribute('disabled');
 
    formElement.removeAttribute('data-id');
 
    foodInputElement.value = '';
    timeInputElement.value = '';
    caloriesInputElement.value = '';
 
    await loadMeals();
});