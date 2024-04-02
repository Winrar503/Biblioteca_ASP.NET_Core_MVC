document.addEventListener("DOMContentLoaded", function () {
    const ratings = document.querySelectorAll('.rating');

    ratings.forEach(function (rating) {
        const stars = rating.querySelectorAll('.star');
        const selectedStar = rating.querySelector('.selected');

        if (selectedStar) {
            const value = selectedStar.getAttribute('data-value');
            let currentStar = selectedStar;

            while (currentStar) {
                currentStar.classList.add('selected');
                currentStar = currentStar.previousElementSibling;
            }

            rating.querySelector('input[type="hidden"]').value = value;
        }

        stars.forEach(function (star) {
            star.addEventListener('click', function () {
                const value = this.getAttribute('data-value');
                const hiddenInput = rating.querySelector('input[type="hidden"]');
                hiddenInput.value = value;

                // Remover la clase 'selected' de todas las estrellas
                stars.forEach(function (s) {
                    s.classList.remove('selected');
                });

                // Agregar la clase 'selected' a la estrella clicada y todas las anteriores
                let prev = this;
                while (prev) {
                    prev.classList.add('selected');
                    prev = prev.previousElementSibling;
                }
            });
        });
    });
});