//document.addEventListener('DOMContentLoaded', function () {
//    const carousel = document.querySelector('.carousel-slides');
//    const prevBtn = document.getElementById('prevBtn');
//    const nextBtn = document.getElementById('nextBtn');
//    let currentSlide = 0;
//    const maxSlide = document.querySelectorAll('.carousel-slide').length;
//    const slidesVisible = getComputedStyle(document.documentElement).getPropertyValue('--slides-visible').trim() || 3;
//    const slideWidth = carousel.clientWidth / slidesVisible;

//    function updateCarousel() {
//        carousel.style.transform = `translateX(-${currentSlide * slideWidth}px)`;
//    }

//    prevBtn.addEventListener('click', function () {
//        if (currentSlide > 0) {
//            currentSlide--;
//            updateCarousel();
//        }
//    });

//    nextBtn.addEventListener('click', function () {
//        if (currentSlide < maxSlide - slidesVisible) {
//            currentSlide++;
//            updateCarousel();
//        }
//    });
//});

document.addEventListener('DOMContentLoaded', function () {
    // Sélectionne tous les conteneurs de carrousels
    const carousels = document.querySelectorAll('.carousel');

    carousels.forEach(function (carousel) {
        const slidesContainer = carousel.querySelector('.carousel-slides');
        const prevBtn = carousel.querySelector('.prevBtn'); // Changez l'ID en classe dans votre HTML
        const nextBtn = carousel.querySelector('.nextBtn'); // Changez l'ID en classe dans votre HTML
        let currentSlide = 0;
        const slides = slidesContainer.querySelectorAll('.carousel-slide');
        const maxSlide = slides.length;
        const slidesVisible = parseInt(getComputedStyle(document.documentElement).getPropertyValue('--slides-visible').trim()) || 3;
        const slideWidth = slidesContainer.clientWidth / slidesVisible;

        function updateCarousel() {
            slidesContainer.style.transform = `translateX(-${currentSlide * slideWidth}px)`;
        }

        prevBtn.addEventListener('click', function () {
            if (currentSlide > 0) {
                currentSlide--;
                updateCarousel();
            }
        });

        nextBtn.addEventListener('click', function () {
            if (currentSlide < maxSlide - slidesVisible) {
                currentSlide++;
                updateCarousel();
            }
        });
    });
});