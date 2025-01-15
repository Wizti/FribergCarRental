document.addEventListener('DOMContentLoaded', () => {
    const togglePassword = document.querySelector('#togglePassword');
    const passwordField = document.querySelector('#password');

    togglePassword.addEventListener('click', function () {
        const type = passwordField.getAttribute('type') === 'password' ? 'text' : 'password';
        passwordField.setAttribute('type', type);
        this.innerHTML = type === 'password'
            ? '<i class="bi bi-eye"></i>'
            : '<i class="bi bi-eye-slash"></i>';
    });
});