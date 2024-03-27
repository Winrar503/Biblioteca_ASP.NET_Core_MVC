document.querySelectorAll('.rating input').forEach((input) => {
    input.addEventListener('click', function () {
        input.parentNode.parentNode.querySelector('.text-danger').innerText = ''; // Clear any existing validation message
    });
});
