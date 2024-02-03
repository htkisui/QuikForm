document.addEventListener('DOMContentLoaded', function () {
    const nextBtn = document.getElementById('nextBtn');
    const prevBtn = document.getElementById('prevBtn');
    const slides = document.querySelector('.carousel-slides');
    let slideIndex = 0;

    const slideWidth = slides.querySelector('.carousel-slide').clientWidth + 10;

    nextBtn.addEventListener('click', () => {
        slideIndex++;
        updateCarousel();
    });

    prevBtn.addEventListener('click', () => {
        slideIndex--;
        updateCarousel();
    });

    function updateCarousel() {
        slides.style.transform = `translateX(-${slideIndex * slideWidth}px)`;
    }