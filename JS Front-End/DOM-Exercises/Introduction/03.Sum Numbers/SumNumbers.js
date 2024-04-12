function calc() {
    const firstNumberElement = document.getElementById('num1');
    const secondNumberElement = document.getElementById('num2');

    const firstNumber = Number(firstNumberElement.value);
    const secondNumber = Number(secondNumberElement.value);

    const resultElement = document.getElementById('sum');
    resultElement.value = firstNumber + secondNumber;
}
