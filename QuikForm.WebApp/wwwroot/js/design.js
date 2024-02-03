document.addEventListener('DOMContentLoaded', function () {
    const carousel = document.querySelector('.carousel-slides');
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');
    let currentSlide = 0;
    const maxSlide = document.querySelectorAll('.carousel-slide').length;
    const slidesVisible = getComputedStyle(document.documentElement).getPropertyValue('--slides-visible').trim() || 3;
    const slideWidth = carousel.clientWidth / slidesVisible;

    function updateCarousel() {
        carousel.style.transform = `translateX(-${currentSlide * slideWidth}px)`;
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