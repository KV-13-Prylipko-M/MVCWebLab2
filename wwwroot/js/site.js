let displayValue = '';
let pendingValue = '';
let operation = '';

function appendNumber(number) {
    displayValue += number;
    updateDisplay();
}

function setOperation(op) {
    if (displayValue === '') return;
    if (pendingValue !== '') {
        calculate();
    }
    pendingValue = displayValue;
    displayValue = '';
    operation = op;
}

function calculate() {
    if (pendingValue === '' || displayValue === '' || operation === '') return;
    let result;
    switch (operation) {
        case '+':
            result = parseFloat(pendingValue) + parseFloat(displayValue);
            break;
        case '-':
            result = parseFloat(pendingValue) - parseFloat(displayValue);
            break;
        case '*':
            result = parseFloat(pendingValue) * parseFloat(displayValue);
            break;
        case '/':
            result = parseFloat(pendingValue) / parseFloat(displayValue);
            break;
        default:
            return;
    }
    displayValue = result.toString();
    pendingValue = '';
    operation = '';
    updateDisplay();
}

function clearDisplay() {
    displayValue = '';
    pendingValue = '';
    operation = '';
    updateDisplay();
}

function updateDisplay() {
    document.getElementById('display').value = displayValue;
}

document.getElementById('standardMode').addEventListener('click', function() {
    
});

document.getElementById('programmerMode').addEventListener('click', function() {
    
});
