function solve(n, arr) {
    let newArr = [];
    for(let i = 0; i < n; i++) {
        newArr.push(arr[i]);
    }
    const reversed = newArr.reverse();

    console.log(reversed.join(' '));
}

solve(3, [10, 20, 30, 40, 50]);