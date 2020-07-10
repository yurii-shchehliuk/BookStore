window.onload = function () {
    $('.slider__box').slick({
        dots: true,
        infinite: true,
        speed: 600,
        slidesToShow: 1,
        adaptiveHeight: true,
        autoplay: true,
        autoplaySpeed: 6000,
        swipeToSlide: true,
        nextArrow: '<i class="fas fa-arrow-circle-right slider-btn slider-next"></i>',
        prevArrow: '<i class="fas fa-arrow-circle-left slider-btn slider-prev"></i>'
    });

    $('.second-slider').slick({
        dots: true,
        infinite: true,
        speed: 600,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 6000,

        swipeToSlide: true,
        nextArrow: '<i class="fas fa-arrow-circle-right slider-btn slider-next2"></i>',
        prevArrow: '<i class="fas fa-arrow-circle-left slider-btn slider-prev2"></i>',

        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });


    /////////////////////INPUT ANIMATION/////////////////////////
    
        $('#hInput').bind('focus', function () {
            $('#loupe').css('transform', 'translateX(40px)');
        });
        $('#hInput').bind('focusout', function () {
            $('#loupe').css('transform', 'translateX(0)');
        });

    /////////////////////////////////////////////////////////////

}